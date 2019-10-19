USE SofUni
GO
-- 01. Employees with Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
SELECT FirstName, LastName FROM Employees
WHERE Salary > 35000
GO

EXEC usp_GetEmployeesSalaryAbove35000;
GO
-- 02. Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @MinSalary DECIMAL(13,2)
AS
SELECT FirstName, LastName FROM Employees
WHERE Salary >= @MinSalary

GO

EXEC usp_GetEmployeesSalaryAboveNumber @MinSalary = 35000;
GO

-- 03. Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith @CityName NVARCHAR(30)
AS
SELECT [Name] FROM Towns
WHERE [Name] LIKE  @CityName + '%';

GO

EXEC usp_GetTownsStartingWith @CityName = 'b';
GO

-- 04. Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown @TownName NVARCHAR(30)
AS
SELECT emp.FirstName, emp.LastName FROM Employees as emp
LEFT JOIN Addresses as addr
ON emp.AddressID = addr.AddressID
LEFT JOIN Towns as t
ON t.TownID = addr.TownID
WHERE t.[Name] = @TownName;

EXEC usp_GetEmployeesFromTown @TownName = 'Sofia';
GO

-- 05. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS 
BEGIN
    RETURN 
	CASE 
		WHEN @Salary < 30000 THEN 'Low'
		WHEN @Salary BETWEEN 30000 AND 50000 THEN 'Average'
		ELSE 'High'
	END
END;

-- 06. Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel  @LevelOfSalary NVARCHAR(10)
AS
SELECT FirstName, LastName
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) =  @LevelOfSalary;

GO
EXEC usp_EmployeesBySalaryLevel @LevelOfSalary = 'High';
GO


-- 07. Define Function

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50)) 
RETURNS BIT
AS
BEGIN
DECLARE @currentIndex int = 1;

WHILE(@currentIndex <= LEN(@word))
	BEGIN

	DECLARE @currentLetter varchar(1) = SUBSTRING(@word, @currentIndex, 1);

	IF(CHARINDEX(@currentLetter, @setOfLetters)) = 0
	BEGIN
	RETURN 0;
	END

	SET @currentIndex += 1;
	END

RETURN 1;
END


-- 08










