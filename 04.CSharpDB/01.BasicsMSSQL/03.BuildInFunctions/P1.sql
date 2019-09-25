-- 1
SELECT FirstName, LastName FROM Employees
WHERE FirstName like 'sa%';

-- 2
SELECT FirstName, LastName FROM Employees
WHERE LastName like '%ei%';


-- 3
SELECT FirstName, LastName FROM Employees
WHERE DepartmentID IN (3,10) AND Year(HireDate) BETWEEN 1995 AND 2005 ;

-- 4
SELECT FirstName, LastName FROM Employees
WHERE JobTitle not like '%engineer%';

-- 5 
SELECT [Name] FROM Towns
WHERE LEN([Name]) IN (5,6)
ORDER BY [NAME];

-- 6
SELECT TownID, [Name] FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [NAME];

-- 7
SELECT TownID, [Name] FROM Towns
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [NAME];

-- 8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE Year(HireDate) > 2000;


-- 9
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5;

-- 10
SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER (
 PARTITION BY Salary
 ORDER BY EmployeeID
 ) [Rank] FROM Employees
WHERE Salary BETWEEN 10000 AND 50000 AND [Rank] = 2
ORDER BY Salary DESC;


-- 11
WITH CTE AS
(
 SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER (
	 PARTITION BY Salary
	 ORDER BY EmployeeID
 ) [Rank] FROM Employees
)
SELECT EmployeeID,  FirstName,  LastName, Salary, [Rank] FROM CTE
WHERE Salary BETWEEN 10000 AND 50000 AND [Rank] = 2
ORDER BY Salary DESC;













































