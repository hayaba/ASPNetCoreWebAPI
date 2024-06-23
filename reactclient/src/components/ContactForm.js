import React, { useState } from "react";
import Constants from "../utilities/Constants";

export default function ContactForm(props) {
  const [formData, setFormData] = useState(initialFormData);

  const initialFormData = Object.freeze({
    navn: "Your Name",
    adresse: "Your addresse",
    email: "Email@example.com",
    telefon: "Phone Number",
  });

  function handleChange(e) {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  }

  function handleSubmit(e) {
    e.preventDefault();

    const createContact = {
      kontaktId: 0,
      navn: formData.navn,
      adresse: formData.adresse,
      email: formData.email,
      telefon: formData.telefon,
    };

    const url = Constants.APPI_URL_CREATE_CONTACT;

    fetch(url, {
      method: "post",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(createContact),
    })
      .then((Response) => Response.json())
      .then((responsFromServer) => {
        console.log(responsFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });

    props.onContactCreated(createContact);
  }

  return (
    <div>
      <from className="w-100 px-5">
        <h1 className="mt-5">Create new contact</h1>

        <div className="mt-5">
          <label className="h3 form-label">Name</label>
          <input
            value={formData.navn}
            name="navn"
            type="text"
            className="form-control"
            onChange={handleChange}
          />
        </div>

        <div className="mt-5">
          <label className="h3 form-label">Address</label>
          <input
            value={formData.adresse}
            name="adresse"
            type="text"
            className="form-control"
            onChange={handleChange}
          />
        </div>

        <div className="mt-5">
          <label className="h3 form-label">Email Address</label>
          <input
            value={formData.email}
            name="email"
            type="text"
            className="form-control"
            onChange={handleChange}
          />
        </div>

        <div className="mt-5">
          <label className="h3 form-label">Phone Number</label>
          <input
            value={formData.telefon}
            name="telefon"
            type="text"
            className="form-control"
            onChange={handleChange}
          />
        </div>

        <button
          onClick={handleSubmit}
          className="btn btn-dark btn-lg w-100 mt-5"
        >
          Submit
        </button>
        <button
          onClick={() => props.onContactCreated(null)}
          className="btn btn-secondary btn-lg w-100 mt-3"
        >
          Cancel
        </button>
      </from>
    </div>
  );
}
