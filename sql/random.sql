use datingapp

SELECT COUNT (*) FROM Users WHERE MyUsername='vicmrp' AND MyPassword='Password123'


use datingapp
SELECT * FROM Users;
SELECT * FROM PersonInfo;
SELECT * FROM Addresses;

Select * FROM Users INNER JOIN
PersonInfo ON PersonInfo.UsersID = Users.UsersID INNER JOIN
Addresses ON Addresses.UsersID = Users.UsersID INNER JOIN
AttractionTable ON AttractionTable.UsersID = Users.UsersID WHERE
Users.UsersID = 1




USE datingapp;  
GO
DROP PROCEDURE IF EXISTS sp_login
GO
CREATE PROCEDURE sp_login
@MyUsername nvarchar(255),
@MyPassword nvarchar(255)
AS  
BEGIN
	DECLARE @ReturnValue int
	

   -- hvis retunere 1 fortsæt ellers fejl.
	EXECUTE @ReturnValue = sp_validateCredentials @MyUsername, @MyPassword
	IF @ReturnValue = 1
	BEGIN
      SELECT * FROM [Users] 
      INNER JOIN PersonInfo ON PersonInfo.UsersID = [Users].UsersID
      INNER JOIN [Addresses] ON [Addresses].UsersID = [Users].UsersID
      INNER JOIN [AttractionTable] ON [AttractionTable].UsersID = Users.UsersID
      WHERE Users.MyUsername = @Myusername
	END
	ELSE
	BEGIN
		RETURN NULL
	END
END
GO

DECLARE @result nvarchar
EXECUTE @result = sp_login @MyUsername='vicmrp', @MyPassword='Password123'

--SELECT COUNT(column_name)
--FROM table_name
--WHERE condition;














USE datingapp;  
GO
DROP PROCEDURE IF EXISTS sp_login
GO
CREATE PROCEDURE sp_login
@MyUsername nvarchar(255),
@MyPassword nvarchar(255)
AS  
DECLARE @ReturnValidation int

-- hvis retunere 1 fortsæt ellers fejl.
EXECUTE @ReturnValidation = sp_validateCredentials @MyUsername, @MyPassword

-- hvis validation er 1 så betyder det at brugerens username og password er korrekt
IF @ReturnValidation = 1
BEGIN
	SELECT 'if hello world'
	
	
END
ELSE
BEGIN
	SELECT 'else hello world'
	RETURN null
   --giv fejl hvis password er forkert.
END
GO

EXECUTE sp_login @MyUsername='vicmrp', @MyPassword='Password123'


--SELECT COUNT(column_name)
--FROM table_name
--WHERE condition;





--- Retunere 1 eller 0 

USE datingapp;  
GO
DROP PROCEDURE IF EXISTS sp_validateCredentials
GO
CREATE PROCEDURE sp_validateCredentials
@MyUsername nvarchar(255),
@MyPassword nvarchar(255)
AS
BEGIN
	DECLARE @ReturnValue int
	SELECT ReturnValue=COUNT(*) FROM Users Where MyUsername=@MyUsername AND MyPassword=@MyPassword
	RETURN @ReturnValue
END

-- EXECUTE sp_validateCredentials @MyUsername='vicmrp', @MyPassword='Password123'


--SELECT COUNT(column_name)
--FROM table_name
--WHERE condition;