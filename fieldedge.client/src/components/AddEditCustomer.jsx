// AddCustomer.js

import React, { useState } from 'react';
import './AddCustomer.css'; // Import the CSS file for styling
import { useNavigate } from 'react-router-dom';

const AddCustomer = () => {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        id: 40,
        salutation: 'Ms.',
        initials: 'V.',
        firstname: 'Velma',
        firstnameAscii: '',
        gender: 'f',
        firstnameCountryRank: '',
        firstnameCountryFrequency: '',
        lastname: 'Foltz',
        lastnameAscii: '',
        lastnameCountryRank: '',
        lastnameCountryFrequency: '',
        email: 'velma.foltz@protonmail.com',
        password: 'VF90-qECkzw|',
        countryCode: '',
        countryCodeAlpha: '',
        countryName: '',
        primaryLanguageCode: '',
        primaryLanguage: '',
        balance: 742.13,
        phoneNumber: '',
        currency: 'USD'
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(formData); // For demonstration, log form data
        // Add logic to save data (e.g., send to API)
        // Reset form after submission
        setFormData({
            id: '',
            salutation: '',
            initials: '',
            firstname: '',
            firstnameAscii: '',
            gender: '',
            firstnameCountryRank: '',
            firstnameCountryFrequency: '',
            lastname: '',
            lastnameAscii: '',
            lastnameCountryRank: '',
            lastnameCountryFrequency: '',
            email: '',
            password: '',
            countryCode: '',
            countryCodeAlpha: '',
            countryName: '',
            primaryLanguageCode: '',
            primaryLanguage: '',
            balance: '',
            phoneNumber: '',
            currency: ''
        });
    };

    return (
        <div className="add-customer-container">
            <h1>Add Customer</h1>
            <form className="add-customer-form" onSubmit={handleSubmit}>
                <div className="form-group">
                    <label htmlFor="firstname">First Name:</label>
                    <input type="text" id="firstname" name="firstname" value={formData.firstname} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label htmlFor="lastname">Last Name:</label>
                    <input type="text" id="lastname" name="lastname" value={formData.lastname} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label htmlFor="email">Email:</label>
                    <input type="email" id="email" name="email" value={formData.email} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password:</label>
                    <input type="password" id="password" name="password" value={formData.password} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label htmlFor="balance">Balance:</label>
                    <input type="text" id="balance" name="balance" value={formData.balance} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label htmlFor="gender">Gender:</label>
                    <select id="gender" name="gender" value={formData.gender} onChange={handleChange}>
                        <option value="m">Male</option>
                        <option value="f">Female</option>
                        <option value="o">Other</option>
                    </select>
                </div>
                <button type="submit">Save Customer</button> &nbsp; <button onClick={navigate("/")}>Cancel</button>
            </form>
        </div>
    );
};

export default AddCustomer;
