EXECUTE sp_CreateAccount 
	-- TABLE Users
	 @MyUsername = 'Strored_procedureStrored_procedure'
	,@MyPassword = '1234Strored_procedure'
	,@Active = 'True'
	-- TABLE PersonInfo
	,@MyFirstName = 'AlexStrored_procedure'
	,@MyLastName = 'PetersenStrored_procedure'
	,@MyAge = 31
	,@MyHeight = 192
	,@MyWeight = 120
	,@MyGender = 'Male'
	-- TABLE Addresses
	,@MyCity = 'Gilleleje'
	,@MyZipCode = '2800'
	-- TABLE AttractionTable
	,@ILikeGender = 'Female'
	,@MinAge = 20
	,@MaxAge = 35
	,@MinHeight = 150
	,@MaxHeight = 200
	,@MinWeight = 50
	,@MaxWeight = 100
