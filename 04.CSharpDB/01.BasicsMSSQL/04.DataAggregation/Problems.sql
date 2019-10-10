-- Problem 1. Records’ Count
USE Gringotts
GO

SELECT * FROM WizzardDeposits

SELECT COUNT(*) FROM WizzardDeposits


-- Problem 2. Longest Magic Wand


SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits


-- Problem 3. Longest Magic Wand per Deposit Groups

SELECT wd.DepositGroup, MAX(wd.MagicWandSize) AS LongestMagicWand FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup

-- Problem 4. *Smallest Deposit Group per Magic Wand Size
WITH CTE AS (
	SELECT DepositGroup, AVG(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits
	GROUP BY DepositGroup
)
SELECT TOP(2) DepositGroup FROM CTE
ORDER BY LongestMagicWand

-- 5
SELECT wd.DepositGroup, SUM(wd.DepositAmount) AS TotalSum FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup

-- 6 
WITH CTE AS (
	SELECT DepositGroup, DepositAmount FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
)
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM CTE
GROUP BY DepositGroup

-- 7 
WITH CTE AS (
	SELECT DepositGroup, DepositAmount FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
)
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM CTE
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

-- 8 
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup


-- 9
WITH CTE AS (
	SELECT Age,
		CASE 
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]' END AS [AgeGroup],
		COUNT(*) AS [WizardCount]
	FROM WizzardDeposits
	GROUP BY Age
)
SELECT [AgeGroup], SUM(WizardCount) AS [WizardCount] FROM CTE
GROUP BY [AgeGroup]


-- 10
WITH CTE AS (
	SELECT DepositGroup, FirstName FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest'
)
SELECT SUBSTRING(FirstName, 1, 1) AS FirstLetter FROM CTE
GROUP BY SUBSTRING(FirstName, 1, 1)
ORDER BY FirstLetter


-- 11
WITH CTE AS (
SELECT DepositGroup, IsDepositExpired, DepositInterest FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
)
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest FROM CTE
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

-- 12 
WITH CTE AS (
SELECT Id, 
		FirstName, 
		DepositAmount AS [HostDeposit], 
		LEAD(FirstName,1) 
		OVER ( ORDER BY Id) AS GuestName, 
		LEAD(DepositAmount,1) 
		OVER ( ORDER BY Id) AS [GuestDeposit]

FROM WizzardDeposits
)
SELECT SUM([HostDeposit] - [GuestDeposit]) AS SumDifference FROM CTE
























































