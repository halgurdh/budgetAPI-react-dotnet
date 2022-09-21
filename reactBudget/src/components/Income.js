import React, { useState } from "react";
import Constants from "../utilities/Constants";
import IncomeCreateForm from "./IncomeCreateForm";
import IncomeUpdateForm from "./IncomeUpdateForm"
import moment from "moment";

export default function Income() {
    const [Income, setIncome] = useState([]);
    const [showCreateIncomeForm, setShowCreateIncomeForm] = useState(false);
    const [showUpdateIncomeForm, setShowUpdateIncomeForm] = useState(null);

    function getIncome() {
        const url = Constants.API_URL_GET_ALL_Income;

        fetch(url, {
            method: "GET",
        })
            .then((response) => response.json())
            .then((IncomeFromServer) => {
                console.log(IncomeFromServer);
                setIncome(IncomeFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });
    }

    return (
        <div>
              <button
                onClick={getIncome}
                className="btn btn-dark btn-lg w-100"
            >
                Get Income
            </button>

            <button
                onClick={() => setShowCreateIncomeForm(true)}
                className="btn btn-secondary btn-lg w-100 mt-4"
            >
                Create new Income
            </button>
            {
                Income.length > 0 &&
                showCreateIncomeForm === false &&
                showUpdateIncomeForm === null &&
                renderIncomeTable()
            }

            {
                showCreateIncomeForm && (
                    <IncomeCreateForm onIncomeCreated={onIncomeCreated} />
                )
            }

            {
                showUpdateIncomeForm && (
                    <IncomeUpdateForm
                        Income={showUpdateIncomeForm}
                        onIncomeUpdated={onIncomeUpdated}
                    />
                )
            }
        </div>
    )

function renderIncomeTable() {
    return (
        <div>
            {showCreateIncomeForm === false && showUpdateIncomeForm === null && (
                <div className="table-responsive mt-5">
                    <table className="table table-bordered border-dark">
                        <thead>
                            <tr>
                                <th scope="col">IncomeId (PK)</th>
                                <th scope="col">Date</th>
                                <th scope="col">Name</th>
                                <th scope="col">Value</th>
                                <th scope="col">CRUD</th>
                            </tr>
                        </thead>
                        <tbody>
                            {Income.map((Income) => (
                                
                                <tr key={Income.id}>
                                    <th scope="row">{Income.id}</th>
                                    <td>{moment(Income.date).format("DD/MM/yyyy")}</td>
                                    <td>{Income.name}</td>
                                    <td>{Income.value}</td>
                                    <td>
                                        <button
                                            onClick={() => setShowUpdateIncomeForm(Income)}
                                            className="btn btn-dark btn-lg mx-3 my-3"
                                        >
                                            Update
                                        </button>
                                        <button
                                            onClick={() => setDelete(Income.id)}
                                            className="btn btn-secondary btn-lg">Delete</button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>

                    <button
                        onClick={() => setIncome([])}
                        className="btn btn-dark btn-lg w-100"
                    >
                        Empty Array
                    </button>
                </div>
            )}
        </div>
    )
}

function onIncomeCreated(createdIncome) {
    setShowCreateIncomeForm(false);

    if (createdIncome === null) {
        return;
    } else {
        console.log(`Income created!: "${createdIncome.name}"`);
    }

    setTimeout(() => {
        getIncome();
    }, 100);
}

function onIncomeUpdated() {
    setShowUpdateIncomeForm(null);
    setTimeout(() => {
        getIncome();
    }, 100);
}

function setDelete(IncomeId) {
    const url = `${Constants.API_URL_DELERE_Income_BY_ID}/${IncomeId}`;

    if (window.confirm("Are you sure you want to delete this Income?")) {
        fetch(url, {
            method: "Delete",
        })
            .then((response) => response.json())
            .then((reponseFromServer) => {
                console.log(reponseFromServer);
                getIncome();
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });
    }
}
}