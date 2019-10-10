USE SoftUni
GO

--13 SELECT * FROM Employees
SELECT DepartmentID, SUM(Salary) AS TotalSalary FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

-- 14 
WITH CTE AS (
	SELECT * FROM Employees
	WHERE DepartmentID IN (2,5,7) AND HireDate > '01/01/2000'
)
SELECT DepartmentID, MIN(Salary) FROM CTE
GROUP BY DepartmentID
ORDER BY DepartmentID

-- 15

SELECT DepartmentID, ManagerID, Salary INTO dbo.EmployeesSalary 
FROM dbo.Employees
WHERE Salary > 30000

DELETE FROM EmployeesSalary
WHERE ManagerID = 42;

UPDATE EmployeesSalary
SET Salary += 5000
WHERE DepartmentID = 1;

SELECT DepartmentID, AVG(Salary) AS AverageSalary FROM EmployeesSalary
GROUP BY DepartmentID


-- 16
SELECT DepartmentID, Max(Salary) AS AverageSalary FROM Employees
GROUP BY DepartmentID
HAVING Max(Salary) NOT BETWEEN 30000 AND 70000


-- 17
SELECT COUNT(Salary) AS Count FROM Employees
WHERE ManagerID IS NULL



-- 18
SELECT e1.DepartmentID, MIN(e1.Salary)
FROM Employees e1
WHERE 3 > (
           SELECT COUNT(Salary)
           FROM Employees e2
           WHERE e2.Salary > e1.Salary
           AND e1.DepartmentID = e2.DepartmentID
          )
GROUP BY e1.DepartmentID
ORDER BY e1.DepartmentID, MIN(e1.Salary) ASC



SELECT eee.DepartmentID, eee.ThirdHighestSalary FROM Employees e
LEFT JOIN (
SELECT e1.DepartmentID, MIN(e1.Salary) AS ThirdHighestSalary
FROM Employees e1
WHERE 3 <= (
			SELECT (
					   SELECT COUNT(Salary) AS [Count]
					   FROM Employees e2
					   WHERE e2.Salary > e1.Salary
					   AND e1.DepartmentID = e2.DepartmentID
					  ))
GROUP BY e1.DepartmentID
--ORDER BY e1.DepartmentID, MIN(e1.Salary) ASC
) AS eee
ON e.DepartmentID = eee.DepartmentID



SELECT DISTINCT e.DepartmentID, eee.ThirdHighestSalary FROM Employees e
LEFT JOIN (
SELECT e1.DepartmentID, MIN(e1.Salary) AS ThirdHighestSalary
FROM Employees e1
LEFT Outer Join Employees as t2
ON e1.EmployeeID = t2.EmployeeID
WHERE 3 <= (
			SELECT (
					   SELECT COUNT(Salary) AS [Count]
					   FROM Employees e2
					   WHERE e2.Salary > e1.Salary
					   AND e1.DepartmentID = e2.DepartmentID
					  ))				  
GROUP BY e1.DepartmentID
) AS eee
ON e.DepartmentID = eee.DepartmentID




WITH salesWithRank AS
(
   SELECT DepartmentID, Salary , RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC, EmployeeID ASC) AS RowNumber
   FROM (SELECT DISTINCT DepartmentID, Salary, EmployeeID FROM Employees) AS EE
)
SELECT DepartmentID, Salary as ThirdHighestSalary
FROM salesWithRank AS s
WHERE RowNumber = 3
















