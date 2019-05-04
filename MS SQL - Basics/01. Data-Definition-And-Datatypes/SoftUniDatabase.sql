CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
[Id] INT PRIMARY KEY IDENTITY(1, 1), 
[Name] NVARCHAR(30) UNIQUE NOT NULL
) 

CREATE TABLE Addresses(
[Id] INT PRIMARY KEY IDENTITY(1, 1),  
[AddressText] NVARCHAR(150) NOT NULL, 
[TownId] INT FOREIGN KEY REFERENCES Towns([Id]) NOT NULL)

CREATE TABLE Departments(
[Id] INT PRIMARY KEY IDENTITY(1, 1), 
[Name] NVARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Employees(
[Id] INT PRIMARY KEY IDENTITY(1, 1), 
[FirstName] NVARCHAR(30) NOT NULL, 
[MiddleName] NVARCHAR(30) NOT NULL, 
[LastName] NVARCHAR(30) NOT NULL, 
[JobTitle] NVARCHAR(30) NOT NULL, 
[DepartmentId] INT FOREIGN KEY REFERENCES Departments([Id]) NOT NULL, 
[HireDate] DATE NOT NULL, 
[Salary] DECIMAL(7,2) NOT NULL,
[AddressId] INT FOREIGN KEY REFERENCES Addresses([Id]))

--USE master
--DROP DATABASE SoftUni

INSERT INTO Towns
VALUES('Sofia'),--1
('Plovdiv'),	--2
('Varna'),		--3
('Burgas')		--4

INSERT INTO Departments
VALUES ('Engineering'),  --1
('Sales'),               --2
('Marketing'),           --3
('Software Development'),--4
('Quality Assurance')    --5

INSERT INTO Employees ([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, CAST('20130201' AS DATE), 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, CAST('20040302' AS DATE), 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, CAST('20160828' AS DATE), 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, CAST('20071209' AS DATE), 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, CAST('20160828' AS DATE), 599.88)

SELECT TOP (10) [Name]
FROM Towns
ORDER BY [Name] ASC

SELECT TOP (10) [Name]
FROM Departments
ORDER BY [Name] ASC

SELECT TOP (10) [FirstName], [LastName], [JobTitle], [Salary]
FROM Employees
ORDER BY [Salary] DESC


UPDATE Employees SET Salary = 1.10 * Salary

SELECT TOP (10) [Salary]
FROM Employees