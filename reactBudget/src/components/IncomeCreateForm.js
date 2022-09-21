import React, { useState } from "react";
import Constants from "../utilities/Constants";
import moment from "moment";

export default function IncomeCreateForm(props) {
	const [IncomeData, setIncomeData] = useState({});

	const handleChange = (e) => {
		setIncomeData({
			...IncomeData,
			[e.target.name]: e.target.value,
		});
	};

	const handleSubmit = (e) => {
		e.preventDefault();

		const IncomeToCreate = {
			name: IncomeData.name,
			date: moment(Date.now()).format("yyyy-MM-DD"),
			value: IncomeData.value,
		};

		const url = Constants.API_URL_CREATE_Income;

		console.log(url);

		fetch(url, {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(IncomeToCreate),
		})
			.then((response) => response.json())
			.then((responseFromServer) => {
				console.log(responseFromServer);
			})
			.catch((error) => {
				console.log(error);
				alert(error);
			});

		props.onIncomeCreated(IncomeToCreate);
	};

	return (
		<div>
			<div className="w-100 px-5">
				<h1 className="mt-5">Create new Income</h1>

				<div className="mt-5">
					<label className="h3 Income-label">Name</label>
					<input
						placeholder="Income name"
						value={IncomeData.name}
						name="name"
						type="text"
						className="Income-control"
						onChange={handleChange}
					/>
				</div>

				<div className="mt-4">
					<label className="h3 Income-label">Income Amount</label>
					<input
						placeholder={100}
						value={IncomeData.value}
						name="value"
						type="text"
						className="Income-control"
						onChange={handleChange}
					/>
				</div>
			</div>

			<button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">
				Submit
			</button>
			<button
				onClick={() => props.onIncomeCreated(null)}
				className="btn btn-secondary btn-lg w-100 mt-3"
			>
				Cancel
			</button>
		</div>
	);
}
