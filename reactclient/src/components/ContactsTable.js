import React from "react";

export default function ContactsTable(props) {
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
          {props.contacts.map((contact) => (
            <tr key={contact.kontaktId}>
              <th scope="row">{contact.kontaktId}</th>
              <td>{contact.navn}</td>
              <td>{contact.adresse}</td>
              <td>{contact.email}</td>
              <td>{contact.telefon}</td>
              <td>
                <button
                  onClick={() => props.onEdit(contact)}
                  className="btn btn-dark btn-s mx-3 my-3"
                >
                  Edit
                </button>
                <button
                  onClick={() => {
                    if (window.confirm("Are you sure you want to delete the contact?")) {
                      props.onDelete(contact.kontaktId);
                    }
                  }}
                  className="btn btn-secondary btn-s"
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      <button onClick={props.onClear} className="btn btn-dark btn-lg w-100">
        Empty React Contacts array
      </button>
    </div>
  );
}
