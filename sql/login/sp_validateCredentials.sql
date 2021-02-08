--- Retunere 1 eller 0 

USE datingapp;  
GO
DROP PROCEDURE IF EXISTS sp_validateCredentials
GO
CREATE PROCEDURE sp_validateCredentials
@MyUsername nvarchar(255),
@MyPassword nvarchar(255)
AS  
	DECLARE @ReturnValue int
	SELECT ReturnValue=COUNT(*) FROM Users Where MyUsername=@MyUsername AND MyPassword=@MyPassword
	RETURN @ReturnValue
GO

-- EXECUTE sp_validateCredentials @MyUsername='vicmrp', @MyPassword='Password123'


--SELECT COUNT(column_name)
--FROM table_name
--WHERE condition;