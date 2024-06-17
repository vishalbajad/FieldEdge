import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import '../css/CustomerList.css'; // Import CSS for styling

const CustomerList = () => {
    const [customers, setCustomers] = useState([]);

    useEffect(() => {
        fetchCustomers();
    }, []);

    const navigate = useNavigate();
    const [currentPage, setCurrentPage] = useState(1);
    const [customersPerPage] = useState(5); // Number of customers per page

    // Logic for pagination
    const indexOfLastCustomer = currentPage * customersPerPage;
    const indexOfFirstCustomer = indexOfLastCustomer - customersPerPage;
    const currentCustomers = customers.slice(indexOfFirstCustomer, indexOfLastCustomer);
  
    // Change page
    const paginate = (pageNumber) => setCurrentPage(pageNumber);



    const fetchCustomers = async () => {
        try {
            await axios.get('https://localhost:7190/api/Customers')
                .then(response => {
                    if (Array.isArray(response.data)) {
                        console.log(response.data); // Log the response data
                        setCustomers(response.data);
                    } else {
                        // Handle other cases, such as response.data being null or an object
                        console.error('Unexpected data structure:', response.data);
                    }
                })
                .catch(error => {
                    console.error('Error fetching customers:', error);
                });
        } catch (error) {
            console.error('Error fetching customers:', error);
        }
    };

    const handleEdit = async (userId) => {
        const queryParams = { customerid: userId };
        navigate(`/add-edit-customer?${new URLSearchParams(queryParams).toString()}`);
    };

    const confirmDelete = async (userId) => {
        if (window.confirm(`Are you sure you want to delete user with ID ${userId}?`)) {
            try {
                await axios.delete(`https://localhost:7190/api/Customer/${userId}`);
                alert(`User with ID ${userId} deleted successfully`);
                window.location.reload();
            } catch (error) {
                console.error(`Error deleting user with ID ${userId}:`, error.response ? error.response.data : error.message);
            }
        }
    };


    const handleAddCustomer = () => {
        navigate('/add-edit-customer');
    };
    const tableHeader = {
        padding: '10px',
        textAlign: 'left',
        borderBottom: '1px solid #ddd',
        backgroundColor: '#f2f2f2',
    };

    const tableCell = {
        padding: '10px',
        textAlign: 'left',
    };

    const buttonStyle = {
        padding: '8px 16px',
        backgroundColor: '#007bff',
        color: '#fff',
        border: 'none',
        borderRadius: '4px',
        cursor: 'pointer',
        boxShadow: '0 2px 4px rgba(0, 0, 0, 0.1)',
    };


    return (
        <div style={{ width: '100%', margin: '5%', fontFamily: 'Arial, sans-serif' }}>
            <h1 style={{ marginBottom: '20px' }}>Customer List</h1>
            <table style={{ width: '100%', borderCollapse: 'collapse', boxShadow: '0 0 10px rgba(0, 0, 0, 0.1)', borderRadius: '8px' }}>
                <thead>
                    <tr style={{ backgroundColor: '#f2f2f2', borderBottom: '2px solid #ddd' }}>
                        <th style={tableHeader}>Customer ID</th>
                        <th style={tableHeader}>First Name</th>
                        <th style={tableHeader}>Last Name</th>
                        <th style={tableHeader}>Email</th>
                        <th style={tableHeader}>Phone Number</th>
                        <th style={tableHeader}>Country Code</th>
                        <th style={tableHeader}>Gender</th>
                        <th style={tableHeader}>Balance</th>
                        <th style={tableHeader}>Edit</th>
                        <th style={tableHeader}>Delete</th>
                    </tr>
                </thead>
                <tbody>
                    {customers.map((customer) => (
                        <tr key={customer.id} style={{ borderBottom: '1px solid #ddd' }}>
                            <td style={tableCell}>{customer.id}</td>
                            <td style={tableCell}>{customer.firstname}</td>
                            <td style={tableCell}>{customer.lastname}</td>
                            <td style={tableCell}><a href={`mailto:${customer.email}`}>{customer.email}</a></td>
                            <td style={tableCell}>{customer.phoneNumber}</td>
                            <td style={tableCell}>{customer.countryCode}</td>
                            <td style={tableCell}>{customer.gender}</td>
                            <td style={tableCell}>${parseFloat(customer.balance).toFixed(2)}</td>
                            <td style={tableCell}>
                                <button style={buttonStyle} onClick={() => handleEdit(customer.id)}> Edit </button>
                            </td>
                            <td style={tableCell}>
                                <button style={buttonStyle} onClick={() => confirmDelete(customer.id)}> Delete </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <div className="pagination">
                <button onClick={() => paginate(currentPage - 1)} disabled={currentPage === 1}>Previous</button>
                <button onClick={() => paginate(currentPage + 1)} disabled={indexOfLastCustomer >= customers.length}>Next</button>
            </div>

            <br />
            <button onClick={handleAddCustomer} style={buttonStyle}>Add Customer</button>
        </div>
    );
};

export default CustomerList;
