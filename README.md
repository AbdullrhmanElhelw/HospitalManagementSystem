# HospitalManagementSystem
 **# Hospital Management System API**

**This API provides a comprehensive set of endpoints for managing hospital data, including patients, relatives, and users.**

**## Key Features**

* **Patient Management:**
    * Create, read, update, and delete patients.
    * Retrieve patients by name or ID.
    * Generate patient reports in various formats.
    * Upload and manage patient profile pictures.
* **Relative Management:**
    * Create, read, update, and delete relatives.
    * Retrieve relatives by name or ID.
    * Manage relative passwords.
* **User Management:**
    * Register and create new users.
    * Login and manage user roles.
    * Retrieve user information.

**## Endpoints**

**### Patient Endpoints**

| HTTP Method | Endpoint               | Description                                      |
|--------------|------------------------|-----------------------------------------------------|
| GET          | /api/Patient/GetPatient | Retrieve a single patient by ID                    |
| POST         | /api/Patient/CreatePatient | Create a new patient                              |
| DELETE       | /api/Patient/DeletePatient | Delete a patient                                   |
| PUT          | /api/Patient/UpdatePatient | Update an existing patient                         |
| GET          | /api/Patient/GetAllPatients | Retrieve a list of all patients                    |
| GET          | /api/Patient/GetPatientByName | Retrieve a patient by name                        |
| POST         | /api/Patient/CreateProfilePicture | Upload a profile picture for a patient            |
| GET          | /api/Patient/GenerateReport | Generate a patient report in a specified format    |
| POST         | /api/Patient/CreateMultiPatients | Create multiple patients in a single request       |
| GET          | /api/Patient/GeneratePdfReport | Generate a patient report in PDF format           |

**### Relative Endpoints**

| HTTP Method | Endpoint               | Description                                      |
|--------------|------------------------|-----------------------------------------------------|
| GET          | /api/Relative/GetRelative | Retrieve a single relative by ID                  |
| GET          | /api/Relative/GetAllRelatives | Retrieve a list of all relatives                  |
| POST         | /api/Relative/CreateRelative | Create a new relative                             |
| GET          | /api/Relative/GetPassword | Retrieve the password for a relative              |
| DELETE       | /api/Relative/DeleteRelative | Delete a relative                                  |
| PUT          | /api/Relative/UpdateRelative | Update an existing relative                       |
| PATCH        | /api/Relative/UpdateRelative | Partially update an existing relative            |
| GET          | /api/Relative/FindRelativeByName | Retrieve a relative by name                       |

**### User Endpoints**

| HTTP Method | Endpoint                 | Description                                      |
|--------------|--------------------------|-----------------------------------------------------|
| POST         | /api/User/Register        | Register a new user                               |
| POST         | /api/User/Login           | Login an existing user                             |
| POST         | /api/User/CreateAdmin      | Create a new admin user                           |
| POST         | /api/User/CreateRole       | Create a new user role                            |
| GET          | /api/User/GetUsers         | Retrieve a list of users                           |
| POST         | /api/User/Upload          | Upload a file (purpose not specified in image)    |
| GET          | /api/User/GetId            | Retrieve a user's ID by username (likely for authentication) |

**## Authentication**

This API uses token-based authentication. To obtain a token, provide a valid username and password in the request body of the `/api/User/Login` endpoint. The returned token must be included in the Authorization header of subsequent requests.

## Tools and Concepts

This project utilizes the following tools and concepts:

- **.Net 8**: The project is developed using the .Net 8 framework, providing a robust and feature-rich development environment.

- **EF-Core For Database Command**: Using EF-Core For Commands Only Like ( Create, Update, Delete ) .
- **Dapper For Database Queries**: Using Dapper for Querying as it a micro ORM and is really fast

- **JWT (JSON Web Tokens)**: JSON Web Tokens are employed for secure and efficient authentication and authorization processes.

- **CQRS With Mediator**: The project adopts the Command Query Responsibility Segregation (CQRS) pattern with Mediator for managing and separating command and query responsibilities, promoting a cleaner and more scalable architecture.

- **UnitOfWork**: Unit of Work pattern is implemented to manage transactions and ensure data consistency across multiple database operations.

- **Repository Pattern**: The repository pattern is utilized for abstracting data access and providing a consistent interface for interacting with the underlying data storage.

- **AutoMapper**: AutoMapper is used for object-to-object mapping, simplifying the process of transforming data between different layers of the application.

- **Built Completely in Clean Architecture**: The project is structured following the Clean Architecture principles, promoting separation of concerns, maintainability, and     testability.

