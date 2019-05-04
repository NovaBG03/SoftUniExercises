CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY,
DirectorName VARCHAR(30) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Directors
VALUES (1, 'Gosho', NULL),
(2, 'Pesho', NULL),
(3, 'Sasho', NULL),
(4, 'Misho', NULL),
(5, 'Ivcho', NULL)

CREATE TABLE Genres(
Id INT PRIMARY KEY,
GenresName VARCHAR(20) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Genres
VALUES (1, 'Epopeq', NULL),
(2, 'Stihotvorenie', NULL),
(3, 'Balada', NULL),
(4, 'Ekshan', NULL),
(5, 'Muzikal', NULL)

CREATE TABLE Categories(
Id INT PRIMARY KEY,
CategoriesName VARCHAR(20) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Categories
VALUES (1, 'Categories1', NULL),
(2, 'Categories2', NULL),
(3, 'Categories3', NULL),
(4, 'Categories4', NULL),
(5, 'Categories5', NULL)

CREATE TABLE Movies(
[Id] INT PRIMARY KEY,
[Title] VARCHAR(40) NOT NULL,
[DirectorId] INT FOREIGN KEY REFERENCES Directors(Id),
[CopyrightYear] DATE NOT NULL,
[Length] INT NOT NULL,
[GenreId] INT FOREIGN KEY REFERENCES Genres(Id),
[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
[Rating] DECIMAL(3,2) NOT NULL,
[Notes] VARCHAR(MAX)
)

INSERT INTO Movies
VALUES(1, 'film1', 1, GETDATE(), 90, 1, 1, 5.10, NULL),
(2, 'film2', 1, GETDATE(), 90, 1, 1, 5.10, NULL),
(3, 'film3', 1, GETDATE(), 90, 1, 1, 5.10, NULL),
(4, 'film4', 1, GETDATE(), 90, 1, 1, 5.10, NULL),
(5, 'film5', 1, GETDATE(), 90, 1, 1, 5.10, NULL)
