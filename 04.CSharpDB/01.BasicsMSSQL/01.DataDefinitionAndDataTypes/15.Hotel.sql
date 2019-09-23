
-- Problem 15: Hotel Database
--- Employees (Id, FirstName, LastName, Title, Notes)
--- Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
--- RoomStatus (RoomStatus, Notes)
--- RoomTypes (RoomType, Notes)
--- BedTypes (BedType, Notes)
--- Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
--- Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
--- Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)

CREATE DATABASE Hotel
GO
USE Hotel 
GO

CREATE TABLE Employees(
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
);

CREATE TABLE Customers(
    AccountNumber INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL,
    EmergencyName NVARCHAR(30) NOT NULL,
    EmergencyNumber VARCHAR(20) NOT NULL,
    Notes NVARCHAR(MAX)
);

CREATE TABLE RoomStatus(
    RoomStatus INT PRIMARY KEY,
    Notes NVARCHAR(MAX)
);

CREATE TABLE RoomTypes(
    RoomType INT PRIMARY KEY,
    Notes NVARCHAR(MAX)
);

CREATE TABLE BedTypes(
    BedType INT PRIMARY KEY,
    Notes NVARCHAR(MAX)
);

CREATE TABLE Rooms(
    RoomNumber INT PRIMARY KEY IDENTITY(1,1),
    RoomType INT FOREIGN KEY REFERENCES RoomTypes(RoomType),
    BedType INT FOREIGN KEY REFERENCES BedTypes(BedType),
    Rate DECIMAL(3,1),
    RoomStatus INT FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
    Notes NVARCHAR(MAX)
);

CREATE TABLE Payments(
    Id INT PRIMARY KEY IDENTITY(1,1),
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
    PaymentDate DATE NOT NULL,
    AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
    FirstDateOccupied DATE NOT NULL,
    LastDateOccupied DATE NOT NULL,
    TotalDays INT NOT NULL,
    AmountCharged DECIMAL(13,2) NOT NULL,
    TaxRate DECIMAL(13,2) NOT NULL,
    TaxAmount DECIMAL(13,2) NOT NULL,
    PaymentTotal DECIMAL(13,2) NOT NULL,
    Notes NVARCHAR(MAX)
);

CREATE TABLE Occupancies(
    Id INT PRIMARY KEY IDENTITY(1,1),
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
    DateOccupied DATE NOT NULL,
    AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
    RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied BIT,
    PhoneCharge DECIMAL(13,2) NOT NULL,
    Notes NVARCHAR(MAX)
);

GO

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES 
('Pyrwi','Pyrwanow','Officer', NULL),
('Vtori','Toshkov','Manager', NULL),
('Treti','Mine','General', NULL);

INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES 
('QPyrwi','CPyrwanow', '32165498', 'oaksd', '321 65498 2132', NULL),
('QVtori','CToshkov', '987654321', 'qcwe', '987 65432121 32132', NULL),
('QTreti','CMine', '32165498', 'qwceq', '12 3123222', NULL);

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES 
(1, 'Свободна'),
(2, 'Zaeta'),
(99, 'hoho');

INSERT INTO RoomTypes(RoomType, Notes) VALUES 
(1, '123123'),
(2, '1424123'),
(99, '123123');

INSERT INTO BedTypes(BedType, Notes) VALUES 
(1, '123123'),
(2, '1424123'),
(99, '123123');

INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus, Notes) VALUES 
(1, 2, 23.21, 1, NULL),
(2, 1, 23.21, 2, NULL),
(1, 1, 23.21, 99, NULL);

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES 
(1, '2012-10-18T10:34:09', 2, '2012-10-18T10:34:09', '2012-10-28T10:34:09', 10, 32.15, 32.15, 32.15, 150.15, NULL),
(1, '2012-10-18T10:34:09', 2, '2012-10-18T10:34:09', '2012-10-28T10:34:09', 10, 32.15, 32.15, 32.15, 150.15, NULL),
(1, '2012-10-18T10:34:09', 2, '2012-10-18T10:34:09', '2012-10-28T10:34:09', 10, 32.15, 32.15, 32.15, 150.15, NULL);

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES 
(1, '2012-10-18T10:34:09', 2, 3, 1, 32.15, NULL),
(2, '2012-10-18T10:34:09', 2, 3, 1, 32.15, NULL),
(1, '2012-10-18T10:34:09', 2, 3, 1, 32.15, NULL);

-- Increase Employees Salary

USE Hotel
GO

SELECT Salary FROM Employees;

UPDATE Employees
SET Salary += Salary * 0.10;

SELECT Salary FROM Employees;


-- Decrease Tax Rate

USE Hotel
GO

SELECT TaxRate FROM Payments;

UPDATE Payments
SET TaxRate -= TaxRate * 0.03;

SELECT TaxRate FROM Payments;

-- Delete All Records

USE Hotel
GO

TRUNCATE TABLE Occupancies;