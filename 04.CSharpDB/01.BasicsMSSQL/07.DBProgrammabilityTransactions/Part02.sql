USE Bank
GO
CREATE TABLE AccountHolders
(
Id INT NOT NULL,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
SSN CHAR(10) NOT NULL
CONSTRAINT PK_AccountHolders PRIMARY KEY (Id)
)

CREATE TABLE Accounts
(
Id INT NOT NULL,
AccountHolderId INT NOT NULL,
Balance MONEY DEFAULT 0
CONSTRAINT PK_Accounts PRIMARY KEY (Id)
CONSTRAINT FK_Accounts_AccountHolders FOREIGN KEY (AccountHolderId) REFERENCES AccountHolders(Id)
)


-- 09. Find Full Name

CREATE OR ALTER PROCEDURE usp_GetHoldersFullName
AS
SELECT FirstName + ' ' + LastName AS FullName FROM AccountHolders



-- 10
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @Money Money
AS
SELECT FirstName, LastName FROM AccountHolders
WHERE Id IN (
SELECT AccountHolderId FROM Accounts
GROUP BY AccountHolderId
HAVING SUM(Balance) > @Money
)
ORDER BY FirstName, LastName


GO

EXEC usp_GetHoldersWithBalanceHigherThan 500000
GO


-- 11. Future Value Function
CREATE FUNCTION dbo.ufn_CalculateFutureValue(@Sum MONEY, @YIR FLOAT, @NumberOfYears INT)
RETURNS MONEY
BEGIN
	DECLARE @Result MONEY
	SET @Result = @Sum * POWER((1+@YIR), @NumberOfYears)
	RETURN @Result
END;
GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)
GO

-- 12. Calculating Interest

CREATE PROCEDURE dbo.usp_CalculateFutureValueForAccount @AccountID INT, @InterestRate FLOAT
AS
SELECT acc.Id, ah.FirstName, ah.LastName, acc.Balance, dbo.ufn_CalculateFutureValue(acc.Balance, @InterestRate, 5) AS 'Balance in 5 years'  FROM AccountHolders AS ah
RIGHT JOIN Accounts as acc
ON acc.AccountHolderId = ah.Id
WHERE acc.Id = @AccountID

GO


EXEC dbo.usp_CalculateFutureValueForAccount @AccountID = 1, @InterestRate = 0.1;
GO





































