USE [master]
GO
/****** Object:  Database [InventoryDB]    Script Date: 02/06/2024 3:25:12 pm ******/
CREATE DATABASE [InventoryDB]
 
USE [InventoryDB]
GO
/****** Object:  Table [dbo].[City]    Script Date: 02/06/2024 3:25:12 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[StateId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 02/06/2024 3:25:12 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 02/06/2024 3:25:12 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[CountryId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02/06/2024 3:25:12 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(100,1) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[MobileNumber] [nvarchar](12) NULL,
	[EmailId] [nvarchar](100) NOT NULL,
	[ProfileURL] [nvarchar](200) NULL,
	[Password] [nvarchar](12) NOT NULL,
	[OTP] [nvarchar](10) NULL,
	[OTPCreatedOn] [datetime] NULL,
	[CurrentAddress] [nvarchar](1000) NULL,
	[PermanentAddress] [nvarchar](1000) NULL,
	[CityId] [int] NULL,
	[StateId] [int] NULL,
	[CountryId] [int] NULL,
	[ZipCode] [nvarchar](10) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 02/06/2024 3:25:12 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[City] ([Id], [Name], [StateId], [IsActive]) VALUES (1, N'Mumbai', 1, 1)
GO
INSERT [dbo].[City] ([Id], [Name], [StateId], [IsActive]) VALUES (2, N'Nagpur', 1, 1)
GO
INSERT [dbo].[City] ([Id], [Name], [StateId], [IsActive]) VALUES (3, N'Pune', 1, 1)
GO
INSERT [dbo].[City] ([Id], [Name], [StateId], [IsActive]) VALUES (4, N'Ahmedabad', 2, 1)
GO
INSERT [dbo].[City] ([Id], [Name], [StateId], [IsActive]) VALUES (5, N'Gandhinagar', 2, 1)
GO
INSERT [dbo].[City] ([Id], [Name], [StateId], [IsActive]) VALUES (6, N'Surat', 2, 1)
GO
INSERT [dbo].[City] ([Id], [Name], [StateId], [IsActive]) VALUES (7, N'Hyderabad', 3, 1)
GO
INSERT [dbo].[City] ([Id], [Name], [StateId], [IsActive]) VALUES (8, N'Nizamabad', 3, 1)
GO
INSERT [dbo].[City] ([Id], [Name], [StateId], [IsActive]) VALUES (9, N'Vijaywada', 3, 1)
GO
INSERT [dbo].[Country] ([Id], [Name], [IsActive]) VALUES (1, N'India', 1)
GO
INSERT [dbo].[Country] ([Id], [Name], [IsActive]) VALUES (2, N'China', 1)
GO
INSERT [dbo].[State] ([Id], [Name], [CountryId], [IsActive]) VALUES (1, N'Maharashtra', 1, 1)
GO
INSERT [dbo].[State] ([Id], [Name], [CountryId], [IsActive]) VALUES (2, N'Gujrat', 1, 1)
GO
INSERT [dbo].[State] ([Id], [Name], [CountryId], [IsActive]) VALUES (3, N'Telangana', 1, 1)
GO
INSERT [dbo].[State] ([Id], [Name], [CountryId], [IsActive]) VALUES (4, N'Shandong', 2, 1)
GO
INSERT [dbo].[State] ([Id], [Name], [CountryId], [IsActive]) VALUES (5, N'Anhui', 2, 1)
GO
INSERT [dbo].[State] ([Id], [Name], [CountryId], [IsActive]) VALUES (6, N'Hainan', 2, 1)
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [UserTypeId], [Name], [MobileNumber], [EmailId], [ProfileURL], [Password], [OTP], [OTPCreatedOn], [CurrentAddress], [PermanentAddress], [CityId], [StateId], [CountryId], [ZipCode], [IsActive], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (101, 1, N'Virat Kohli', N'8795854547', N'virat@gmail.com', N'', N'virat@123', NULL, NULL, N'Pune', N'Banglore', 3, 1, 1, N'78965', 1, 0, CAST(N'2024-05-21T21:48:44.070' AS DateTime), 0, NULL, NULL)
GO
INSERT [dbo].[User] ([Id], [UserTypeId], [Name], [MobileNumber], [EmailId], [ProfileURL], [Password], [OTP], [OTPCreatedOn], [CurrentAddress], [PermanentAddress], [CityId], [StateId], [CountryId], [ZipCode], [IsActive], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (102, 3, N'Rohit Sharma', N'6544889998', N'rohit@gmail.com', N'', N'rohit@123', NULL, NULL, N'Mumbai', N'Mumbai', 1, 1, 1, N'00001', 1, 0, CAST(N'2024-05-21T21:53:09.097' AS DateTime), 0, NULL, NULL)
GO
INSERT [dbo].[User] ([Id], [UserTypeId], [Name], [MobileNumber], [EmailId], [ProfileURL], [Password], [OTP], [OTPCreatedOn], [CurrentAddress], [PermanentAddress], [CityId], [StateId], [CountryId], [ZipCode], [IsActive], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1101, 2, N'Shreyas Iyer', N'', N'shreyas@gmail.com', N'', N'shreyas@123', NULL, NULL, N'', N'', 2, 1, 1, N'', 1, 0, CAST(N'2024-05-22T21:46:05.947' AS DateTime), 0, NULL, NULL)
GO
INSERT [dbo].[User] ([Id], [UserTypeId], [Name], [MobileNumber], [EmailId], [ProfileURL], [Password], [OTP], [OTPCreatedOn], [CurrentAddress], [PermanentAddress], [CityId], [StateId], [CountryId], [ZipCode], [IsActive], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1102, 3, N'Shikhar', N'', N'test@gmail.com', N'', N'test@123', NULL, NULL, N'', N'', 6, 2, 1, N'', 1, 0, CAST(N'2024-05-22T21:50:44.570' AS DateTime), 0, NULL, NULL)
GO
INSERT [dbo].[User] ([Id], [UserTypeId], [Name], [MobileNumber], [EmailId], [ProfileURL], [Password], [OTP], [OTPCreatedOn], [CurrentAddress], [PermanentAddress], [CityId], [StateId], [CountryId], [ZipCode], [IsActive], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1103, 1, N'Dinesh Kartik', N'8956325474', N'dinesh@gmail.com', N'', N'dinesh@123', NULL, NULL, N'Delhi', N'Mumbai', 1, 1, 1, N'', 1, 0, CAST(N'2024-05-23T21:21:06.120' AS DateTime), 0, NULL, NULL)
GO
INSERT [dbo].[User] ([Id], [UserTypeId], [Name], [MobileNumber], [EmailId], [ProfileURL], [Password], [OTP], [OTPCreatedOn], [CurrentAddress], [PermanentAddress], [CityId], [StateId], [CountryId], [ZipCode], [IsActive], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1104, 2, N'MS Dhoni', N'6546546545', N'ms@gmail.com', N'', N'ms@123', NULL, NULL, N'Chennai', N'Ranchi', 7, 3, 1, N'', 1, 0, CAST(N'2024-05-23T21:23:04.460' AS DateTime), 0, NULL, NULL)
GO
INSERT [dbo].[User] ([Id], [UserTypeId], [Name], [MobileNumber], [EmailId], [ProfileURL], [Password], [OTP], [OTPCreatedOn], [CurrentAddress], [PermanentAddress], [CityId], [StateId], [CountryId], [ZipCode], [IsActive], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1105, 3, N'dgfgdfg', N'6465454545', N'ms3@gmail.com', N'', N'test@123', NULL, NULL, N'dgfg', N'gdfgf', 2, 1, 1, N'', 1, 0, CAST(N'2024-05-23T21:36:52.363' AS DateTime), 0, NULL, NULL)
GO
INSERT [dbo].[User] ([Id], [UserTypeId], [Name], [MobileNumber], [EmailId], [ProfileURL], [Password], [OTP], [OTPCreatedOn], [CurrentAddress], [PermanentAddress], [CityId], [StateId], [CountryId], [ZipCode], [IsActive], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1106, 3, N'fagdg', N'8744545454', N'test1@gmail.com', N'', N'vfdvfd', NULL, NULL, N'gfdgfd', N'gdfgdf', 1, 1, 1, N'', 1, 0, CAST(N'2024-05-23T21:45:42.600' AS DateTime), 0, NULL, NULL)
GO
INSERT [dbo].[User] ([Id], [UserTypeId], [Name], [MobileNumber], [EmailId], [ProfileURL], [Password], [OTP], [OTPCreatedOn], [CurrentAddress], [PermanentAddress], [CityId], [StateId], [CountryId], [ZipCode], [IsActive], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1107, 1, N'grasg', N'4545454545', N'tes@gmail.com', N'', N'gdfgfd', NULL, NULL, N'gfdgdf', N'bfdfd', 5, 2, 1, N'', 1, 0, CAST(N'2024-05-23T21:46:38.640' AS DateTime), 0, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT [dbo].[UserType] ([Id], [Title], [IsActive]) VALUES (1, N'SuperAdmin', 1)
GO
INSERT [dbo].[UserType] ([Id], [Title], [IsActive]) VALUES (2, N'Admin', 1)
GO
INSERT [dbo].[UserType] ([Id], [Title], [IsActive]) VALUES (3, N'General', 1)
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserType] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[usp_AddUser]    Script Date: 02/06/2024 3:25:13 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AddUser]    
@UserTypeId int,    
@Name NVARCHAR(200),    
@MobileNumber NVARCHAR(12)='',    
@EmailId NVARCHAR(100),    
@ProfileURL NVARCHAR(200) = '',    
@Password NVARCHAR(12),    
--@OTP NVARCHAR(10),    
--@OTPCreatedOn DATETIME,    
@CurrentAddress NVARCHAR(1000)='',    
@PermanentAddress NVARCHAR(1000)='',    
@CityId int,    
@StateId int,    
@CountryId int,    
@ZipCode NVARCHAR(10)='',    
@IsActive bit,    
--@IsDeleted bit,    
@CreatedBy int=0,    
@StatusCode INT OUT    
AS    
BEGIN    
    
 IF EXISTS(SELECT 1 FROM [User] WHERE EmailId = @EmailId)     
 BEGIN    
  SET @StatusCode = -301;    
  RETURN;    
 END    
    
 IF EXISTS(SELECT 1 FROM [User] WHERE MobileNumber<>'' AND MobileNumber = @MobileNumber)     
 BEGIN    
  SET @StatusCode = -302;    
  RETURN;    
 END    
    
 INSERT INTO [User](UserTypeId,[Name],MobileNumber,EmailId,ProfileURL,[Password],CurrentAddress,PermanentAddress,CityId,StateId,CountryId,ZipCode,IsActive,IsDeleted,CreatedDate,CreatedBy)    
    
 VALUES(@UserTypeId,@Name,@MobileNumber,@EmailId,@ProfileURL,@Password,@CurrentAddress,@PermanentAddress,@CityId,@StateId,@CountryId,@ZipCode,@IsActive,0,GETDATE(),@CreatedBy)    
    
 SELECT @StatusCode = @@IDENTITY    
    
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCityDropdown]    Script Date: 02/06/2024 3:25:13 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[usp_GetCityDropdown]
@StateId int
AS
BEGIN

  SELECT Id, [Name] FROM City WHERE IsActive = 1 AND StateId = @StateId ORDER BY [Name]

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCountryDropdown]    Script Date: 02/06/2024 3:25:13 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[usp_GetCountryDropdown]
AS
BEGIN

  SELECT Id, [Name] FROM Country WHERE IsActive = 1 ORDER BY [Name]

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetStateDropdown]    Script Date: 02/06/2024 3:25:13 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[usp_GetStateDropdown]
@CountryId int
AS
BEGIN

  SELECT Id, [Name] FROM [State] WHERE IsActive = 1 AND CountryId = @CountryId ORDER BY [Name]

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserProfile]    Script Date: 02/06/2024 3:25:13 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetUserProfile]  
@UserId int   
AS  
BEGIN  
    
  
 SELECT U.Id,U.UserTypeId,UT.Title AS UserType,U.[Name],U.EmailId,U.MobileNumber FROM [User] U INNER JOIN UserType UT ON U.UserTypeId = UT.Id
 WHERE U.Id = @UserId
  
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUserTypeDropdown]    Script Date: 02/06/2024 3:25:13 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetUserTypeDropdown]
AS
BEGIN

  SELECT Id, Title FROM UserType WHERE IsActive = 1 ORDER BY Title

END
GO
/****** Object:  StoredProcedure [dbo].[usp_ValidateUser]    Script Date: 02/06/2024 3:25:13 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ValidateUser]  
@UserName VARCHAR(20),  
@Password NVARCHAR(50),  
@StatusCode int OUT  
AS  
BEGIN  
    IF NOT EXISTS(SELECT 1 FROM [User] WHERE EmailId = @UserName)  
 BEGIN  
   SET @StatusCode = -401;  
   RETURN;  
 END  
  
 IF NOT EXISTS(SELECT 1 FROM [User] WHERE EmailId = @UserName AND [Password] = @Password)  
 BEGIN  
   SET @StatusCode = -402;  
   RETURN;  
 END  
  
 SELECT @StatusCode = Id FROM [User] WHERE EmailId = @UserName AND [Password] = @Password  
  
END
GO
USE [master]
GO
ALTER DATABASE [InventoryDB] SET  READ_WRITE 
GO
