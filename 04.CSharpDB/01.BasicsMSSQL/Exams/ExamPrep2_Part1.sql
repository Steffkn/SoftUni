CREATE DATABASE School
GO
USE School
GO

CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(30) NOT NULL,
    MiddleName NVARCHAR(25),
    LastName NVARCHAR(30) NOT NULL,
	Age SMALLINT CHECK(Age BETWEEN 5 AND 100),
    [Address] NVARCHAR(50),
    Phone NCHAR(10)

	--CONSTRAINT CHK_AgeBetween5And100
	--CHECK(Age >= 5 AND Age <=100)
)

CREATE TABLE Subjects(
	Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(20) NOT NULL,
	Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects(
	Id INT PRIMARY KEY IDENTITY,
    StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
    SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(3,2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL
)



CREATE TABLE Exams(
	Id INT PRIMARY KEY IDENTITY(1,1),
    [Date] DATETIME2,
    SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
)


CREATE TABLE StudentsExams(
    StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
    ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,	
	Grade DECIMAL(3,2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL

	CONSTRAINT PK_CompositeStudentIdExamId
	PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers(
	Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(20) NOT NULL,
    LastName NVARCHAR(20) NOT NULL,
    [Address] NVARCHAR(20) NOT NULL,
    Phone NCHAR(10),
    SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
)


CREATE TABLE StudentsTeachers(
    StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
    TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
	
	CONSTRAINT PK_CompositeStudentIdTeacherId
	PRIMARY KEY (StudentId, TeacherId)
)

-- GRUD

INSERT INTO Subjects([Name], Lessons) Values
('Geometry',	12),
('Health',	10),
('Drama',7),
('Sports',	9);

INSERT INTO Teachers(FirstName, LastName, Address, Phone, SubjectId) Values
('Ruthanne', 'Bamb','84948 Mesta Junction','3105500146', 6),
('Gerrard', 'Lowin','370 Talisman Plaza','3324874824', 2),
('Merrile', 'Lambdin','81 Dahle Plaza','4373065154', 5),
('Bert', 'Ivie','2 Gateway Circle','4409584510', 6);


UPDATE StudentsSubjects 
SET Grade = 6
WHERE Grade >= 5.5 AND SubjectId IN (1,2)

DELETE FROM StudentsTeachers
WHERE TeacherId IN (
SELECT Id FROM Teachers
WHERE Phone LIKE '%72%'
)

DELETE FROM Teachers
WHERE CHARINDEX('72', Phone) > 0