import React, { useState } from "react";
import Constants from "./../utilities/Constants";
import moment from "moment";

export default function ExpensesCreateForm(props) {
	const [ExpenseData, setExpenseData] = useState({});

	const handleChange = (e) => {
		setExpenseData({
			...ExpenseData,
			[e.target.name]: e.target.value,
		});
	};

	const handleSubmit = (e) => {
		e.preventDefault();

		const expenseToCreate = {
			name: ExpenseData.name,
			date: moment(Date.now()).format("yyyy-MM-DD"),
			value: ExpenseData.value,
		};

		const url = Constants.API_URL_CREATE_Expense;

		console.log(url);

		fetch(url, {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(expenseToCreate),
		})
			.then((response) => response.json())
			.then((responseFromServer) => {
				console.log(responseFromServer);
			})
			.catch((error) => {
				console.log(error);
				alert(error);
			});

		props.onExpenseCreated(expenseToCreate);
	};

	return (
		<div>
			<div className="w-100 px-5">
				<h1 className="mt-5">Create new Expense</h1>

				<div className="mt-5">
					<label className="h3 Expense-label">Name</label>
					<input
						placeholder="Expense name"
						value={ExpenseData.name}
						name="name"
						type="text"
						className="Expense-control"
						onChange={handleChange}
					/>
				</div>

				<div className="mt-4">
					<label className="h3 Expense-label">Expense Amount</label>
					<input
						placeholder={100}
						value={ExpenseData.value}
						name="value"
						type="text"
						className="Expense-control"
						onChange={handleChange}
					/>
				</div>
			</div>

			<button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">
				Submit
			</button>
			<button
				onClick={() => props.onExpenseCreated(null)}
				className="btn btn-secondary btn-lg w-100 mt-3"
			>
				Cancel
			</button>
		</div>
	);
}
