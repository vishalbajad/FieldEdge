import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css'; // Import Bootstrap CSS
//import '../css/CustomerList.css'; // Custom CSS for additional styling if needed

const CustomerList = () => {
    const [customers, setCustomers] = useState([]);
    const navigate = useNavigate();
    const [currentPage, setCurrentPage] = useState(1);
    const customersPerPage = 5; // Number of customers per page

    // Fetch customers on component mount
    useEffect(() => {
        fetchCustomers();
    }, []);

    // Fetch customers from API
    const fetchCustomers = async () => {
        try {
            const response = await axios.get('https://localhost:7190/api/Customers');
            if (Array.isArray(response.data)) {
                console.log(response.data); // Log the response data
                setCustomers(response.data);
            } else {
                console.error('Unexpected data structure:', response.data);
            }
        } catch (error) {
            console.error('Error fetching customers:', error);
        }
    };

    // Handle navigation to edit customer page
    const handleEdit = (customerId) => {
        navigate(`/add-edit-customer?customerid=${customerId}`);
    };

    // Confirm and delete customer
    const confirmDelete = async (customerId) => {
        if (window.confirm(`Are you sure you want to delete user with ID ${customerId}?`)) {
            try {
                await axios.delete(`https://localhost:7190/api/Customer/${customerId}`);
                alert(`User with ID ${customerId} deleted successfully`);
                fetchCustomers(); // Refresh customer list after deletion
            } catch (error) {
                console.error(`Error deleting user with ID ${customerId}:`, error.response ? error.response.data : error.message);
            }
        }
    };

    // Pagination logic
    const indexOfLastCustomer = currentPage * customersPerPage;
    const indexOfFirstCustomer = indexOfLastCustomer - customersPerPage;
    const currentCustomers = customers.slice(indexOfFirstCustomer, indexOfLastCustomer);

    // Change page
    const paginate = (pageNumber) => setCurrentPage(pageNumber);

    return (
        <div className="container mt-5">
            <button className="btn btn-success btn-lg float-end" onClick={() => navigate('/add-edit-customer')}>Add Customer</button>
            <h1>Customer List</h1> 
            <table className="table table-bordered mt-3">
                <thead className="thead-dark">
                    <tr>
                        <th>Customer ID</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Email</th>
                        <th>Phone Number</th>
                        <th>Country Code</th>
                        <th>Gender</th>
                        <th>Balance</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                </thead>
                <tbody>
                    {currentCustomers.map((customer) => (
                        <tr key={customer.id}>
                            <td>{customer.id}</td>
                            <td>{customer.firstname}</td>
                            <td>{customer.lastname}</td>
                            <td><a href={`mailto:${customer.email}`}>{customer.email}</a></td>
                            <td>{customer.phoneNumber}</td>
                            <td>{customer.countryCode}</td>
                            <td>{customer.gender}</td>
                            <td>${parseFloat(customer.balance).toFixed(2)}</td>
                            <td>
                                <button className="btn btn-primary" onClick={() => handleEdit(customer.id)}>Edit</button>
                            </td>
                            <td>
                                <button className="btn btn-danger" onClick={() => confirmDelete(customer.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <div className="pagination">
                <button className="btn btn-primary" onClick={() => paginate(currentPage - 1)} disabled={currentPage === 1}>Previous</button> &nbsp;
                <button className="btn btn-primary" onClick={() => paginate(currentPage + 1)} disabled={indexOfLastCustomer >= customers.length}>Next</button>
            </div>
        </div>
    );
};

export default CustomerList;
