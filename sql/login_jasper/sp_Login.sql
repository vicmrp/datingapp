
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
PRINT @result

--SELECT COUNT(column_name)
--FROM table_name
--WHERE condition;