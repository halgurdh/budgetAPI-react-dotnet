import React, { useState } from "react";
import Constants from "../utilities/Constants";

export default function IncomeUpdateForm(props) {
    const [IncomeData, setFormData] = useState({
      name: props.Income.name,
      value: props.Income.value
  });

  const handleChange = (e) => {
    setFormData({
      ...IncomeData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const IncomeToUpdate = {
      id: props.Income.id,
      name: IncomeData.name,
      value: IncomeData.value,
    };

    const url = Constants.API_URL_UPDATE_Income;

    fetch(url, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(IncomeToUpdate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onIncomeUpdated(IncomeToUpdate);
  };

  return (
    <div>
      <form className="w-100 px-5">
        <h1 className="mt-5">Update Espense: "{IncomeData.name}".</h1>

        <div className="mt-5">
          <label className="h3 form-label">Title</label>
          <input
            value={IncomeData.name}
            name="name"
            type="text"
            className="form-control"
            onChange={handleChange}
          />
        </div>

        <div className="mt-4">
          <label className="h3 form-label">Amount</label>
          <input
            value={IncomeData.value}
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
        onClick={() => props.onIncomeUpdated(null)}
        className="btn btn-secondary btn-lg w-100 mt-3"
      >
        Cancel
      </button>
    </div>
  );
}
