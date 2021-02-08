

USE datingapp;  
GO
DROP PROCEDURE IF EXISTS sp_CreateAccount
GO
CREATE PROCEDURE sp_CreateAccount
	-- TABLE Users
    @MyUsername nvarchar(255),
	@MyPassword nvarchar(255),
	@Active nvarchar(255),
	-- TABLE PersonInfo
	@MyFirstName nvarchar(255),
	@MyLastName nvarchar(255),
	@MyAge int,
	@MyHeight int,
	@MyWeight int,
	@MyGender nvarchar(255),
	-- TABLE Addresses
	@MyCity nvarchar(255),
	@MyZipCode nvarchar(255),
	-- TABLE AttractionTable
	@ILikeGender nvarchar(255),
	@MinAge int,
	@MaxAge int,
	@MinHeight int,
	@MaxHeight int,
	@MinWeight int,
	@MaxWeight int
AS 
	DECLARE @UsersIDD int -- int UsersIDD;

	-- Opret user i users tabel
	INSERT INTO Users VALUES 
	(@MyUsername, @MyPassword, @Active)
	
	-- Hent UsersID udefra hvad brugernavnet er.
	EXECUTE @UsersIDD = sp_GetUsersID @MyUsername

	-- Opret brugeren i tabellen PersonInfo
	INSERT INTO PersonInfo VALUES
	(@UsersIDD, @MyFirstName, @MyLastName, @MyAge, @MyHeight, @MyWeight, @MyGender)
	-- I test fasen
	--SELECT * FROM PersonInfo WHERE UsersID=@UsersIDD

	-- Opret brugeren i addresses tabellen
	INSERT INTO Addresses VALUES
	(@UsersIDD, @MyCity, @MyZipCode)
	--SELECT * FROM Addresses WHERE UsersID=@UsersIDD

	-- opret bruger i attractiontable
	INSERT INTO AttractionTable VALUES
	(@UsersIDD, @ILikeGender, @MinAge, @MaxAge, @MinHeight, @MaxHeight, @MinWeight, @MaxWeight)
	--SELECT * FROM AttractionTable WHERE UsersID=@UsersIDD
GO
