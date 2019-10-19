SELECT FirstName, LastName, Age FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

SELECT s.FirstName, s.LastName, COUNT(TeacherId) as TeachersCount  FROM Students s
LEFT JOIN StudentsTeachers st
ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName

SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] FROM Students as S
LEFT JOIN StudentsExams AS se
ON se.StudentId = s.Id
WHERE se.ExamId IS NULL
ORDER BY [Full Name]

-- ROUND(Grade ,2)
-- FORMAT for dates
SELECT TOP 10 s.FirstName, s.LastName, CAST(AVG(se.Grade) AS DECIMAL(3,2))AS Grade FROM Students as S
LEFT JOIN StudentsExams AS se
ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName

-- CONCAT with MiddleName can be NULL
SELECT CONCAT(FirstName, ' ', s.MiddleName + ' ', s.LastName) AS [Full Name] FROM Students as S
LEFT JOIN StudentsSubjects AS ss
ON ss.StudentId = s.Id
WHERE ss.StudentId IS NULL
ORDER BY [Full Name]

-- GROUP BY ID so we can ORDER BY ID later
SELECT s.[Name], AVG(ss.Grade) AS [AverageGrade] FROM Subjects s
JOIN StudentsSubjects ss
ON ss.SubjectId = s.Id
GROUP BY s.[Name], s.Id
ORDER BY s.Id

GO
-- FUNCTION TIME --
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS NVARCHAR(100)
BEGIN
	DECLARE @studentName NVARCHAR(30) = (
		SELECT TOP 1 FirstName FROM Students
		WHERE Id = @studentId
	)

	IF (@studentName IS NULL)
	BEGIN
		RETURN 'The student with provided id does not exist in the school!'
	END

	IF (@grade > 6.00)
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END

	DECLARE @studentGradeCount INT = (
		SELECT COUNT(Grade) FROM StudentsExams
		WHERE StudentId = @studentId AND (Grade >= @grade AND Grade <= (Grade + 0.50))
	)

	RETURN CONCAT('You have to update ', @studentGradeCount, ' grades for the student ', @studentName)
END

GO
-- END OF FUNCTION TIME --

-- PROCEDURE TIME --
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @studentsMatchingIdCount INT = (
		SELECT COUNT(Id) FROM Students
		WHERE Id = @StudentId
	)

	IF (@studentsMatchingIdCount = 0)
	BEGIN
		RAISERROR('This school has no student with the provided id!' , 16, 1)
		RETURN;
	END
	
	DELETE FROM StudentsExams
	WHERE StudentId = @StudentId

	DELETE FROM StudentsSubjects
	WHERE StudentId = @StudentId

	DELETE FROM StudentsTeachers
	WHERE StudentId = @StudentId

	DELETE FROM Students
	WHERE Id = @StudentId
END