Examl

DDL 

CREATE DATABASE Bitbucket
GO
USE Bitbucket
GO

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(30) NOT NULL
)

CREATE TABLE Repositories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	CONSTRAINT PK_RepositoriesContributors PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues(
	Id INT PRIMARY KEY IDENTITY,
	[Title] VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
)


CREATE TABLE Commits(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
)


CREATE TABLE Files(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[Size] DECIMAL(15,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL,
)



-- GRUD


INSERT INTO Files([Name], [Size], ParentId, CommitId) VALUES 
('Trade.idk', 2598.0,1,1),
('menu.net', 9238.31, 2,2),
('Administrate.soshy', 1246.93,	3,	3),
('Controller.php',7353.15,	4,	4),
('Find.java', 9957.86,5,	5),
('Controller.json',	14034.87,	3,	6),
('Operate.xix',	7662.92, 7,	7);


INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId) VALUES 
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8);



UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId IN (6);



SELECT * FROM Repositories
WHERE Name = 'Softuni-Teamwork'


SELECT * FROM Commits
WHERE RepositoryId = 3
SELECT * FROM Files
WHERE CommitId = 36





DELETE FROM RepositoriesContributors
WHERE RepositoryId IN (
						SELECT RepositoryId FROM Repositories
						WHERE Name = 'Softuni-Teamwork'
)

DELETE FROM Files
WHERE CommitId IN (
	SELECT CommitId FROM Commits
	WHERE RepositoryId IN(
						SELECT RepositoryId FROM Repositories
						WHERE Name = 'Softuni-Teamwork')
)

DELETE FROM Commits
WHERE RepositoryId IN (
						SELECT RepositoryId FROM Repositories
						WHERE Name = 'Softuni-Teamwork'
)

DELETE FROM Issues
WHERE RepositoryId IN (
						SELECT RepositoryId FROM Repositories
						WHERE Name = 'Softuni-Teamwork'
)



SELECT Id, Message, RepositoryId, ContributorId FROM Commits
ORDER BY Id, Message, RepositoryId, ContributorId 








SELECT Id, Name, Size FROM Files
WHERE Size > 1000 AND Name Like '%html%'
ORDER BY Size DESC, Id, Name


SELECT i.Id, CONCAT(u.Username,' : ', i.Title) AS IssueAssignee  FROM Issues i
JOIN Users u
ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, IssueAssignee


SELECT Id, Name, CONCAT(Size, 'KB') as Size FROM Files
WHERE Id NOT IN (SELECT DISTINCT ParentId FROM Files f1
WHERE ParentId IS NOT NULL)




SELECT TOP(5) r.Id, r.Name, COUNT(c.RepositoryId) as Commits FROM Repositories r
JOIN Commits c
ON r.Id = c.RepositoryId
GROUP BY r.Id, r.Name

SELECT  * FROM Commits c
ORDER BY c.RepositoryId

GO

WITH CTE AS 
(
SELECT TOP(5) c.RepositoryId, COUNT(c.RepositoryId) AS Commits FROM Commits c
GROUP BY c.RepositoryId
ORDER BY COUNT(c.RepositoryId) DESC
)
SELECT r.Id, r.Name, Commits FROM CTE
RIGHT JOIN Repositories as r
ON r.Id = CTE.RepositoryId
WHERE Commits IS NOT NULL
ORDER BY Commits DESC, r.Id, r.Name

GO

SELECT * FROM Repositories r
JOIN Commits c
ON r.Id = c.RepositoryId



SELECT u.Username, AVG(f.Size) AS Size FROM Commits c
JOIN Users u
ON u.Id = c.ContributorId
JOIN Files f
ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY [Size] DESC,  u.Username


SELECT * FROM Users u
WHERE u.Id IN (SELECT DISTINCT ContributorId FROM Commits);
GO




CREATE FUNCTION dbo.udf_UserTotalCommits (@username VARCHAR(30))
RETURNS int  
AS  
BEGIN  
     RETURN(
  SELECT COUNT(c.Id) AS [Output] FROM Commits c
	WHERE c.ContributorId IN (SELECT Id FROM Users
								WHERE Username = @username)
   );  
END; 






