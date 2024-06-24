import React from "react";

export default function ContactsTable(props) {
  return (
    <div className="container">
      <div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4">
        {props.contacts.map((contact) => (
          <div key={contact.kontaktId} className="col mb-4">
            <div className="card">
              <div className="card-header">
                Contact ID: {contact.kontaktId}
              </div>
              <div className="card-body">
                <h5 className="card-title">{contact.navn}</h5>
                <p className="card-text"><strong>Address:</strong> {contact.adresse}</p>
                <p className="card-text"><strong>Email:</strong> {contact.email}</p>
                <p className="card-text"><strong>Phone:</strong> {contact.telefon}</p>
                <div className="btn-group" role="group">
                  <button
                    onClick={() => props.onEdit(contact)}
                    className="btn btn-dark"
                  >
                    Edit
                  </button>
                  <button
                    onClick={() => {
                      if (window.confirm("Are you sure you want to delete the contact?")) {
                        props.onDelete(contact.kontaktId);
                      }
                    }}
                    className="btn btn-secondary"
                  >
                    Delete
                  </button>
                </div>
              </div>
            </div>
          </div>
        ))}
      </div>

      {props.contacts.length === 0 && (
        <div className="alert alert-info mt-3" role="alert">
          No contacts available.
        </div>
      )}

      <button onClick={props.onClear} className="btn btn-dark btn-lg w-100 mt-3 mb-4">
        Empty React Contacts array
      </button>
    </div>
  );
}
