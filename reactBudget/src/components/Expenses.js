import React, { useState } from "react";
import Constants from "../utilities/Constants";
import ExpenseCreateForm from "./ExpensesCreateForm";
import ExpenseUpdateForm from "./ExpensesUpdateForm"
import moment from "moment";

export default function Expenses() {
    const [expenses, setExpenses] = useState([]);
    const [showCreateExpenseForm, setShowCreateExpenseForm] = useState(false);
    const [showUpdateExpenseForm, setShowUpdateExpenseForm] = useState(null);

    function getExpenses() {
        const url = Constants.API_URL_GET_ALL_Expenses;

        fetch(url, {
            method: "GET",
        })
            .then((response) => response.json())
            .then((expensesFromServer) => {
                console.log(expensesFromServer);
                setExpenses(expensesFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });
    }

    return (
        <div>
            
            <button
                onClick={getExpenses}
                className="btn btn-dark btn-lg w-100"
            >
                Get Expenses
            </button>

            <button
                onClick={() => setShowCreateExpenseForm(true)}
                className="btn btn-secondary btn-lg w-100 mt-4"
            >
                Create new Expense
            </button>
            {
                expenses.length > 0 &&
                showCreateExpenseForm === false &&
                showUpdateExpenseForm === null &&
                renderExpensesTable()
            }

            {
                showCreateExpenseForm && (
                    <ExpenseCreateForm onExpenseCreated={onExpenseCreated} />
                )
            }

            {
                showUpdateExpenseForm && (
                    <ExpenseUpdateForm
                        Expense={showUpdateExpenseForm}
                        onExpenseUpdated={onExpenseUpdated}
                    />
                )
            }
        </div>
    )

    function renderExpensesTable() {
        return (
            <div>
                {showCreateExpenseForm === false && showUpdateExpenseForm === null && (
                    <div className="table-responsive mt-5">
                        <table className="table table-bordered border-dark">
                            <thead>
                                <tr>
                                    <th scope="col">ExpenseId (PK)</th>
                                    <th scope="col">Date</th>
                                    <th scope="col">Name</th>
                                    <th scope="col">Value</th>
                                    <th scope="col">CRUD</th>
                                </tr>
                            </thead>
                            <tbody>
                                {expenses.map((expense) => (

                                    <tr key={expense.id}>
                                        <th scope="row">{expense.id}</th>
                                        <td>{moment(expense.date).format("DD/MM/yyyy")}</td>
                                        <td>{expense.name}</td>
                                        <td>{expense.value}</td>
                                        <td>
                                            <button
                                                onClick={() => setShowUpdateExpenseForm(expense)}
                                                className="btn btn-dark btn-lg mx-3 my-3"
                                            >
                                                Update
                                            </button>
                                            <button
                                                onClick={() => setDelete(expense.id)}
                                                className="btn btn-secondary btn-lg">Delete</button>
                                        </td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>

                        <button
                            onClick={() => setExpenses([])}
                            className="btn btn-dark btn-lg w-100"
                        >
                            Empty Array
                        </button>
                    </div>
                )}
            </div>
        )
    }

    function onExpenseCreated(createdExpense) {
        setShowCreateExpenseForm(false);

        if (createdExpense === null) {
            return;
        } else {
            console.log(`Expense created!: "${createdExpense.name}"`);
        }

        setTimeout(() => {
            getExpenses();
        }, 100);
    }

    function onExpenseUpdated() {
        setShowUpdateExpenseForm(null);
        setTimeout(() => {
            getExpenses();
        }, 100);
    }

    function setDelete(ExpenseId) {
        const url = `${Constants.API_URL_DELERE_Expense_BY_ID}/${ExpenseId}`;

        if (window.confirm("Are you sure you want to delete this Expense?")) {
            fetch(url, {
                method: "Delete",
            })
                .then((response) => response.json())
                .then((reponseFromServer) => {
                    console.log(reponseFromServer);
                    getExpenses();
                })
                .catch((error) => {
                    console.log(error);
                    alert(error);
                });
        }
    }
}