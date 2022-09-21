import { BrowserRouter as Router } from "react-router-dom";
import ReactDOM from 'react-dom'
import React from "react"
import App from "./App"
import 'bootstrap/dist/css/bootstrap.css'


ReactDOM.render(
    <React.StrictMode>
        <Router>
            <App />
        </Router>
    </React.StrictMode>,
    document.getElementById("root")
);