import Constants from "../utilities/Constants";

export default function UpdateTotal(totalToUpdate) {
  const url = Constants.API_URL_UPDATE_Total;

  fetch(url, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(totalToUpdate),
  })
    .then((response) => response.json())
    .then((responseFromServer) => {
      console.log(responseFromServer);
    })
    .catch((error) => {
      console.log(error);
      alert(error);
    });
}