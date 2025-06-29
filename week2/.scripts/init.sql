-- @block
-- check install version
select @@version;


-- @block
-- check all databases available
SELECT name, database_id, create_date
FROM sys.databases;
GO

-- @block
-- create sample database for this exercise
CREATE DATABASE Product_Management;
GO


-- @block
-- Define Database Schema
USE Product_Management;

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Region VARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Sample Data
INSERT INTO Customers (CustomerID, Name, Region) VALUES
(1, 'Alice', 'North'),
(2, 'Bob', 'South'),
(3, 'Charlie', 'East'),
(4, 'David', 'West');

INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 600.00),
(4, 'Headphones', 'Accessories', 150.00);

INSERT INTO Orders (OrderID, CustomerID, OrderDate) VALUES
(1, 1, '2023-01-15'),
(2, 2, '2023-02-20'),
(3, 3, '2023-03-25'),
(4, 4, '2023-04-30');

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
(1, 1, 1, 1),
(2, 2, 2, 2),
(3, 3, 3, 1),
(4, 4, 4, 3);


-- @block
-- create sample database for this exercise
CREATE DATABASE Employee_Management;
GO


-- @block
-- Employee Management System SQL Exercises

-- Database Schema

-- The following schema defines the structure for an Employee
-- Management System: 

USE Employee_Management;

-- Departments Table
CREATE TABLE Departments ( 
    DepartmentID INT PRIMARY KEY, 
    DepartmentName VARCHAR(100) 
); 
 

-- Employees Table
CREATE TABLE Employees ( 
    EmployeeID INT PRIMARY KEY, 
    FirstName VARCHAR(50), 
    LastName VARCHAR(50), 
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID), 
    Salary DECIMAL(10,2), 
    JoinDate DATE 
); 
 

-- Sample Data
-- The following sample data can be used for testing: 

-- Departments Sample Data
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES 
(1, 'HR'), 
(2, 'Finance'), 
(3, 'IT'), 
(4, 'Marketing'); 
 

-- Employees Sample Data
INSERT INTO Employees (EmployeeID, FirstName, LastName,
DepartmentID, Salary, 
JoinDate) VALUES 
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'), 
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'), 
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'), 
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05'); 


-- @block
-- check all tables in the created database
USE Employee_Management;
SELECT *
FROM INFORMATION_SCHEMA.COLUMNS
-- WHERE TABLE_NAME = 'Products';
