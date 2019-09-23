-- Problem 14: Car Rental Database

CREATE DATABASE CarRental
GO
USE CarRental 
GO

CREATE TABLE Categories(
    Id INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(30) NOT NULL,
    DailyRate DECIMAL(13,2),
    WeeklyRate DECIMAL(13,2),
    MonthlyRate DECIMAL(13,2),
    WeekendRate DECIMAL(13,2)
);

CREATE TABLE Cars(
    Id INT PRIMARY KEY IDENTITY(1,1),
    PlateNumber VARCHAR(10) NOT NULL,
    Manufacturer NVARCHAR(30) NOT NULL,
    Model NVARCHAR(30) NOT NULL,
    CarYear INT NOT NULL,
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
    Doors INT,
    Picture VARBINARY(MAX),
	Condition NVARCHAR(200),
	Available BIT,
);


CREATE TABLE Employees(
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
);

CREATE TABLE Customers(
    Id INT PRIMARY KEY IDENTITY(1,1),
    DriverLicenceNumber NVARCHAR(20) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200),
	City NVARCHAR(30),
	ZIPCode INT,
    Notes NVARCHAR(MAX)
);

CREATE TABLE RentalOrders(
    Id INT PRIMARY KEY IDENTITY(1,1),
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
    CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
    CarId INT FOREIGN KEY REFERENCES Cars(Id),
    TankLevel INT NOT NULL,
    KilometrageStart INT NOT NULL,
    KilometrageEnd INT NOT NULL,
    TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateAplied BIT,
	TaxRate DECIMAL(13,2),
	OrderStatus INT DEFAULT 1,
    Notes NVARCHAR(MAX)
);


INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES 
('Pyrvа', 10.22,8.11,5.33,7.99),
('Pyrvа', 10.22,8.11,5.33,7.99),
('Pyrvа', 10.22,8.11,5.33,7.99);

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES 
('AS1233FD','VW','SS', 1999, 1, 5, NULL, 'Excelent', 1),
('AS1233FD','VW','M', 2012, 2, 2, NULL, 'Poor', 1),
('AS1233FD','VW','K', 2009, 3, 5, NULL, 'Great inside', 0);

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES 
('Pyrwi','Pyrwanow','Officer', NULL),
('Vtori','Toshkov','Manager', NULL),
('Treti','Mine','General', NULL);

INSERT INTO Customers(DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES 
('123123123','Gecko',NULL, NULL, NULL, NULL),
('345345345','Tecko',NULL, NULL, NULL, NULL),
('567567567','Zmeicho',NULL, NULL, NULL, NULL);

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage,StartDate, EndDate, TotalDays, RateAplied, TaxRate, OrderStatus, Notes) VALUES 
(1 , 1, 1, 90, 140000, 145000, 000000, '2019/10/10', '2019/10/20', 10, 0, 12.3, 1, NULL),
(2 , 3, 2, 50, 140000, 145000, 000000, '2019/10/10', '2019/10/20', 10, 0, 12.3, 1, NULL),
(2 , 2, 3, 25, 140000, 145000, 000000, '2019/10/10', '2019/10/20', 10, 0, 12.3, 1, NULL);
