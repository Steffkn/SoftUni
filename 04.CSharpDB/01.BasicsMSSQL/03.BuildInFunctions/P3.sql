-- Diablo
-- 14
USE Diablo
GO

SELECT TOP(50) [Name], CONVERT(varchar, [Start], 23) FROM Games
WHERE Year([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start]

-- 15
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email) + 1) AS 'Email provider' FROM Users
ORDER BY 'Email provider', Username


-- 16 %***.1^.^.***%'
SELECT Username, IpAddress AS 'IP Address' FROM Users
WHERE IpAddress LIKE '[0-9][0-9][0-9].1[0-9]%.[0-9]%.[0-9][0-9][0-9]' 
ORDER BY Username

-- 17
WITH CTE AS (
	SELECT [Name] AS Game,
	CASE 
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END AS 'Parts of the day' , 
	CASE 
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS 'Duration2' FROM Games
)
SELECT * FROM CTE
ORDER BY Game, 'Duration2', 'Parts of the day'