import React, { useState } from "react";
import Constants from "./utilities/Constants";
import CreateContact from "./components/CreateContact";
import UpdateContact from "./components/UpdateContact";
import ContactsTable from "./components/ContactsTable";

export default function App() {
  const [contacts, setContacts] = useState([]);
  const [showingContactForm, setShowingContactForm] = useState(false);
  const [updatingContact, setUpdatingContact] = useState(null);

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

  function handleEdit(contact) {
    setUpdatingContact(contact);
  }

  function handleDelete(contactId) {
    const url = `${Constants.API_URL_DELETE_CONTACT_BY_ID}/${contactId}`;

    fetch(url, {
      method: "DELETE",
    })
      .then(() => {
        setContacts(contacts.filter(contact => contact.kontaktId !== contactId));
        alert("Contact successfully deleted.");
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  function handleClear() {
    setContacts([]);
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {showingContactForm === false && updatingContact === null && (
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
            updatingContact === null && (
              <ContactsTable
                contacts={contacts}
                onEdit={handleEdit}
                onDelete={handleDelete}
                onClear={handleClear}
              />
            )}

          {showingContactForm && (
            <CreateContact onContactCreated={onContactCreated} />
          )}

          {updatingContact !== null && (
            <UpdateContact
              contact={updatingContact}
              onContactUpdated={onContactUpdated}
            />
          )}
        </div>
      </div>
    </div>
  );

  function onContactCreated(createdContact) {
    setShowingContactForm(false);
    if (createdContact === null) {
      return;
    }
    alert(`"${createdContact.navn}" Contact successfully created.`);

    getContacts();
  }

  function onContactUpdated(updatedContact) {
    setUpdatingContact(null);
    if (updatedContact === null) {
      return;
    }

    let contactsCopy = [...contacts];
    const index = contactsCopy.findIndex(
      (contact) => contact.kontaktId === updatedContact.kontaktId
    );

    if (index !== -1) {
      contactsCopy[index] = updatedContact;
    }

    setContacts(contactsCopy);
    alert("Contact successfully updated.");
  }
}
