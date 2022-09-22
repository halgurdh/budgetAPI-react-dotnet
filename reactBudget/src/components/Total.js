import React, { useState } from "react";
import Constants from "../utilities/Constants";
import moment from "moment";

export default function Total() {
  const [Total, setTotal] = useState([]);

  function getTotal() {
    const url = Constants.API_URL_GET_ALL_total;

    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((totalFromServer) => {
        console.log(totalFromServer);
        setTotal(totalFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  function calculateTotalByMonth() {}

  return (
    <div>
      <button onClick={getTotal} className="btn btn-dark btn-lg w-100">
        Get total
      </button>

      {Total.length > 0 && rendertotalTable()}
    </div>
  );

  function rendertotalTable() {
    return (
      <div>
        <div className="table-responsive mt-5">
          <table className="table table-bordered border-dark">
            <thead>
              <tr>
                <th scope="col">TotalId (PK)</th>
                <th scope="col">Date</th>
                <th scope="col">Name</th>
                <th scope="col">Value</th>
                <th scope="col">CRUD</th>
              </tr>
            </thead>
            <tbody>
              {Total.map((total) => (
                <tr key={total.id}>
                  <th scope="row">{total.id}</th>
                  <td>{moment(total.date).format("DD/MM/yyyy")}</td>
                  <td>{total.name}</td>
                  <td>{total.value}</td>
                </tr>
              ))}
            </tbody>
          </table>

          <button
            onClick={() => setTotal([])}
            className="btn btn-dark btn-lg w-100"
          >
            Empty Array
          </button>
        </div>
      </div>
    );
  }
}
