import moment from "moment";
import React, { useState } from "react";
import Constants from "../utilities/Constants";

export default function ExpensesUpdateForm(props) {
  const [expenseData, setFormData] = useState({
    name: props.Expense.name,
    value: props.Expense.value,
  });

  const handleChange = (e) => {
    setFormData({
      ...expenseData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const expenseToUpdate = {
      expensesID: props.Expense.expensesID,
      name: expenseData.name,
      date: moment(Date.now()).format("yyyy-MM-DD"),
      value: expenseData.value,
      categoryID: props.Expense.categoryID,
    };

    const url = Constants.API_URL_UPDATE_Expense;

    fetch(url, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(expenseToUpdate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onExpenseUpdated(expenseToUpdate);
  };

  return (
    <div>
      <form className="w-100 px-5">
        <h1 className="mt-5">Update Espense: "{expenseData.name}".</h1>

        <div className="mt-5">
          <label className="h3 form-label">Title</label>
          <input
            value={expenseData.name}
            name="name"
            type="text"
            className="form-control"
            onChange={handleChange}
          />
        </div>

        <div className="mt-4">
          <label className="h3 form-label">Amount</label>
          <input
            value={expenseData.value}
            name="value"
            type="text"
            className="form-control"
            onChange={handleChange}
          />
        </div>
      </form>

      <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">
        Submit
      </button>
      <button
        onClick={() => props.onExpenseUpdated(null)}
        className="btn btn-secondary btn-lg w-100 mt-3"
      >
        Cancel
      </button>
    </div>
  );
}
