**Customer Management API with .NET Core and React**

This project showcases a Customer Management API built using .NET Core for backend operations and React for the frontend interface. It utilizes AutoMapper for mapping between DTOs (Data Transfer Objects) and domain models to maintain a clear separation of concerns. also it contain the Rate Limiting , JWT Token 

**Overview**

The CustomerController in this project provides RESTful endpoints for performing CRUD operations on customer data. The API interacts with a database using Entity Framework Core for ORM operations and integrates AutoMapper for seamless object mapping between DTOs and domain entities.

**Technologies Used**
ASP.NET Core: Framework for building robust and scalable APIs using C#

Entity Framework Core: ORM (Object-Relational Mapping) for database interactions

AutoMapper: Library for object-to-object mapping, simplifying DTO transformations

React: JavaScript library for building user interfaces

Microsoft.Extensions.Logging: Logging framework for capturing runtime information

Swagger: API documentation and testing tool for interactive API exploration

**Controller Details**

CustomerController

The CustomerController exposes endpoints for managing customer data:

GET /api/Customers: Retrieves all customers from the database.

GET /api/Customer/{id}: Retrieves a specific customer by their ID.

POST /api/Customer: Adds a new customer to the database.

POST /api/Customer/{id}: Updates an existing customer in the database.

DELETE /api/Customer/{id}: Deletes a customer from the database based on their ID

Screenshot : 
![image](https://github.com/vishalbajad/FieldEdge/assets/14272268/fe409896-556d-4240-b4f2-056c1b0251fe)

![image](https://github.com/vishalbajad/FieldEdge/assets/14272268/3ceabd24-24bd-4735-bb47-b526be04ccd9)

![image](https://github.com/vishalbajad/FieldEdge/assets/14272268/d45cb56b-1cb5-45d3-8109-83e2d227521e)




