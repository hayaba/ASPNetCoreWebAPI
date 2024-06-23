import React, { useState } from "react";

export default function App() {
  const [contacts, setContacts] = useState([]);
  function getContacts() {
    const url = "https://localhost:7005/get-all-kontaktPersoner";

    fetch(url, {
      method: "GET",
    }).then(Response => Response.json())
    .then(contactsFromServer => {
      console.log(contactsFromServer);
      setContacts(contactsFromServer);
    })
    .catch((error) => {
      console.log(error);
      alert(error);
    });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div>
          <h1>ASP.NET Core Web API || Contacts List</h1>
          <div className="mt-5">
            <button onClick={getContacts} className="btn btn-dark btn-lg w-100">Get Contacts from server</button>
            <button onClick={() => {}} className="btn btn-secondary btn-lg w-100 mt-4">Add New Contact</button>
          </div>
          </div>

          {renderContactsTable()}
        </div>
      </div>
    </div>
  );

  function renderContactsTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">ContactId</th>
              <th scope="col">Name</th>
              <th scope="col">Adresse</th>
              <th scope="col">Email</th>
              <th scope="col">Phone</th>
              <th scope="col">CRUD Operation</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <th scope="row">1</th>
              <td>haya</td>
              <td>Aarhus</td>
              <td>email address</td>
              <td>12345678</td>
              <td>
                <button className="btn btn-dark btn-s mx-3 my-3">Edit</button>
                <button className="btn btn-secondary btn-s">Delete</button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    );
  }
}
