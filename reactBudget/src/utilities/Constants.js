const API_URL_DEV = "http://localhost:5184";
const API_URL_PROD = "https://appname.azure.net";

const ENDPOINTS_Expenses = {
  GET_All_Expenses: "getAllExpenses",
  GET_Expense_BY_ID: "getExpensesById",
  GET_Monthly_Expense: "getMonthlyExpenses",
  CREATE_Expense: "createExpense",
  UPDATE_Expense: "updateExpense",
  DELETE_Expense_BY_ID: "deleteExpenseById",
};

const ENDPOINTS_Income = {
  GET_All_Income: "getAllIncome",
  GET_Income_BY_ID: "getIncomeById",
  GET_Monthly_Income: "getMonthlyIncome",
  CREATE_Income: "createIncome",
  UPDATE_Income: "updateIncome",
  DELETE_Income_BY_ID: "deleteIncomeById",
};

const ENDPOINTS_Total = {
  GET_All_Total: "getAllTotal",
  GET_Total_BY_ID: "getTotalById",
  GET_Monthly_Total: "getMonthlyTotal",
  CREATE_Total: "createTotal",
  UPDATE_Total: "updateTotal",
  DELETE_Total_BY_ID: "deleteTotalById",
};

const development = {
  API_URL_GET_ALL_Expenses: `${API_URL_DEV}/${ENDPOINTS_Expenses.GET_All_Expenses}`,
  API_URL_GET_Expense_BY_ID: `${API_URL_DEV}/${ENDPOINTS_Expenses.GET_Expense_BY_ID}`,
  API_URL_GET_Montly_Expense: `${API_URL_DEV}/${ENDPOINTS_Expenses.GET_Monthly_Expense}`,
  API_URL_CREATE_Expense: `${API_URL_DEV}/${ENDPOINTS_Expenses.CREATE_Expense}`,
  API_URL_UPDATE_Expense: `${API_URL_DEV}/${ENDPOINTS_Expenses.UPDATE_Expense}`,
  API_URL_DELERE_Expense_BY_ID: `${API_URL_DEV}/${ENDPOINTS_Expenses.DELETE_Expense_BY_ID}`,

  API_URL_GET_ALL_Income: `${API_URL_DEV}/${ENDPOINTS_Income.GET_All_Income}`,
  API_URL_GET_Income_BY_ID: `${API_URL_DEV}/${ENDPOINTS_Income.GET_Income_BY_ID}`,
  API_URL_GET_Montly_Income: `${API_URL_DEV}/${ENDPOINTS_Expenses.GET_Monthly_Income}`,
  API_URL_CREATE_Income: `${API_URL_DEV}/${ENDPOINTS_Income.CREATE_Income}`,
  API_URL_UPDATE_Income: `${API_URL_DEV}/${ENDPOINTS_Income.UPDATE_Income}`,
  API_URL_DELERE_Income_BY_ID: `${API_URL_DEV}/${ENDPOINTS_Income.DELETE_Expense_BY_ID}`,

  API_URL_GET_ALL_Total: `${API_URL_DEV}/${ENDPOINTS_Total.GET_All_Total}`,
  API_URL_GET_Total_BY_ID: `${API_URL_DEV}/${ENDPOINTS_Total.GET_Total_BY_ID}`,
  API_URL_GET_Montly_Total: `${API_URL_DEV}/${ENDPOINTS_Total.GET_Monthly_Total}`,
  API_URL_CREATE_Total: `${API_URL_DEV}/${ENDPOINTS_Total.CREATE_Total}`,
  API_URL_UPDATE_Total: `${API_URL_DEV}/${ENDPOINTS_Total.UPDATE_Total}`,
  API_URL_DELERE_Total_BY_ID: `${API_URL_DEV}/${ENDPOINTS_Total.DELETE_Total_BY_ID}`,
};

const production = {
  API_URL_GET_ALL_Expenses: `${API_URL_PROD}/${ENDPOINTS_Expenses.GET_ALL_Expenses}`,
  API_URL_GET_Expense_BY_ID: `${API_URL_PROD}/${ENDPOINTS_Expenses.GET_Expense_BY_ID}`,
  API_URL_GET_Montly_Expense: `${API_URL_PROD}/${ENDPOINTS_Expenses.GET_Monthly_Expense}`,
  API_URL_CREATE_Expense: `${API_URL_PROD}/${ENDPOINTS_Expenses.CREATE_Expense}`,
  API_URL_UPDATE_Expense: `${API_URL_PROD}/${ENDPOINTS_Expenses.UPDATE_Expense}`,
  API_URL_DELERE_Expense_BY_ID: `${API_URL_PROD}/${ENDPOINTS_Expenses.DELETE_Expense_BY_ID}`,

  API_URL_GET_ALL_Income: `${API_URL_PROD}/${ENDPOINTS_Income.GET_All_Income}`,
  API_URL_GET_Income_BY_ID: `${API_URL_PROD}/${ENDPOINTS_Income.GET_Income_BY_ID}`,
  API_URL_GET_Montly_Income: `${API_URL_PROD}/${ENDPOINTS_Income.GET_Monthly_Income}`,
  API_URL_CREATE_Income: `${API_URL_PROD}/${ENDPOINTS_Income.CREATE_Income}`,
  API_URL_UPDATE_Income: `${API_URL_PROD}/${ENDPOINTS_Income.UPDATE_Income}`,
  API_URL_DELERE_Income_BY_ID: `${API_URL_PROD}/${ENDPOINTS_Income.DELETE_Expense_BY_ID}`,

  API_URL_GET_ALL_Total: `${API_URL_PROD}/${ENDPOINTS_Total.GET_All_Total}`,
  API_URL_GET_Total_BY_ID: `${API_URL_PROD}/${ENDPOINTS_Total.GET_Total_BY_ID}`,
  API_URL_GET_Montly_Total: `${API_URL_PROD}/${ENDPOINTS_Total.GET_Monthly_Total}`,
  API_URL_CREATE_Total: `${API_URL_PROD}/${ENDPOINTS_Total.CREATE_Total}`,
  API_URL_UPDATE_Total: `${API_URL_PROD}/${ENDPOINTS_Total.UPDATE_Total}`,
  API_URL_DELERE_Total_BY_ID: `${API_URL_PROD}/${ENDPOINTS_Total.DELETE_Total_BY_ID}`,
};

const Constants =
  process.env.NODE_ENV === "development" ? development : production;

export default Constants;
