import React from "react";
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from "chart.js";
import { Pie } from "react-chartjs-2";
import Constants from "../utilities/Constants";

ChartJS.register(ArcElement, Tooltip, Legend);

function getExpensesVSIncome() {
  // getExpenses().forEach((expenses) => {
  //   console.log(expenses);
  // });
}

function getIncome() {
  const url = Constants.API_URL_GET_ALL_Income;

  fetch(url, {
    method: "GET",
  })
    .then((response) => response.json())
    .then((IncomeFromServer) => {
      console.log(IncomeFromServer);
      return IncomeFromServer;
    })
    .catch((error) => {
      console.log(error);
      alert(error);
    });
}

function getExpenses() {
  const url = Constants.API_URL_GET_ALL_Expenses;

  fetch(url, {
    method: "GET",
  })
    .then((response) => response.json())
    .then((expensesFromServer) => {
      console.log(expensesFromServer);
      return expensesFromServer;
    })
    .catch((error) => {
      console.log(error);
      alert(error);
    });
}

export const data = {
  labels: ["Expenses", "Income"],
  datasets: [
    {
      label: "Expenses vs Income",
      data: getExpensesVSIncome(),
      backgroundColor: ["rgba(255, 99, 132, 0.2)", "rgba(54, 162, 235, 0.2)"],
      borderColor: ["rgba(255, 99, 132, 1)", "rgba(54, 162, 235, 1)"],
      borderWidth: 1,
    },
  ],
};

export function PieChart() {
  return <Pie data={data} />;
}
