import React from "react";
import { Routes, Route } from "react-router-dom";
import Expenses from "./components/Expenses";
import Income from "./components/Income";
import NavBar from "./components/NavBar";

export default function App() {

	return (
		<div className="container">
			<div className="row min-vh-100">
				<div className="col d-flex flex-column justify-content-center align-items-center">
						<div>
							<h1>ASP.NET + React</h1>
							<Routes>
								<Route path="/" element={<NavBar/>} />
								<Route path="/expenses" element={<Expenses/>} />
								<Route path="/income" element={<Income/>} />
							</Routes>
						</div>
				</div>
			</div>
		</div>
	);

}