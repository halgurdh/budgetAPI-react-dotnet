import React, { useState } from "react";
import Constants from "../utilities/Constants";

export default function CategoryUpdateForm(props) {
  const [CategoryData, setFormData] = useState({
    name: props.Category.name,
    value: props.Category.value,
  });

  const handleChange = (e) => {
    setFormData({
      ...CategoryData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const CategoryToUpdate = {
      categoryID: props.Category.categoryID,
      name: CategoryData.name,
    };

    const url = Constants.API_URL_UPDATE_Category;

    fetch(url, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(CategoryToUpdate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onCategoryUpdated(CategoryToUpdate);
  };

  return (
    <div>
      <form className="w-100 px-5">
        <h1 className="mt-5">Update Espense: "{CategoryData.name}".</h1>

        <div className="mt-5">
          <label className="h3 form-label">Title</label>
          <input
            value={CategoryData.name}
            name="name"
            type="text"
            className="form-control"
            onChange={handleChange}
          />
        </div>

        <div className="mt-4">
          <label className="h3 form-label">Amount</label>
          <input
            value={CategoryData.value}
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
        onClick={() => props.onCategoryUpdated(null)}
        className="btn btn-secondary btn-lg w-100 mt-3"
      >
        Cancel
      </button>
    </div>
  );
}
