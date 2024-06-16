import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import CustomerList from './components/CustomerList';
import AddEditCustomer from './components/AddEditCustomer';
const App = () => {
    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route exact path="/" element={<CustomerList/>} />
                    <Route path="/add-edit-customer" element={<AddEditCustomer/>} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;
