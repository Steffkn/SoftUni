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
