-- 12
SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode
-- there must be a better way


-- 13 
WITH CTE AS (
	SELECT P.PeakName, R.RiverName, LOWER(SUBSTRING(P.PeakName, 1, LEN(P.PeakName) - 1) + R.RiverName) As Mix FROM Peaks AS P
	RIGHT JOIN Rivers AS R
	ON RIGHT(P.PeakName, 1) = LEFT(R.RiverName, 1)
)
SELECT PeakName, RiverName, Mix FROM CTE
WHERE Mix IS NOT NULL
ORDER BY Mix
