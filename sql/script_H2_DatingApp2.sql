USE master
GO
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'datingapp')
BEGIN
	CREATE DATABASE datingapp
END
USE datingapp
GO
DROP TABLE AttractionTable
GO
DROP TABLE Addresses
GO
DROP TABLE PersonInfo
GO
DROP TABLE MessageTable
GO
DROP TABLE ILikeTable
GO
DROP TABLE Users
GO


CREATE TABLE Users(
	UsersID int identity(1,1) primary key,
	MyUsername nvarchar(255) NOT NULL UNIQUE,
	MyPassword nvarchar(255) NOT NULL,
	Active nvarchar(255) CHECK (Active='True' OR Active='False') NOT NULL,
)
GO

CREATE TABLE PersonInfo (
PersonInfoID int identity(1,1) primary key,
UsersID int NOT NULL UNIQUE,
MyFirstName nvarchar(255) NOT NULL,
MyLastName nvarchar(255) NOT NULL,
MyAge int NOT NULL,
MyHeight int NOT NULL,
MyWeight int NOT NULL,
MyGender nvarchar(255) CHECK (MyGender='Male' OR MyGender='Female') NOT NULL,
CHECK (MyAge >= 15 AND MyAge <= 150),
)
GO

ALTER TABLE PersonInfo
ADD FOREIGN KEY (UsersID) REFERENCES Users(UsersID)
GO

CREATE TABLE Addresses (
	AddressesID int identity(1,1) primary key,
	UsersID int NOT NULL UNIQUE,
	MyCity nvarchar(255) NOT NULL,
	MyZipCode nvarchar(255) NOT NULL
)
GO

ALTER TABLE Addresses
ADD FOREIGN KEY (UsersID) REFERENCES Users(UsersID)
GO

CREATE TABLE AttractionTable (
	AttractionTableID int identity(1,1) primary key,
	UsersID int NOT NULL UNIQUE,
	ILikeGender nvarchar(255) CHECK (ILikeGender='Male' OR ILikeGender='Female') NOT NULL,
	MinAge int DEFAULT 15,
	MaxAge int DEFAULT 65,
	MinHeight int DEFAULT 150,
	MaxHeight int DEFAULT 200,
	MinWeight int DEFAULT 50,
	MaxWeight int DEFAULT 100,
	CHECK (MaxAge >= MinAge AND MinAge >= 15 AND MaxAge <= 150),
	CHECK (MaxHeight >= MinHeight),
	CHECK (MaxWeight >= MinWeight)
)
GO

ALTER TABLE AttractionTable
ADD FOREIGN KEY (UsersID) REFERENCES Users(UsersID)
GO


-- # lav en liste af alle dem som du er tiltrukket af
-- 
-- der er ingen restriktioner i databasen for hvem der kan like hvem.
-- Men i applikationen kan du kun se og like dem som du er tiltrukket af.
-- Hvem du er tiltrukket af ændre sig løbende. F.eks. kan der komme nye bruger til,
-- en bruger kan have tabt sig (ændret parameter) eller brugeren selv kan ændre sine 
-- preferencer.
--
-- Når du liker bliver noteret i iLikeTable, hvem du er og hvem du har liket.
-- Du kan kun like en bruger en gang. 
-- Hvis brugeren har liket dig også så er der match

-- hent like listen
--
-- krav en bruger må kun like en bruger som findes.
-- krav en bruger må ikke kunne like den samme person to gange.
CREATE TABLE ILikeTable (
	ILikeTableID int identity(1,1) primary key,
	WhoIAmUsersID int NOT NULL,
	WhoILikeUsersID int NOT NULL,
	CHECK (WhoIAmUsersID <> WhoILikeUsersID)
)
GO

ALTER TABLE ILikeTable
ADD FOREIGN KEY (WhoIAmUsersID) REFERENCES Users(UsersID)
GO

