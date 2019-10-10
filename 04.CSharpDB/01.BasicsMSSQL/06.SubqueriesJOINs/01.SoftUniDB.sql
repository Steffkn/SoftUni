
-- 01. Employee Address

SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText FROM Employees as e
LEFT JOIN Addresses as a
ON a.AddressID = e.AddressID
ORDER BY a.AddressID 

-- 02. Addresses with Towns

SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText FROM Employees as e
INNER JOIN Addresses as a
ON a.AddressID = e.AddressID
INNER JOIN Towns as t
ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName 

-- 03. Sales Employees

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name as 'DepartmentName' FROM Employees as e
LEFT JOIN Departments as d
ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID 


-- 04. Employee Departments

SELECT TOP(5) EmployeeID, FirstName, Salary, DepartmentName FROM 
        ( 
		SELECT e.EmployeeID, e.FirstName, e.Salary, d.Name as 'DepartmentName', d.DepartmentID FROM Employees as e
		LEFT JOIN Departments as d
		ON d.DepartmentID = e.DepartmentID
		ORDER BY d.DepartmentID
		OFFSET 0 ROWS
        ) SubQueryAlias
WHERE Salary > 15000


-- 05. Employees Without Projects

SELECT TOP(3) e.EmployeeID, e.FirstName FROM Employees as e
WHERE e.EmployeeID NOT IN (SELECT EmployeeID FROM EmployeesProjects)


-- 06. Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate, d.Name as 'DeptName' FROM Employees as e
LEFT JOIN Departments as d
ON d.DepartmentID = e.DepartmentID
WHERE  e.HireDate > '01/01/1999' AND (d.Name = 'Sales' OR d.Name = 'Finance')
ORDER BY e.HireDate 


-- 07. Employees With Project
SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name FROM Employees as e
INNER JOIN EmployeesProjects AS ep
ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '08/13/2002'
ORDER BY e.EmployeeID

-- 08. Employee 24
SELECT e.EmployeeID, e.FirstName, 
CASE 
	WHEN p.StartDate >= '01/01/2005' THEN NULL
	ELSE p.Name
END AS ProjectName
FROM Employees as e
INNER JOIN EmployeesProjects AS ep
ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24


-- 09. Employee Manager
SELECT e.EmployeeID, e.FirstName, e.ManagerID, ee.FirstName  FROM Employees as e
INNER JOIN Employees as ee
ON ee.EmployeeID = e.ManagerID
WHERE e.ManagerID IN (3 , 7)
ORDER BY e.EmployeeID


-- 10. Employees Summary
SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName as EmployeeName , ee.FirstName + ' ' + ee.LastName as ManagerName, d.Name FROM Employees as e
INNER JOIN Employees as ee
ON ee.EmployeeID = e.ManagerID
INNER JOIN Departments as d
ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID


-- 11. Min Average Salary
SELECT TOP(1) AVG(e.Salary) as MinAverageSalary FROM Employees as e
GROUP BY e.DepartmentID
ORDER BY  AVG(e.Salary)



-- 12. Highest Peaks in Bulgaria

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM Mountains as m
INNER JOIN MountainsCountries as mc
ON mc.MountainId = m.Id
INNER JOIN Peaks as p
ON m.Id = p.MountainId
INNER JOIN Countries as c
ON c.CountryCode = mc.CountryCode
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC


-- 13. Count Mountain Ranges
SELECT c.CountryCode, COUNT(m.MountainRange) FROM Mountains as m
INNER JOIN MountainsCountries as mc
ON mc.MountainId = m.Id
INNER JOIN Countries as c
ON c.CountryCode = mc.CountryCode
WHERE c.CountryCode IN ('BG', 'RU', 'US')
GROUP BY c.CountryCode


-- 14

SELECT c.CountryName, r.RiverName FROM 
        ( 
		SELECT TOP(5) c.CountryName, c.CountryCode FROM Countries as c
		WHERE c.ContinentCode = 'AF'
		ORDER BY c.CountryName
        ) as c

LEFT OUTER JOIN CountriesRivers as rc
ON rc.CountryCode = c.CountryCode
LEFT OUTER JOIN Rivers as r
ON r.Id = rc.RiverID


-- 15
WITH CTE AS 
(
	SELECT c.ContinentCode, ccy.CurrencyCode, COUNT(ccy.CurrencyCode) AS CurrencyUsage , 
	RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(ccy.CurrencyCode) DESC) AS rowNumber
	FROM Continents as ct
	LEFT outer JOIN Countries as c
	ON c.ContinentCode = ct.ContinentCode
	LEFT JOIN Currencies as ccy
	ON c.CurrencyCode= ccy.CurrencyCode
	GROUP BY c.ContinentCode, ccy.CurrencyCode
	HAVING COUNT(ccy.CurrencyCode) > 1
)
SELECT ContinentCode, CurrencyCode, CurrencyUsage FROM CTE
WHERE rowNumber = 1

-- 16. Countries Without any Mountains
SELECT COUNT(resultQuery.CountryCode) FROM (SELECT c.CountryCode FROM Countries as c
LEFT OUTER JOIN MountainsCountries as mc
ON mc.CountryCode = c.CountryCode
WHERE MountainId IS NULL
GROUP BY c.CountryCode
) as resultQuery


-- 17. Highest Peak and Longest River by Country
SELECT TOP(5) c.CountryName, MAX(p.Elevation)  as HighestPeakElevation, MAX(r.Length) as LongestRiverLength FROM Mountains as m
INNER JOIN MountainsCountries as mc
ON mc.MountainId = m.Id
INNER JOIN Peaks as p
ON m.Id = p.MountainId
INNER JOIN Countries as c
ON c.CountryCode = mc.CountryCode

LEFT OUTER JOIN CountriesRivers as rc
ON rc.CountryCode = c.CountryCode
LEFT OUTER JOIN Rivers as r
ON r.Id = rc.RiverID

GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName


-- 18. Highest Peak Name and Elevation by Country
WITH CTE AS 
(
	SELECT c.CountryName, p.PeakName, p.Elevation, m.MountainRange ,
	RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS rowNumber
	FROM Countries AS c
	LEFT OUTER JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	LEFT OUTER JOIN Mountains AS m
	ON m.Id = mc.MountainId
	LEFT OUTER JOIN Peaks AS p
	ON m.Id = p.MountainId
)
SELECT TOP(5) CountryName, 
CASE 
	WHEN PeakName IS NULL THEN '(no highest peak)'
	ELSE PeakName
END
AS 'Highest Peak Name' , 
CASE 
	WHEN PeakName IS NULL THEN 0
	ELSE Elevation
END 
AS 'Highest Peak Elevation' ,
CASE 
	WHEN PeakName IS NULL THEN '(no mountain)'
	ELSE MountainRange
END 
AS 'Mountain'
FROM CTE
WHERE rowNumber = 1
ORDER BY CountryName, PeakName 
