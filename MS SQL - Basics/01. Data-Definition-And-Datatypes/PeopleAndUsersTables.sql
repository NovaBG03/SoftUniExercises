CREATE DATABASE Exercise

USE Exercise

CREATE TABLE People(
[Id] INT IDENTITY(1, 1) UNIQUE,
[Name] NVARCHAR(200) NOT NULL,
[Picture] VARBINARY(MAX),
[Height] DECIMAL(3,2),
[Weight] DECIMAL(5,2),
[Gender] CHAR(1) CHECK([Gender] = 'm' OR [Gender] = 'f') NOT NULL,
[Birthdate] DATETIME NOT NULL,
[Biography] NVARCHAR(MAX)
)

ALTER TABLE People
ADD CONSTRAINT PK_Id_People
PRIMARY KEY(Id)

INSERT INTO People ([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES ('Gosho', NULL, 1.50, 90, 'm', CAST('12.03.2000' AS DATETIME), Null),
('Gosho', NULL, 1.93, 92, 'm', CAST('01.03.2001' AS DATETIME), Null),
('Misho', NULL, 1.66, 49, 'm', CAST('12.06.2002' AS DATETIME), Null),
('Pesho', NULL, 1.70, 77, 'm', CAST('09.12.2003' AS DATETIME), Null),
('Ivan', NULL, 1.80, 64, 'm', CAST('11.23.2004' AS DATETIME), Null)

SELECT TOP (10) *
FROM People

TRUNCATE TABLE People

CREATE TABLE Users(
[Id] INT IDENTITY(1, 1),
[Username] VARCHAR(30) NOT NULL,
[Password] VARCHAR(24) NOT NULL,
[ProfilePicture] VARBINARY(MAX),
[LastLoginTime] DATETIME NOT NULL,
[IsDeleted] BIT NOT NULL)

ALTER TABLE Users
ADD CONSTRAINT PK_Id_Users
PRIMARY KEY (Id)

INSERT INTO Users ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES('Ivan', '1234', NULL, CAST('01.03.2001' AS DATETIME), 1),
('Ivan', '1234', NULL, CAST('01.03.2001' AS DATETIME), 1),
('Ivan', '1234', NULL, CAST('01.03.2001' AS DATETIME), 1),
('Ivan', '1234', NULL, CAST('01.03.2001' AS DATETIME), 1),
('Ivan', '1234', NULL, CAST('01.03.2001' AS DATETIME), 1)

SELECT TOP (10) *
FROM Users

TRUNCATE TABLE Users

ALTER TABLE Users
DROP CONSTRAINT PK_Id_Users

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername_Users
PRIMARY KEY ([Id], [Username])

ALTER TABLE Users
ADD CONSTRAINT CK_Password_Users
CHECK (LEN([Password]) >= 5)

ALTER TABLE Users 
ADD CONSTRAINT DF_LastLoginTime_Users 
DEFAULT GETDATE() FOR [LastLoginTime]

ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Id_Users
PRIMARY KEY ([Id])

ALTER TABLE Users
ADD CONSTRAINT UQ_Username_Users
UNIQUE ([Username])

ALTER TABLE Users
ADD CONSTRAINT CK_Username_Users
CHECK (LEN([Username]) >= 3)
