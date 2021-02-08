
USE datingapp;  
GO
DROP PROCEDURE IF EXISTS sp_login
GO
CREATE PROCEDURE sp_login
@MyUsername nvarchar(255),
@MyPassword nvarchar(255)
AS  
DECLARE @ReturnValue int
GO

-- hvis retunere 1 fortsæt ellers fejl.
EXECUTE @ReturnValue = sp_validateCredentials @MyUsername, @MyPassword
GO
IF @ReturnValue = 1
BEGIN
	PRINT 'if hello world'
   --do something
END
ELSE
BEGIN
	PRINT 'else hello world'
   --do something else
END


EXECUTE sp_login @MyUsername='vicmrp', @MyPassword='Password123'


--SELECT COUNT(column_name)
--FROM table_name
--WHERE condition;