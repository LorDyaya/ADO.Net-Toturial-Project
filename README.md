# ADO.NET Contacts Management Console App

This is a tutorial Console Application built with C# using ADO.NET to perform CRUD Operations on a SQL Server Database.

## Features
- Add New Contact
- Update Contact
- Delete Contact
- Find Contact By ID
- Display All Contacts

---

# Technologies Used
- C#
- ADO.NET
- SQL Server
- 3-Tier Architecture
- Object-Oriented Programming (OOP)

---

# Database
I restored the database from my local device using SQL Server Management System (SSMS).

---

# Project Architecture

The project is built using 3-Tier Architecture.

## 1. Presentation Layer
This layer contains no business logic.

It is only responsible for:
- Calling methods
- Printing results
- Testing features

### Methods
- `testFindContact(int ID)`
- `testAddNewContact()`
- `testUpdateContact(int ID)`
- `testDeleteContact(int ID)`
- `GetAllContacts()`

---

## 2. Business Layer
This is the logical layer of the application.

I created a `Contact` class that contains:
- Contact information using `get` and `set`
- Constructors
- Save functionality

### Features
- Public constructor with default values
- Private constructor with parameters
- `Save()` method for adding and updating data

This layer applies OOP concepts and controls the business logic.

---

## 3. Data Access Layer
This layer is responsible for:
- Connecting to the database
- Executing SQL commands
- Manipulating data using ADO.NET

All database operations are handled here.

---

# Final Notes
This project helped me practice:
- ADO.NET
- CRUD Operations
- SQL Server
- OOP
- 3-Tier Architecture

I hope I explained the project clearly.

## Author
Yehia Hamed

> I wish continued success for everyone 🚀