ALTER TABLE ILikeTable
ADD FOREIGN KEY (WhoILikeUsersID) REFERENCES Users(UsersID)
GO

ALTER TABLE ILikeTable
ADD CONSTRAINT uc_composite UNIQUE (WhoIAmUsersID,WhoILikeUsersID)
GO

CREATE TABLE MessageTable (
	MessageTableID int identity(1,1) primary key,
	SenderUsersID int NOT NULL ,
	RecipientUsersID int NOT NULL,
	MyMessage nvarchar(255),
	CHECK (SenderUsersID <> RecipientUsersID)
)
GO

ALTER TABLE MessageTable
ADD FOREIGN KEY (SenderUsersID) REFERENCES Users(UsersID)
GO

ALTER TABLE MessageTable
ADD FOREIGN KEY (RecipientUsersID) REFERENCES Users(UsersID)


GO
-- Alle piger er tiltrukket af gillelejeBoy
-- gilleLejeBoy er tiltrukket af emilieGirl og kiaGirl - de lever op til hans krav

-- insert dummy data
INSERT INTO Users VALUES 
('gillelejeBoy', '1234', 'True'),
('vicmrp', '1234', 'True'),
('flyelsker', '1234', 'True'),
('leaGirl', '1234', 'True'),
('louiseGirl', '1234', 'True'),
('emilieGirl', '1234', 'True'),
('kiaGirl', '1234', 'True')
GO

INSERT INTO PersonInfo VALUES
-- UsersID FirstName LastName Age Height Weight
(1,'Alex', 'Petersen', 31, 192, 95,'Male'),
(2, 'Victor', 'Reipur', 30, 189, 92, 'Male'),
(3, 'Anmar', 'Al-Baraki', 30, 184, 87, 'Male'),
(4, 'Lea', 'Mager', 27, 175, 75, 'Female'),
(5, 'Louise', 'Havelove', 27, 175, 75, 'Female'),

-- dem som gillelejeBoy er tiltrukket af.
(6, 'Emilie', 'Mooller', 19, 170, 75, 'Female'),
(7, 'Kia', 'Kiasen', 21, 180, 75, 'Female')
GO

INSERT INTO Addresses VALUES
-- UsersID City ZipCode
(1, 'Gilleleje', '3250'),
(2, 'Klampenborg', '2930'),
(3, 'Sooborg', '3250'),
(4, 'Vangede', '2860'),
(5, 'Gentofte', '2820'),
(6, 'Kooge', '4000'),
(7, 'Kooge', '4000')
GO

INSERT INTO AttractionTable VALUES
-- UsersID Gender MinAge MaxAge MinHeight MaxHeight MinWeight MaxWeight
(1, 'Female', 19, 21, 170, 180, 50, 75 ),
(2, 'Female', 20, 30, 150, 200, 50, 75 ),
(3, 'Female', 15, 16, 160, 190, 40, 120),
(4, 'Male', 30, 50, 180, 200, 80, 95),
(5, 'Male', 30, 50, 180, 200, 80, 95),
(6, 'Male', 30, 50, 180, 200, 80, 95),
(7, 'Male', 30, 50, 180, 200, 80, 95)
GO

--INSERT INTO ILikeTable VALUES
--(4,1),
--(1,4),
--(3,4),
--(4,3)
--GO

---- skriv i chatten 
--INSERT INTO MessageTable VALUES
--(4,1,'Hej gillejejeboy hilsen leagirl'),
--(1,2,'Hej vicmrp, gaar det godt? Hilsen gillelejeboy'),
--(1,4, 'Hej Leagirl. Hilsen Gillejeboy.'),
--(2,1, 'Hej gillelejeeboy hilsen vicmrp')
---- vicmrp skriver til leaGirl
--(2,4, 'Hej leaGirl. Hilsen vicmrp'),
--(4,2, 'Hej vicmrp. Hilsen leaGirl')
--GO
