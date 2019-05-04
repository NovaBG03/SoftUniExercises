CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1, 1), 
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL, 
Title NVARCHAR(20), 
Notes NVARCHAR(MAX)
)

INSERT INTO Employees
VALUES('Gogo', 'Gogov', 'Gospodin', NULL),
('Gogina', 'Gogova', 'Gospoja', NULL),
('Gogo', 'Ivanov', 'Gospodin', NULL)

CREATE TABLE Customers(
AccountNumber INT PRIMARY KEY, 
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL, 
PhoneNumber INT UNIQUE NOT NULL, 
EmergencyName NVARCHAR(30) NOT NULL, 
EmergencyNumber INT NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Customers
VALUES(1, 'Ivcho', 'Ivchov', 0977301122, 'Petko', 1111111111, NULL),
(2, 'Givcho', 'Givchov', 0944301122, 'Petko', 1111111111, NULL),
(3, 'Pavcho', 'Pavchov', 0971301122, 'Petko', 1111111111, NULL)

CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(30) PRIMARY KEY,
Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus
VALUES ('Good', NULL),
('Bad', NULL),
('Poor', NULL)

CREATE TABLE RoomTypes(
RoomType NVARCHAR(30) PRIMARY KEY,
Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes
VALUES ('Cleaned', NULL),
('Cleaning', NULL),
('Not ready for customers', NULL)

CREATE TABLE BedTypes(
BedType NVARCHAR(30) PRIMARY KEY,
Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes
VALUES ('2 beds', NULL),
('3 beds', NULL),
('1 bed', NULL)

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY, 
RoomType NVARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType), 
BedType NVARCHAR(30) FOREIGN KEY REFERENCES BedTypes(BedType), 
Rate DECIMAL(3,1) NOT NULL, 
RoomStatus NVARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus), 
Notes NVARCHAR(MAX)
)

INSERT INTO Rooms
VALUES(100, 'Cleaned', '2 beds', 1, 'Good', NULL),
(101, 'Cleaned', '2 beds', 1, 'Good', NULL),
(102, 'Cleaned', '2 beds', 1, 'Good', NULL)

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY, 
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
PaymentDate DATETIME, 
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
FirstDateOccupied DATETIME, 
LastDateOccupied DATETIME, 
TotalDays INT, 
AmountCharged DECIMAL(10,2), 
TaxRate DECIMAL, 
TaxAmount DECIMAL, 
PaymentTotal DECIMAL,
Notes NVARCHAR(MAX)
)

INSERT INTO Payments
VALUES(1, NULL, 1, NULL, NULL, 0, 10, 1, 2, 12, NULL),
(2, NULL, 1, NULL, NULL, 0, 10, 1, 2, 12, NULL),
(2, NULL, 1, NULL, NULL, 0, 10, 1, 2, 12, NULL)

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
DateOccupied DATETIME, 
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber), 
RateApplied INT, 
PhoneCharge INT,
Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies
VALUES(1, NULL, 1, 100, NULL, NULL, NULL),
(1, NULL, 1, 100, NULL, NULL, NULL),
(1, NULL, 1, 100, NULL, NULL, NULL)

UPDATE Payments SET TaxRate = 0.97 * TaxRate

SELECT TOP (10) TaxRate
FROM Payments

TRUNCATE TABLE Occupancies