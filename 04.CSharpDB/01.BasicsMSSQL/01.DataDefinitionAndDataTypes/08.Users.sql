-- Problem 8: Create Table Users

CREATE TABLE Users(
    Id BIGINT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(30) NOT NULL,
    Password VARCHAR(26) NOT NULL,
    ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME2,
	IsDeleted BIT,
	
	CHECK(DATALENGTH(ProfilePicture) <= 921600)
);

INSERT INTO Users(Username, Password, LastLoginTime, IsDeleted) VALUES 
('Viki', 'ala bala nica', NULL, 1),
('Dani', 'ala bala nica', NULL, 0),
('Titi', 'ala bala nica', NULL, 0),
('Desi', 'ala bala nica', NULL, 0),
('Ross', 'ala bala nica', NULL, 0);

-- Problem 9: Remove PK and add Composite PK (Id, Username)

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07D33520F7

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUsername
PRIMARY KEY(Id, Username)

-- Problem 10: Add check constraint Password at least 5 symbols long;

ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordMinLength
CHECK(LEN([Password]) >= 5)


-- Problem 11: Add check constraint LastLoginTime default date today;

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime;

-- Problem 12: Remove PK and add PK (Id), add unique check constraint for Username Len >=3
ALTER TABLE Users
DROP CONSTRAINT PK_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_UsersId
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT UQ_Username
UNIQUE(Username)

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameMinLength
CHECK(LEN([Username]) >= 3)
