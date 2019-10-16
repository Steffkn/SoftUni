USE Diablo
GO

-- 14. Create Table Logs

CREATE TABLE Logs(
LogId INT PRIMARY KEY IDENTITY(1,1),
AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
OldSum MONEY,
NewSum MONEY
)

GO

CREATE TRIGGER tr_ChangeBalance ON Accounts
AFTER UPDATE
AS
BEGIN
INSERT INTO Logs(AccountID,OldSum,NewSum)
SELECT i.Id, d.Balance, i.Balance 
FROM inserted AS i
INNER JOIN deleted AS d
ON i.Id = d.Id
END




-- 15. Create Table Emails

  
CREATE TABLE NotificationEmails
(
 Id INT NOT NULL IDENTITY,
 Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
 [Subject] VARCHAR(50),
 Body TEXT
)

GO

CREATE TRIGGER tr_EmailsNotificationsAfterInsert
ON Logs AFTER INSERT 
AS
BEGIN
INSERT INTO NotificationEmails(Recipient,Subject,Body)
SELECT i.AccountID, 
CONCAT('Balance change for account: ',i.AccountId),
CONCAT('On ',GETDATE(),' your balance was changed from ',i.NewSum,' to ',i.OldSum)
  FROM inserted AS i
END



-- 16. Deposit Money
  
CREATE PROCEDURE usp_DepositMoney(@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN TRANSACTION

UPDATE Accounts
SET Balance += @MoneyAmount
WHERE Id = @AccountId

COMMIT


-- 17. Withdraw Money Procedure

 CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount MONEY)
     AS
  BEGIN TRANSACTION
 UPDATE Accounts
    SET Balance -= @MoneyAmount
  WHERE Id = @AccountId
DECLARE @LeftBalance MONEY = (SELECT Balance FROM Accounts WHERE Id = @AccountId)
	 IF(@LeftBalance < 0)
	  BEGIN
	   ROLLBACK
	   RAISERROR('',16,2)
	   RETURN
	  END
COMMIT

-- 18. Money Transfer
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
BEGIN TRANSACTION
EXEC usp_DepositMoney @ReceiverId, @Amount
EXEC usp_WithdrawMoney @SenderId, @Amount
COMMIT

-- 20. *Massive Shopping




-- 21. Employees with Three Projects

CREATE PROC usp_AssignProject(@EmloyeeId INT , @ProjectID INT)
AS
BEGIN TRANSACTION
DECLARE @ProjectsCount INT;
SET @ProjectsCount = (SELECT COUNT(ProjectID) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)
IF(@ProjectsCount >= 3)
BEGIN 
 ROLLBACK
 RAISERROR('The employee has too many projects!', 16, 1)
 RETURN
END
INSERT INTO EmployeesProjects
     VALUES
(@EmloyeeId, @ProjectID)
 
 COMMIT


-- 22. Delete Employees
DROP TABLE Deleted_Employees
CREATE TABLE Deleted_Employees
(
 EmployeeId INT PRIMARY KEY IDENTITY,
 FirstName VARCHAR(50), 
 LastName VARCHAR(50), 
 MiddleName VARCHAR(50), 
 JobTitle VARCHAR(50), 
 DeparmentId INT, 
 Salary MONEY
)

CREATE TRIGGER tr_DeleteEmployee ON Employees AFTER DELETE
AS
INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
SELECT d.FirstName, d.LastName, d.MiddleName, d.JobTitle, d.DepartmentID, d.Salary 
FROM deleted AS d


SELECT * FROM Deleted_Employees
DELETE FROM Employees
WHERE EmployeeID = 1























