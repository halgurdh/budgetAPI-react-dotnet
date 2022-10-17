import React, { useState } from "react";
import Constants from "../utilities/Constants";

export default function CategoryCreateForm(props) {
  const [CategoryData, setCategoryData] = useState({});

  const handleChange = (e) => {
    setCategoryData({
      ...CategoryData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const CategoryToCreate = {
      name: CategoryData.name,
    };

    const url = Constants.API_URL_CREATE_Category;

    console.log(url);

    fetch(url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(CategoryToCreate),
    })
      .then((response) => response.json())
      .then((responseFromServer) => {
        console.log(responseFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onCategoryCreated(CategoryToCreate);
  };

  return (
    <div>
      <div className="w-100 px-5">
        <h1 className="mt-5">Create new Category</h1>

        <div className="mt-5">
          <label className="h3 Category-label">Name</label>
          <input
            placeholder="Category name"
            value={CategoryData.name}
            name="name"
            type="text"
            className="Category-control"
            onChange={handleChange}
          />
        </div>
      </div>

      <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">
        Submit
      </button>
      <button
        onClick={() => props.onCategoryCreated(null)}
        className="btn btn-secondary btn-lg w-100 mt-3"
      >
        Cancel
      </button>
    </div>
  );
}
