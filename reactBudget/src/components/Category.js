import React, { useState } from "react";
import Constants from "../utilities/Constants";
import CategoryCreateForm from "./CategoryCreateForm";
import CategoryUpdateForm from "./CategoryUpdateForm";
import moment from "moment";

export default function Category() {
  const [Category, setCategory] = useState([]);
  const [showCreateCategoryForm, setShowCreateCategoryForm] = useState(false);
  const [showUpdateCategoryForm, setShowUpdateCategoryForm] = useState(null);

  function getCategory() {
    const url = Constants.API_URL_GET_ALL_Category;

    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((CategoryFromServer) => {
        console.log(CategoryFromServer);
        setCategory(CategoryFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  return (
    <div>
      <button onClick={getCategory} className="btn btn-dark btn-lg w-100">
        Get Category
      </button>

      <button
        onClick={() => setShowCreateCategoryForm(true)}
        className="btn btn-secondary btn-lg w-100 mt-4"
      >
        Create new Category
      </button>
      {Category.length > 0 &&
        showCreateCategoryForm === false &&
        showUpdateCategoryForm === null &&
        renderCategoryTable()}

      {showCreateCategoryForm && (
        <CategoryCreateForm onCategoryCreated={onCategoryCreated} />
      )}

      {showUpdateCategoryForm && (
        <CategoryUpdateForm
          Category={showUpdateCategoryForm}
          onCategoryUpdated={onCategoryUpdated}
        />
      )}
    </div>
  );

  function renderCategoryTable() {
    return (
      <div>
        {showCreateCategoryForm === false && showUpdateCategoryForm === null && (
          <div className="table-responsive mt-5">
            <table className="table table-bordered border-dark">
              <thead>
                <tr>
                  <th scope="col">categoryID (PK)</th>
                  <th scope="col">Date</th>
                  <th scope="col">Name</th>
                  <th scope="col">Value</th>
                  <th scope="col">CRUD</th>
                </tr>
              </thead>
              <tbody>
                {Category.map((Category) => (
                  <tr key={Category.categoryID}>
                    <th scope="row">{Category.categoryID}</th>
                    <td>{Category.name}</td>
                    <td>
                      <button
                        onClick={() => setShowUpdateCategoryForm(Category)}
                        className="btn btn-dark btn-lg mx-3 my-3"
                      >
                        Update
                      </button>
                      <button
                        onClick={() => setDelete(Category.categoryID)}
                        className="btn btn-secondary btn-lg"
                      >
                        Delete
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>

            <button
              onClick={() => setCategory([])}
              className="btn btn-dark btn-lg w-100"
            >
              Empty Array
            </button>
          </div>
        )}
      </div>
    );
  }

  function onCategoryCreated(createdCategory) {
    setShowCreateCategoryForm(false);

    if (createdCategory === null) {
      return;
    } else {
      console.log(`Category created!: "${createdCategory.name}"`);
    }

    setTimeout(() => {
      getCategory();
    }, 100);
  }

  function onCategoryUpdated() {
    setShowUpdateCategoryForm(null);
    setTimeout(() => {
      getCategory();
    }, 100);
  }

  function setDelete(categoryID) {
    const url = `${Constants.API_URL_DELERE_Category_BY_ID}/${categoryID}`;

    if (window.confirm("Are you sure you want to delete this Category?")) {
      fetch(url, {
        method: "Delete",
      })
        .then((response) => response.json())
        .then((reponseFromServer) => {
          console.log(reponseFromServer);
          getCategory();
        })
        .catch((error) => {
          console.log(error);
          alert(error);
        });
    }
  }
}
