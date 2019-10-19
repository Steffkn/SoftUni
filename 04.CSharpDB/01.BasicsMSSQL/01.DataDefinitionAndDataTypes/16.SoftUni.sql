
-- Problem 16: Create SoftUni Database
--- Towns (Id, Name)
--- Addresses (Id, AddressText, TownId)
--- Departments (Id, Name)
--- Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
--- Id columns are auto incremented starting from 1 and increased by 1 (1, 2, 3, 4…). Make sure you use appropriate data types for each column. Add primary and foreign keys as constraints for each table. Use only SQL queries. Consider which fields are always required and which are optional.

CREATE DATABASE SoftUni
GO

USE SoftUni 
GO

CREATE TABLE Towns(
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(MAX)
);

CREATE TABLE Addresses (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AddressText NVARCHAR(100) NOT NULL,
    TownId INT FOREIGN KEY REFERENCES Towns(Id)
);

CREATE TABLE Departments (
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(MAX)
);

CREATE TABLE Employees  (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(30) NOT NULL,
    MiddleName NVARCHAR(30),
    LastName NVARCHAR(30) NOT NULL,
    JobTitle NVARCHAR(30) NOT NULL,
    DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
    HireDate DATE NOT NULL,
    Salary DECIMAL(13,2) NOT NULL,
    AddressId INT FOREIGN KEY REFERENCES Addresses(Id),
);

INSERT INTO Towns([Name]) VALUES 
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas');


INSERT INTO Departments([Name]) VALUES 
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance');


INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES 
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '01/02/2013', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '02/03/2004', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '09/12/2007', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 5, '08/28/2016', 599.88);


-- 19. Basic Select All Fields

USE SoftUni
GO

SELECT * FROM Towns;
SELECT * FROM Departments;
SELECT * FROM Employees;

-- 20. Basic Select All Fields and Order Them
USE SoftUni
GO

SELECT * FROM Towns
ORDER BY [Name];
SELECT * FROM Departments
ORDER BY [Name];
SELECT * FROM Employees
ORDER BY Salary DESC;

-- 21. Basic Select Some Fields
USE SoftUni
GO

SELECT [Name] FROM Towns
ORDER BY [Name];
SELECT [Name] FROM Departments
ORDER BY [Name];
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC;

-- 22 
UPDATE Employees
SET Salary += Salary * 0.10

SELECT Salary FROM Employees

