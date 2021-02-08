USE datingapp;  
GO
DROP PROCEDURE IF EXISTS sp_DisableAccount
GO
CREATE PROCEDURE sp_DisableAccount
@MyUsername nvarchar(255)
AS
	UPDATE Users
	SET Active = 'False'
	WHERE MyUsername=@MyUsername
GO


-- koor stored procedure
--EXECUTE sp_DisableAccount @MyUsername = 'vicmrp'