USE Star4Cast
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserDetails')
			AND type IN (N'U')
		)
	DROP TABLE UserDetails
GO

CREATE TABLE UserDetails (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	About NVARCHAR(1500) NULL,
	Age INT NOT NULL,
	BloodGroup INT NOT NULL,
	DateOfBirth DATETIME2(7) NOT NULL,
	Disability NVARCHAR(max) NULL,
	DttmCreted DATETIME2(7) NOT NULL,
	DttmModified DATETIME2(7) NOT NULL,
	HealthInfo NVARCHAR(200) NULL,
	MaritalStatus INT NOT NULL,
	MotherTongue NVARCHAR(100) NULL,
	Nickname NVARCHAR(200) NULL,
	ProfileAddress NVARCHAR(200) NULL,
	Religion NVARCHAR(100) NULL,
	UserId NVARCHAR(450) NULL,
	FOREIGN KEY (UserId) REFERENCES Users(Id)
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'PhysicalAppearances')
			AND type IN (N'U')
		)
	DROP TABLE PhysicalAppearances
GO

CREATE TABLE PhysicalAppearances (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	BodyType INT NOT NULL,
	Chest INT NOT NULL,
	DttmCreted DATETIME2(7) NOT NULL,
	DttmModified DATETIME2(7) NOT NULL,
	EyeColor INT NOT NULL,
	HairColor INT NOT NULL,
	HairLength INT NOT NULL,
	HairType INT NOT NULL,
	Height INT NOT NULL,
	SkinColor INT NOT NULL,
	UserId NVARCHAR(450) NULL,
	Weight INT NOT NULL,
	West INT NOT NULL,
	FOREIGN KEY (UserId) REFERENCES Users(Id)
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Accents')
			AND type IN (N'U')
		)
	DROP TABLE Accents
GO

CREATE TABLE Accents (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	Accent NVARCHAR(150) NULL,
	STATUS INT NOT NULL
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserAsents')
			AND type IN (N'U')
		)
	DROP TABLE UserAsents
GO

CREATE TABLE UserAsents (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	AccentsId UNIQUEIDENTIFIER NOT NULL,
	DttmCreted DATETIME2(7) NOT NULL,
	DttmModified DATETIME2(7) NOT NULL,
	UserId NVARCHAR(450) NULL,
	FOREIGN KEY (UserId) REFERENCES Users(Id),
	FOREIGN KEY (AccentsId) REFERENCES Accents(Id)
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Languages')
			AND type IN (N'U')
		)
	DROP TABLE Languages
GO

CREATE TABLE Languages (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	Code NVARCHAR(50) NULL,
	LANGUAGE NVARCHAR(100) NULL,
	STATUS INT NOT NULL
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserLanguage')
			AND type IN (N'U')
		)
	DROP TABLE UserLanguage
GO

CREATE TABLE UserLanguage (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	DttmCreted DATETIME2(7) NOT NULL,
	DttmModified DATETIME2(7) NOT NULL,
	LanguagesId UNIQUEIDENTIFIER NOT NULL,
	UserId NVARCHAR(450) NULL,
	FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (LanguagesId) REFERENCES Languages(Id)
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SocialAddress')
			AND type IN (N'U')
		)
	DROP TABLE SocialAddress
GO

CREATE TABLE SocialAddress (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	HelpUrl NVARCHAR(200) NULL,
	IconClass NVARCHAR(100) NULL,
	PostLabel NVARCHAR(200) NULL,
	PostUrl NVARCHAR(200) NULL,
	PreUrl NVARCHAR(200) NULL,
	SocialName NVARCHAR(200) NULL,
	STATUS INT NOT NULL
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserSocialAddress')
			AND type IN (N'U')
		)
	DROP TABLE UserSocialAddress
GO

CREATE TABLE UserSocialAddress (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	DttmCreted DATETIME2(7) NOT NULL,
	DttmModified DATETIME2(7) NOT NULL,
	SocialAddressId UNIQUEIDENTIFIER NOT NULL,
	SocialUserName NVARCHAR(200) NULL,
	STATUS INT NOT NULL,
	UserId NVARCHAR(450) NULL,
	FOREIGN KEY (UserId) REFERENCES Users(Id),
	FOREIGN KEY (SocialAddressId) REFERENCES SocialAddress(Id)
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'JobCategory')
			AND type IN (N'U')
		)
	DROP TABLE JobCategory
GO

CREATE TABLE JobCategory (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	CategoryDesc NVARCHAR(250) NULL,
	CategoryName NVARCHAR(150) NULL,
	CategoryStatus INT NOT NULL,
	DisplayName NVARCHAR(150) NULL,
	DttmCreated DATETIME2(7) NOT NULL,
	DttmModified DATETIME2(7) NOT NULL
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserJobCategory')
			AND type IN (N'U')
		)
	DROP TABLE UserJobCategory
GO

CREATE TABLE UserJobCategory (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	DttmCreted DATETIME2(7) NOT NULL,
	DttmModified DATETIME2(7) NOT NULL,
	JobCategoryId UNIQUEIDENTIFIER NOT NULL,
	UserId NVARCHAR(450) NULL,
	FOREIGN KEY (UserId) REFERENCES Users(Id),
	FOREIGN KEY (JobCategoryId) REFERENCES JobCategory(Id)
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'JobSubCategory')
			AND type IN (N'U')
		)
	DROP TABLE JobSubCategory
GO

CREATE TABLE JobSubCategory (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	DisplayName NVARCHAR(150) NULL,
	DttmCreated DATETIME2(7) NOT NULL,
	DttmModified DATETIME2(7) NOT NULL,
	JobCategoryId UNIQUEIDENTIFIER NOT NULL,
	SubCategoryDesc NVARCHAR(250) NULL,
	SubCategoryName NVARCHAR(150) NULL,
	SubCategoryStatus INT NOT NULL,
	SubCategoryType NVARCHAR(150) NULL
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserJobSubCategory')
			AND type IN (N'U')
		)
	DROP TABLE UserJobSubCategory
GO

CREATE TABLE UserJobSubCategory (
	Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
	DttmCreted DATETIME2(7) NOT NULL,
	DttmModified DATETIME2(7) NOT NULL,
	JobSubCategoryId UNIQUEIDENTIFIER NOT NULL,
	UserId NVARCHAR(450) NULL,
	FOREIGN KEY (UserId) REFERENCES Users(Id),
	FOREIGN KEY (JobSubCategoryId) REFERENCES JobSubCategory(Id)
	)
GO


