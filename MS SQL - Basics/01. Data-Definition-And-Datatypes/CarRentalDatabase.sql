CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1,1),
CategoryName VARCHAR(30) NOT NULL, 
DailyRate INT DEFAULT 0, 
WeeklyRate INT DEFAULT 0, 
MonthlyRate INT DEFAULT 0, 
WeekendRate INT DEFAULT 0
)

INSERT INTO Categories (CategoryName)
VALUES('Category1'),
('Category2'),
('Category3')

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY(1,1), 
PlateNumber VARCHAR(10) UNIQUE NOT NULL, 
Manufacturer VARCHAR(20) NOT NULL,
Model VARCHAR(20) NOT NULL, 
CarYear DATETIME NOT NULL, 
CategoryId INT FOREIGN KEY REFERENCES Categories(Id), 
Doors INT NOT NULL CHECK (Doors >= 1 AND Doors <= 5), 
Picture BINARY, 
Condition VARCHAR(20) NOT NULL, 
Available BIT
) 

INSERT INTO Cars 
VALUES ('PB0000AA', 'Tesla', 'X', GETDATE(), 1, 4, NULL, 'Ok.', 1),
('PB0001AA', 'Tesla', 'S', GETDATE(), 1, 4, NULL, 'Poor.', 1),
('PB0002AA', 'Mercedes', 'S class', GETDATE(), 1, 4, NULL, 'Very good!', 0)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(30) NOT NULL, 
LastName VARCHAR(30) NOT NULL, 
Title VARCHAR(15), 
Notes VARCHAR(MAX)
) 

INSERT INTO Employees
VALUES('Georgi', 'Goshev', 'Mehanik', NULL),
('Georgi', 'Peshev', 'Prodavach', NULL),
('Georgi', 'Ivanov', 'Kasier', NULL)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY(1,1),
DriverLicenceNumber INT UNIQUE NOT NULL,
FullName VARCHAR(60) NOT NULL, 
Address VARCHAR(200) NOT NULL,
City VARCHAR(20) NOT NULL,
ZIPCode VARCHAR(10) NOT NULL,
Notes VARCHAR(MAX)
) 

INSERT INTO Customers
VALUES(11111100, 'Pesho Iliev', 'General Kolev 15', 'Plovidv', '4000', NULL),
(34343434, 'Maria Ilieva', 'General Kolev 15', 'Plovidv', '4000', NULL),
(23232323, 'Sasho Iliev', 'General Kolev 15', 'Plovidv', '4000', NULL)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY(1,1), 
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,  
CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL, 
CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL, 
TankLevel DECIMAL(4,2) NOT NULL,
KilometrageStart INT NOT NULL, 
KilometrageEnd INT, 
TotalKilometrage INT NOT NULL, 
StartDate DATETIME NOT NULL, 
EndDate DATETIME NOT NULL, 
TotalDays INT NOT NULL, 
RateApplied DECIMAL(5,2) NOT NULL, 
TaxRate DECIMAL(10,2) NOT NULL, 
OrderStatus BIT NOT NULL, 
Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders
VALUES(1, 1, 1, 12.3, 10, 100, 90, GETDATE(), GETDATE(), 0, 10, 900, 1, NULL),
(1, 1, 1, 12.3, 10, 100, 90, GETDATE(), GETDATE(), 0, 10, 900, 1, NULL),
(1, 1, 1, 12.3, 10, 100, 90, GETDATE(), GETDATE(), 0, 10, 900, 1, NULL)