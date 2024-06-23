import React, {useState} from 'react'
import Constants from '../utilities/Constants'

export default function ContactForm() {
  return (
    <div>
      <from className="w-100 px-5">
        <h1 className='mt-5'>Create new contact</h1>

        <div className='mt-5'>
            <label className='h3 form-label'>Name</label>
            <input value={FormData.navn} name="navn" type='text' className='form-control' onChange={handleChange} />
        </div>

        <div className='mt-5'>
            <label className='h3 form-label'>Address</label>
            <input value={FormData.adresse} name="adresse" type='text' className='form-control' onChange={handleChange} />
        </div>

        <div className='mt-5'>
            <label className='h3 form-label'>Email Address</label>
            <input value={FormData.email} name="email" type='text' className='form-control' onChange={handleChange} />
        </div>

        <div className='mt-5'>
            <label className='h3 form-label'>Phone Number</label>
            <input value={FormData.telefon} name="telefon" type='text' className='form-control' onChange={handleChange} />
        </div>

        <button onClick={handleSubmit} className='btn btn-dark btn-lg w-100 mt-5'>Submit</button>
        <button onClick={() => props.onContactCreated(null)} className='btn btn-secondary btn-lg w-100 mt-3'>Cancel</button>
      </from>
    </div>
  );
}
