use datingapp;
--SELECT * FROM Users;
--SELECT * FROM PersonInfo;
--SELECT * FROM Addresses;
--SELECT * FROM AttractionTable;
--SELECT * FROM MessageTable;



-- CREATE TABLE PersonInfo (
-- PersonInfoID int identity(1,1) primary key,
-- UsersID int NOT NULL UNIQUE,
-- MyFirstName nvarchar(255) NOT NULL,
-- MyLastName nvarchar(255) NOT NULL,
-- MyAge int NOT NULL,
-- MyHeight int NOT NULL,
-- MyWeight int NOT NULL,
-- MyGender nvarchar(255) CHECK (MyGender='Male' OR MyGender='Female') NOT NULL
-- )

-- CREATE TABLE AttractionTable (
-- 	AttractionTableID int identity(1,1) primary key,
-- 	UsersID int NOT NULL UNIQUE,
-- 	ILikeGender nvarchar(255) CHECK (ILikeGender='Male' OR ILikeGender='Female') NOT NULL,
-- 	MinAge int DEFAULT 15,
-- 	MaxAge int DEFAULT 65,
-- 	MinHeight int DEFAULT 150,
-- 	MaxHeight int DEFAULT 200,
-- 	MinWeight int DEFAULT 50,
-- 	MaxWeight int DEFAULT 100,
-- 	CHECK (MaxAge >= MinAge AND MinAge >= 15 AND MaxAge <= 65)
-- )

-- jeg er logget ind som det her objekt
SELECT A.UsersID as ATTUserID, P.UsersID as PINusersId, P.MyGender, P.MyAge
FROM AttractionTable A, PersonInfo P 
WHERE
(P.MyWeight>=A.MinWeight AND P.MyWeight<=A.MaxWeight) AND
(P.MyAge>=A.MinAge AND P.MyAge<=A.MaxAge) AND
(P.MyHeight>=A.MinHeight AND P.MyHeight<=A.MaxHeight) AND
P.MyGender='Female' AND
(P.UsersID <> A.UsersID AND A.UsersID=2)

--
--
SELECT *
FROM PersonInfo
WHERE 
(MyAge>=22 AND MyAge<=30) AND
(MyHeight>=160 AND MyHeight<=190) AND
(MyWeight>=50 AND MyWeight<=75) AND
MyGender='Female'


--SELECT A.PersonInfoID, A.UsersID, A.MyFirstName, A.MyLastName, A.MyAge, A.MyHeight, A.MyWeight, A.MyGender
SELECT *
FROM PersonInfo AS A
JOIN AttractionTable AS B
ON A.UsersID=B.UsersID
--WHERE
----(A.MyAge>=22 AND A.MyAge<=30 AND
---- A.MyHeight>=160 AND A.MyHeight<=190) AND
----(A.MyWeight>=50 AND A.MyWeight<=75) AND
----(A.MyGender='Female') AND
--B.UsersID = 2