
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
