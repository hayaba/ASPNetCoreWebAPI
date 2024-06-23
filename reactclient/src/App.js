import React from "react";

export default function App() {
  return (
    <div className="container">
    <div className="row min-vh-100">
      <div className="col d-flex flex-column justify-content-center align-items-center">
        <h1>Hello World</h1>

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
              <button className="btn btn-dark btn-lg mx-3 my-3">Edite</button>
              <button className="btn btn-secondary btn-lg">delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    )
  }
}
