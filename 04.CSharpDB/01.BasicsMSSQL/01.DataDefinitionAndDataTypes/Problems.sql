-- Problem 1 create new database called Minions
CREATE DATABASE Minions

GO

-- Problem 2: Create new table called Minions(Id, Name, Age) in the databes Minions.
USE Minions

GO

CREATE TABLE Minions(
	Id INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age INT NOT NULL
);

CREATE TABLE Towns(
	Id INT NOT NULL,
	Name NVARCHAR(50) NOT NULL,
);

ALTER TABLE Minions
ADD CONSTRAINT PK_MinionId PRIMARY KEY(Id)

ALTER TABLE Towns
ADD CONSTRAINT PK_TownId PRIMARY KEY(Id)

-- Problem 3 Alter Minions table, new column
GO

ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD CONSTRAINT FK_MinionTownId FOREIGN KEY (TownId) REFERENCES Towns(Id)

-- Problem 4: Insert records in tables Minions and Towns

--- Age is Not Null for some reason so we need to change it by droping the column and re-creating it.
ALTER TABLE Minions
DROP COLUMN Age;

ALTER TABLE Minions
Add Age INT;

GO

INSERT INTO Towns(Id,[Name]) VALUES 
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna');

INSERT INTO Minions(Id, [Name], Age, TownId) VALUES 
(1,'Kevin', 22, 1),
(2,'Bob', 15, 3),
(3,'Steward', NULL, 2);

-- Problem 5: Truncate Table Minions
GO
TRUNCATE TABLE Minions;

-- Problem 6: Drop All Tables
GO
DROP TABLE Minions;
DROP TABLE Towns;

-- Problem 7: Create Table People

CREATE TABLE People(
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(200) NOT NULL,
    Picture VARBINARY(MAX),
    Height DECIMAL(3,2),
    [Weight] DECIMAL(5,2),
    Gender CHAR(1) NOT NULL,
	Birthdate SMALLDATETIME NOT NULL,
	Biography NVARCHAR(MAX),
	
	CHECK(DATALENGTH(Picture) <= 2097152),
	CHECK(Gender = 'f' OR Gender = 'm'),
);

INSERT INTO People([Name], Height, [Weight], Gender, Birthdate, Biography) VALUES 
('Viki', 1.8, 67.23, 'f', '2001-01-01', 'Bio is full'),
('Dani', 1.6, 69.56, 'f', '2002-02-02', NULL),
('Krisi', 1.7, 76.34, 'f', '2003-03-03', 'Bio is full'),
('Desi', 1.8, 83.93, 'f', '2004-04-04', 'Bio is full'),
('Gosho', 2.9, 100.34, 'm', '2005-05-05', 'Bio is full');

-- Problem 8: Create Table Users

CREATE TABLE Users(
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(30) NOT NULL,
    Password VARCHAR(26) NOT NULL,
    ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT,
	
	CHECK(DATALENGTH(ProfilePicture) <= 921600)
);

INSERT INTO Users(Username, Password, LastLoginTime, IsDeleted) VALUES 
('Viki', 'ala bala nica', NULL, 1),
('Dani', 'ala bala nica', NULL, 0),
('Titi', 'ala bala nica', NULL, 0),
('Desi', 'ala bala nica', NULL, 0),
('Ross', 'ala bala nica', NULL, 0);

-- Problem 9: Remove PK and add Composite PK (Id, Username)

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07D33520F7

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUsername
PRIMARY KEY(Id, Username)

-- Problem 10: Add check constraint Password at least 5 symbols long;

ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordMinLength
CHECK(LEN([Password]) >= 5)


-- Problem 11: Add check constraint LastLoginTime default date today;

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime;

-- Problem 12: Remove PK and add PK (Id), add unique check constraint for Username Len >=3
ALTER TABLE Users
DROP CONSTRAINT PK_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_UsersId
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT UQ_Username
UNIQUE(Username)

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameMinLength
CHECK(LEN([Username]) >= 3)


-- Problem 13: Movies Database

CREATE DATABASE Movies
GO
USE Movies
GO

CREATE TABLE Directors(
    Id INT PRIMARY KEY IDENTITY(1,1),
    DirectorName NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
);

CREATE TABLE Genres(
    Id INT PRIMARY KEY IDENTITY(1,1),
    GenreName NVARCHAR(30) NOT NULL,
    Notes NVARCHAR(MAX)
);

CREATE TABLE Categories(
    Id INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(30) NOT NULL,
    Notes NVARCHAR(MAX)
);

CREATE TABLE Movies(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(30) NOT NULL,
    DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
    CopyrightYear INT NOT NULL,
    [Length] SMALLDATETIME,
    GenreId INT FOREIGN KEY REFERENCES Genres(Id),
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
    Rating DECIMAL(3,1),
    Notes NVARCHAR(MAX)
);

INSERT INTO Directors(DirectorName, Notes) VALUES 
('Pyrvi', NULL),
('Vtori', 'Random'),
('Четвъртия директор', NULL),
('Последния директор', NULL),
('Трети', NULL);

INSERT INTO Genres(GenreName, Notes) VALUES 
('Pyrvi', NULL),
('Vtori', NULL),
('Четвъртия', NULL),
('Последния', NULL),
('Трети', 'Random');

INSERT INTO Categories(CategoryName, Notes) VALUES 
('Pyrvа', NULL),
('Vtorа', NULL),
('Четвърта', 'Random'),
('Последна', NULL),
('Трета', NULL);


INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES 
('Първо', 1, 2000, NULL, 2, 3, 3.2, NULL),
('Второ', 2, 2000, NULL, 1, 4, 2.2, 'Random'),
('Трето', 3, 2000, NULL, 3, 5, 4.2, NULL),
('Chetvyrto', 4, 2000, NULL, 4, 1, NULL, NULL),
('Peto', 5, 2000, NULL, 5, 2, 10.0, NULL);


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






































