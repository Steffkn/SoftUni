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
