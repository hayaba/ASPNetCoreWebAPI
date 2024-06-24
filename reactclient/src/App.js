import React, { useState } from "react";
import Constants from "./utilities/Constants";
import CreateContact from "./components/CreateContact";

export default function App() {
  const [contacts, setContacts] = useState([]);
  const [showingContactForm, setShowingContactForm] = useState(false);

  function getContacts() {
    const url = Constants.API_URL_GET_ALL_CONTACTS;

    fetch(url, {
      method: "GET",
    })
      .then((Response) => Response.json())
      .then((contactsFromServer) => {
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
          {showingContactForm === false && (
            <div>
              <h1>ASP.NET Core Web API || Contacts List</h1>
              <div className="mt-5">
                <button
                  onClick={getContacts}
                  className="btn btn-dark btn-lg w-100"
                >
                  Get Contacts from server
                </button>
                <button
                  onClick={() => setShowingContactForm(true)}
                  className="btn btn-secondary btn-lg w-100 mt-4"
                >
                  Add New Contact
                </button>
              </div>
            </div>
          )}

          {contacts.length > 0 &&
            showingContactForm === false &&
            renderContactsTable()}

          {showingContactForm && (
            <CreateContact onContactCreated={onContactCreated} />
          )}
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
            {contacts.map((contact) => (
              <tr key={contact.kontaktId}>
                <th scope="row">{contact.kontaktId}</th>
                <td>{contact.navn}</td>
                <td>{contact.adresse}</td>
                <td>{contact.email}</td>
                <td>{contact.telefon}</td>
                <td>
                  <button className="btn btn-dark btn-s mx-3 my-3">Edit</button>
                  <button className="btn btn-secondary btn-s">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <button
          onClick={() => setContacts([])}
          className="btn btn-dark btn-lg w-100"
        >
          Empty React Contacts array
        </button>
      </div>
    );
  }

  function onContactCreated(createdContact) {
    setShowingContactForm(false);
    if (createdContact === null) {
      return;
    }
    alert(`"${createdContact.navn}" Contact successfully created.`);

    getContacts();
  }
}
