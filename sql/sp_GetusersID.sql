USE datingapp;  
GO
DROP PROCEDURE IF EXISTS sp_GetUsersID
GO
CREATE PROCEDURE sp_GetUsersID
@MyUsername nvarchar(255)
AS   
	DECLARE @ReturnValue int
	SELECT @ReturnValue=UsersID FROM Users Where MyUsername=@MyUsername
	RETURN @ReturnValue
GO