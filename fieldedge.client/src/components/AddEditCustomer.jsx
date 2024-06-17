import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useNavigate, useLocation } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

const AddCustomer = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const queryParams = new URLSearchParams(location.search);
    const customerid = queryParams.get('customerid');
    const title = customerid > 0 ? 'Update' : 'Create';

    const [formData, setFormData] = useState({
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

    useEffect(() => {
        if (customerid > 0) {
            getCustomer(customerid);
        }
    }, [customerid]);

    const getCustomer = async (id) => {
        try {
            const response = await axios.get(`https://localhost:7190/api/Customer/${id}`);
            setFormData(response.data);
        } catch (error) {
            console.error('Error fetching customer:', error);
        }
    };

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleHomePage = () => {
        navigate('/');
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        const url = `https://localhost:7190/api/Customer${customerid > 0 ? `/${customerid}` : ''}`;

        try {
            if (window.confirm(`Are you sure you want to ${title} the customer details?`)) {
                const response = await axios.post(url, formData);
                console.log('Post success:', response.data);
                alert(`User ${title} successfully!`);
                handleHomePage();
            }
        } catch (error) {
            console.error(`Error ${title.toLowerCase()} customer:`, error.response ? error.response.data : error.message);
            alert(`Error ${title.toLowerCase()} customer. Please try again.`);
        }
    };

    return (
        <div className="container mt-5">
            <h2>{`${title} Customer Details`}</h2>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label>ID:</label>
                    <input type="text" className="form-control" name="id" value={formData.id} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Salutation:</label>
                    <input type="text" className="form-control" name="salutation" value={formData.salutation} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Initials:</label>
                    <input type="text" className="form-control" name="initials" value={formData.initials} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>First Name:</label>
                    <input type="text" className="form-control" name="firstname" value={formData.firstname} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label>First Name ASCII:</label>
                    <input type="text" className="form-control" name="firstnameAscii" value={formData.firstnameAscii} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Gender:</label>
                    <input type="text" className="form-control" name="gender" value={formData.gender} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>First Name Country Rank:</label>
                    <input type="text" className="form-control" name="firstnameCountryRank" value={formData.firstnameCountryRank} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>First Name Country Frequency:</label>
                    <input type="text" className="form-control" name="firstnameCountryFrequency" value={formData.firstnameCountryFrequency} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Last Name:</label>
                    <input type="text" className="form-control" name="lastname" value={formData.lastname} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label>Last Name ASCII:</label>
                    <input type="text" className="form-control" name="lastnameAscii" value={formData.lastnameAscii} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Last Name Country Rank:</label>
                    <input type="text" className="form-control" name="lastnameCountryRank" value={formData.lastnameCountryRank} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Last Name Country Frequency:</label>
                    <input type="text" className="form-control" name="lastnameCountryFrequency" value={formData.lastnameCountryFrequency} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Email:</label>
                    <input type="email" className="form-control" name="email" value={formData.email} onChange={handleChange} required />
                </div>
                <div className="form-group">
                    <label>Password:</label>
                    <input type="password" className="form-control" name="password" value={formData.password} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Country Code:</label>
                    <input type="text" className="form-control" name="countryCode" value={formData.countryCode} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Country Code Alpha:</label>
                    <input type="text" className="form-control" name="countryCodeAlpha" value={formData.countryCodeAlpha} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Country Name:</label>
                    <input type="text" className="form-control" name="countryName" value={formData.countryName} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Primary Language Code:</label>
                    <input type="text" className="form-control" name="primaryLanguageCode" value={formData.primaryLanguageCode} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Primary Language:</label>
                    <input type="text" className="form-control" name="primaryLanguage" value={formData.primaryLanguage} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Balance:</label>
                    <input type="text" className="form-control" name="balance" value={formData.balance} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Phone Number:</label>
                    <input type="text" className="form-control" name="phoneNumber" value={formData.phoneNumber} onChange={handleChange} />
                </div>
                <div className="form-group">
                    <label>Currency:</label>
                    <input type="text" className="form-control" name="currency" value={formData.currency} onChange={handleChange} />
                </div>
                <button type="submit" className="btn btn-primary">Save</button> &nbsp;
                <button type="button" className="btn btn-secondary" onClick={handleHomePage}>Cancel</button>
            </form>
        </div>
    );
};

export default AddCustomer;
