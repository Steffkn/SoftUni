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