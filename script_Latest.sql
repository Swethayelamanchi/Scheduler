--USE [master]
--GO
--/****** Object:  Database [Scheduler]    Script Date: 11/28/2017 5:59:58 PM ******/
--CREATE DATABASE [Scheduler]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'Scheduler', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Scheduler.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'Scheduler_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Scheduler_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
--GO
--ALTER DATABASE [Scheduler] SET COMPATIBILITY_LEVEL = 130
--GO
--IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
--begin
--EXEC [Scheduler].[dbo].[sp_fulltext_database] @action = 'enable'
--end
--GO
--ALTER DATABASE [Scheduler] SET ANSI_NULL_DEFAULT OFF 
--GO
--ALTER DATABASE [Scheduler] SET ANSI_NULLS OFF 
--GO
--ALTER DATABASE [Scheduler] SET ANSI_PADDING OFF 
--GO
--ALTER DATABASE [Scheduler] SET ANSI_WARNINGS OFF 
--GO
--ALTER DATABASE [Scheduler] SET ARITHABORT OFF 
--GO
--ALTER DATABASE [Scheduler] SET AUTO_CLOSE OFF 
--GO
--ALTER DATABASE [Scheduler] SET AUTO_SHRINK OFF 
--GO
--ALTER DATABASE [Scheduler] SET AUTO_UPDATE_STATISTICS ON 
--GO
--ALTER DATABASE [Scheduler] SET CURSOR_CLOSE_ON_COMMIT OFF 
--GO
--ALTER DATABASE [Scheduler] SET CURSOR_DEFAULT  GLOBAL 
--GO
--ALTER DATABASE [Scheduler] SET CONCAT_NULL_YIELDS_NULL OFF 
--GO
--ALTER DATABASE [Scheduler] SET NUMERIC_ROUNDABORT OFF 
--GO
--ALTER DATABASE [Scheduler] SET QUOTED_IDENTIFIER OFF 
--GO
--ALTER DATABASE [Scheduler] SET RECURSIVE_TRIGGERS OFF 
--GO
--ALTER DATABASE [Scheduler] SET  DISABLE_BROKER 
--GO
--ALTER DATABASE [Scheduler] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
--GO
--ALTER DATABASE [Scheduler] SET DATE_CORRELATION_OPTIMIZATION OFF 
--GO
--ALTER DATABASE [Scheduler] SET TRUSTWORTHY OFF 
--GO
--ALTER DATABASE [Scheduler] SET ALLOW_SNAPSHOT_ISOLATION OFF 
--GO
--ALTER DATABASE [Scheduler] SET PARAMETERIZATION SIMPLE 
--GO
--ALTER DATABASE [Scheduler] SET READ_COMMITTED_SNAPSHOT OFF 
--GO
--ALTER DATABASE [Scheduler] SET HONOR_BROKER_PRIORITY OFF 
--GO
--ALTER DATABASE [Scheduler] SET RECOVERY SIMPLE 
--GO
--ALTER DATABASE [Scheduler] SET  MULTI_USER 
--GO
--ALTER DATABASE [Scheduler] SET PAGE_VERIFY CHECKSUM  
--GO
--ALTER DATABASE [Scheduler] SET DB_CHAINING OFF 
--GO
--ALTER DATABASE [Scheduler] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
--GO
--ALTER DATABASE [Scheduler] SET TARGET_RECOVERY_TIME = 60 SECONDS 
--GO
--ALTER DATABASE [Scheduler] SET DELAYED_DURABILITY = DISABLED 
--GO
--ALTER DATABASE [Scheduler] SET QUERY_STORE = OFF
--GO
--USE [Scheduler]
--GO
--ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
--GO
--ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
--GO
--ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
--GO
--ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
--GO
--ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
--GO
--ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
--GO
--ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
--GO
--ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
--GO
USE [Scheduler]
GO
/****** Object:  Table [dbo].[CategoryType]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryType](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](255) NOT NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_CategoryType] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holidays]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holidays](
	[HolidayID] [int] IDENTITY(1,1) NOT NULL,
	[Holiday] [date] NOT NULL,
	[Description] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Holidays] PRIMARY KEY CLUSTERED 
(
	[HolidayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instructors]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructors](
	[InstructorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](255) NULL,
 CONSTRAINT [PK_Instructor] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomNumber] [int] IDENTITY(1,1) NOT NULL,
	[Location] [varchar](255) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Building] [varchar](255) NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[RoomTypeID] [int] IDENTITY(1,1) NOT NULL,
	[RoomTypeName] [varchar](255) NOT NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[RoomTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[ScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[CRN] [int] NOT NULL,
	[CourseID] [varchar](255) NOT NULL,
	[InstructorId] [int] NOT NULL,
	[Section] [int] NOT NULL,
	[RoomNumber] [int] NOT NULL,
	[Days] [varchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[Agenda] [varchar](max) NULL,
	[Series] [bit] NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[CourseId] [varchar](255) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Title] [varchar](512) NOT NULL,
	[MinCredits] [int] NOT NULL,
	[MaxCredits] [int] NOT NULL,
	[SpecialApproval] [bit] NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectType]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectType](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](255) NOT NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_SubjectType] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](25) NOT NULL,
	[Password] [varchar](512) NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[RoleID] [int] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD FOREIGN KEY([CourseID])
REFERENCES [dbo].[Subjects] ([CourseId])
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD FOREIGN KEY([InstructorId])
REFERENCES [dbo].[Instructors] ([InstructorId])
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD FOREIGN KEY([RoomNumber])
REFERENCES [dbo].[Rooms] ([RoomNumber])
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[CategoryType] ([CategoryId])
GO
ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD FOREIGN KEY([SubjectId])
REFERENCES [dbo].[SubjectType] ([SubjectId])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleId])
GO
/****** Object:  StoredProcedure [dbo].[usp_AddOrUpdateCourse]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddOrUpdateCourse] 
	-- Add the parameters for the stored procedure here
	@isNew bit,
	@CourseId varchar(255),
	@SubjectName varchar(255),
	@CategoryName varchar(255),
	@Title varchar(512),
	@MinCredits int,
	@MaxCredits int,
	@SpecialApproval bit,
	@isExists int Output 
AS
BEGIN
	SET @isExists=0
	Declare @roleid int
	if Exists(Select top 1 * from [dbo].[Subjects] where [CourseId] = @CourseId) AND @isNew = 1
	BEGIN
		Set	@isExists = 1
		Return
	END

	DECLARE @SubjectId int
	DECLARE @CategoryId int

	SELECT @SubjectId = [SubjectId] FROM [dbo].[SubjectType] WHERE [SubjectName] = @SubjectName
	SELECT @CategoryId = [CategoryId] FROM [dbo].[CategoryType] WHERE [CategoryName] = @CategoryName

	if(@isNew = 1)
	BEGIN
	INSERT INTO [dbo].[Subjects]
           ([CourseId]
           ,[SubjectId]
           ,[CategoryId]
           ,[Title]
           ,[MinCredits]
           ,[MaxCredits]
           ,[SpecialApproval])
     VALUES
           (@CourseId
           ,@SubjectId
           ,@CategoryId
           ,@Title
           ,@MinCredits
           ,@MaxCredits
           ,@SpecialApproval
		   )
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Subjects]
			SET
				[SubjectId] = @SubjectId
			   ,[CategoryId] = @CategoryId
			   ,[Title] = @Title
			   ,[MinCredits] = @MinCredits
			   ,[MaxCredits] = @MaxCredits
			   ,[SpecialApproval] = @SpecialApproval
			WHERE 
				[CourseId] = @CourseId
	END

END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddOrUpdateHoliday]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddOrUpdateHoliday] 
	-- Add the parameters for the stored procedure here
	@isNew bit,
	@holidayDate date,
	@description varchar(255),
	@isExists int Output 
AS
BEGIN
	SET @isExists=0

	if Exists(Select top 1 * from [dbo].[Holidays] where [Holiday]=@holidayDate) AND @isNew = 1
	BEGIN
		Set	@isExists = 1
		Return
	END
	
	if(@isNew = 1)
	BEGIN
		INSERT INTO [dbo].[Holidays]
           ([Holiday]
           ,[Description])
		VALUES
           (@holidayDate
           ,@description)
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Holidays]
			SET
				[Description] = @description
			WHERE 
				[Holiday] = @holidayDate
	END

END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddOrUpdateInstructor]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddOrUpdateInstructor] 
	-- Add the parameters for the stored procedure here
	@isNew bit,
	@InstructorId int,
	@firstName varchar(50),
	@middleName varchar(50),
	@lastName varchar(50),
	@email varchar(50),
	@isExists int Output 
AS
BEGIN
	SET @isExists=0
	Declare @roleid int
	if Exists(Select top 1 * from [dbo].[Instructors] 
							where 
								ISNULL([FirstName],'')= ISNULL(@firstName,'') 
								AND ISNULL([MiddleName],'')= ISNULL(@middleName,'')
								AND ISNULL([LastName],'') = ISNULL(@lastName,'') 
								AND ISNULL([Email],'') = ISNULL(@email,'')
								) AND @isNew = 1
	BEGIN
		Set	@isExists = 1
		Return
	END
	
	if(@isNew = 1)
	BEGIN
		INSERT INTO [dbo].[Instructors]
           ([FirstName]
		   ,[MiddleName]
           ,[LastName]
           ,[Email]
		   )
     VALUES
           (@firstName
		   ,@middleName
           ,@lastName
           ,@email
           )
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Instructors]
			SET
				[FirstName] = @firstName
				,[MiddleName] = @middleName
				,[LastName] = @lastName
				,[Email] = @email
			WHERE 
				[InstructorId] = @InstructorId
	END

END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddOrUpdateRoom]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddOrUpdateRoom] 
	-- Add the parameters for the stored procedure here
	@isNew bit,
	@RoomNumber int,
	@Building varchar(25),
	@location varchar(50),
	@Capacity int,
	@isExists int Output 
AS
BEGIN
	SET @isExists=0
	if Exists(Select top 1 * from [dbo].[Rooms] where [Building]=@building AND [Location]=@location) AND @isNew = 1
	BEGIN
		Set	@isExists = 1
		Return
	END
	
	if(@isNew = 1)
	BEGIN
		INSERT INTO [dbo].[Rooms]
           ([Location]
           ,[Capacity]
           ,[Building])
     VALUES
           (@location
           ,@Capacity
           ,@Building
		   )
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Rooms]
			SET
				 [Location] = @location
				,[Capacity] = @Capacity
				,[Building] = @Building
			WHERE 
				[RoomNumber] = @RoomNumber
	END

END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddOrUpdateSchedule]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddOrUpdateSchedule] 
	@isNew int,
	@ScheduleId int,
	@CRN int,
	@CourseId varchar(255),
	@InstructorId int,
	@Section int,
	@RoomNumber int,
	@Days Varchar(50),
	@StartDate Date,
	@EndDate Date,
	@StartTime Time(7),
	@EndTime Time(7),
	@Series Bit
AS
BEGIN
	
IF (@isNew = 1)
BEGIN
	INSERT INTO [dbo].[Schedules]
           ([CRN]
           ,[CourseID]
           ,[InstructorId]
           ,[Section]
           ,[RoomNumber]
           ,[Days]
           ,[StartDate]
           ,[EndDate]
           ,[StartTime]
           ,[EndTime]
           ,[Series]
		   )
     VALUES
           (@CRN
           ,@CourseId
           ,@InstructorId
           ,@Section
           ,@RoomNumber
           ,@Days
           ,@StartDate
           ,@EndDate
           ,@StartTime
           ,@EndTime
           ,@Series
		   )
END

ELSE

BEGIN

	UPDATE [dbo].[Schedules]
		SET
			[CourseID] = @CourseId
           ,[InstructorId] = @InstructorId
           ,[Section] = @Section
           ,[RoomNumber] = @RoomNumber
           ,[Days] = @Days
           ,[StartDate] = @StartDate
           ,[EndDate] = @EndDate
           ,[StartTime] = @StartTime
           ,[EndTime] = @EndTime
           ,[Series] = @Series
		WHERE [ScheduleId] = @ScheduleId AND [CRN] = @CRN

END


END
GO
/****** Object:  StoredProcedure [dbo].[usp_AddOrUpdateUser]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_AddOrUpdateUser] 
	-- Add the parameters for the stored procedure here
	@isNew bit,
	@userName varchar(25),
	@firstName varchar(50),
	@lastName varchar(50),
	@email varchar(50),
	@role varchar(50),
	@password varchar(512),
	@isExists int Output 
AS
BEGIN
	SET @isExists=0
	Declare @roleid int
	if Exists(Select top 1 * from [dbo].[Users] where [UserName]=@userName) AND @isNew = 1
	BEGIN
		Set	@isExists = 1
		Return
	END
	
	if(@isNew = 1)
	BEGIN
	Select @roleid=RoleId From [dbo].[Roles] where RoleName = @role

		INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
           ,[FirstName]
           ,[LastName]
           ,[Email]
           ,[RoleID]
           ,[Active])
     VALUES
           (@userName
           ,@password
           ,@firstName
           ,@lastName
           ,@email
           ,@roleid
           ,1)
	END
	ELSE
	BEGIN
			UPDATE [dbo].[Users]
			SET
				[FirstName] = @firstName
				,[LastName] = @lastName
				,[Email] = @email
			WHERE 
				[UserName] = @userName
	END

END
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCourse]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteCourse]
	@CourseId int
AS
BEGIN
	
	Begin Tran
		Delete From [dbo].[Schedules] Where [CourseID] = @CourseId
		Delete From [dbo].[Subjects] Where [CourseID] = @CourseId
	COMMIT TRAN
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteInstructor]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteInstructor] 
	@InstructorId int
AS
BEGIN
	
	Begin Tran
		Delete From [dbo].[Schedules] Where [InstructorId] = @InstructorId
		Delete From [dbo].[Instructors] Where [InstructorId] = @InstructorId
	COMMIT TRAN
END
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteRoom]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[usp_DeleteRoom]
	@RoomNumber int
AS
BEGIN
	
	Begin Tran
		Delete From [dbo].[Schedules] Where [RoomNumber] = @RoomNumber
		Delete From [dbo].[Rooms] Where [RoomNumber] = @RoomNumber
	COMMIT TRAN
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCourseMap]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetCourseMap] 
	
AS
BEGIN
	SELECT 
		CM.[CRN]
		,ST.[SubjectName] AS [Subject]
		,S.[CourseId] AS [Course]
		,CM.[Section]
		,S.[MinCredits]
		,S.[MaxCredits]
		,S.[Title]
		,I.[FirstName] + ' ' + I.[MiddleName] + ' ' + I.[LastName] AS [Instructor]
		,CT.[CategoryName] AS [Category]
		,S.[SpecialApproval]
  FROM [dbo].[CourseMap] CM
  INNER JOIN [dbo].[Subjects] S ON S.[CourseId] = CM.[CourseID]
  INNER JOIN [dbo].[SubjectType] ST ON ST.[SubjectId] = S.[SubjectId]
  INNER JOIN [dbo].[CategoryType] CT ON CT.[CategoryId] = S.[CategoryId]
  INNER JOIN [dbo].[Instructors] I ON I.[InstructorId] = CM.[InstructorId]
  Order by CM.[CRN],ST.[SubjectName],S.[CourseId]
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetCourses]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetCourses] 
	
AS
BEGIN
	SELECT [CourseId]
      ,ST.[SubjectName] AS [Subject]
      ,CT.[CategoryName] AS [Category]
      ,[Title]
      ,[MinCredits]
      ,[MaxCredits]
      ,[SpecialApproval]
  FROM [dbo].[Subjects] S
  INNER JOIN [dbo].[SubjectType] ST on ST.[SubjectId] = S.[SubjectId]
  INNER JOIN [dbo].[CategoryType] CT ON CT.[CategoryId] = S.[CategoryId]
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Getenums]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_Getenums] 

AS
BEGIN
	SELECT 'Category' AS [Type]
      ,[CategoryName] AS [Value]
      ,[Description]
  FROM [Scheduler].[dbo].[CategoryType]
  UNION ALL
  SELECT 'Subject' AS [Type]
      ,[SubjectName] AS [Value]
      ,[Description]
  FROM [Scheduler].[dbo].[SubjectType]
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetHolidays]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetHolidays] 

AS
BEGIN
	
	SELECT	[HolidayID]
			,[Holiday]
			,[Description]
	FROM [dbo].[Holidays]
	Order by Holiday Desc

END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetInstructors]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetInstructors] 
	
AS
BEGIN
	SELECT [InstructorId]
      ,[FirstName]
	  ,[MiddleName]
      ,[LastName]
      ,[Email]
  FROM [Scheduler].[dbo].[Instructors]
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetRooms]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[usp_GetRooms] 
	
AS
BEGIN
	SELECT [RoomNumber]
      ,[Location]
      ,[Capacity]
      ,[Building]
  FROM [dbo].[Rooms]
	Order by RoomNumber
END









GO
/****** Object:  StoredProcedure [dbo].[usp_GetSchedules]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetSchedules] 
	
AS
BEGIN
	SELECT 
		 SC.[ScheduleId]
		,SC.[CRN]
		,ST.[SubjectName] AS [Subject]
		,S.[CourseId] AS [Course]
		,SC.[Section]
		,S.[Title]
		,CT.[CategoryName] AS [Category]
		,I.[FirstName] + ' ' + I.[MiddleName] + ' ' + I.[LastName] AS [Instructor]
		,SC.[Days]
		,FORMAT(CAST([StartTime] AS DATETIME),'hh:mm tt') + ' - ' + FORMAT(CAST([EndTime] AS DATETIME),'hh:mm tt') AS [Time]
		,SC.[StartDate]	
		,SC.[EndDate]
		,R.[Building]
		,R.[Location]
  FROM [dbo].[Schedules] SC
  INNER JOIN [dbo].[Subjects] S ON S.[CourseId] = SC.[CourseID]
  INNER JOIN [dbo].[SubjectType] ST ON ST.[SubjectId] = S.[SubjectId]
  INNER JOIN [dbo].[CategoryType] CT ON CT.[CategoryId] = S.[CategoryId]
  INNER JOIN [dbo].[Instructors] I ON I.[InstructorId] = SC.[InstructorId]
  INNER JOIN [dbo].[Rooms] R ON R.[RoomNumber] = SC.[RoomNumber]
  Order by SC.[CRN],ST.[SubjectName],S.[CourseId]
END







GO
/****** Object:  StoredProcedure [dbo].[usp_GetScheduleSearchOptions]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetScheduleSearchOptions] 
	
AS
BEGIN
	SELECT Distinct
		SC.[InstructorId]
		,I.[FirstName] + ' ' + I.[MiddleName] + ' ' + I.[LastName] AS [Instructor]
		,SC.[CourseID]
		,C.[Title]
		,[Section]
  FROM [dbo].[Schedules] SC
  INNER JOIN [dbo].[Instructors] I ON I.InstructorId = SC.InstructorId
  INNER JOIN [dbo].[Subjects] C on C.[CourseId] = SC.[CourseId]
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetUsers]    Script Date: 11/28/2017 5:59:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetUsers] 
	
AS
BEGIN
	SELECT [UserName]
		,[Password]
      ,[FirstName]
      ,[LastName]
      ,[Email]
	  ,[RoleName]
  FROM [dbo].[Users] U
  INNER JOIN [dbo].[Roles] R ON R.RoleId = U.RoleID
  WHERE U.Active = 1
END
GO
USE [master]
GO
ALTER DATABASE [Scheduler] SET  READ_WRITE 
GO


USE [Scheduler]
GO

INSERT INTO [dbo].[Roles]
           ([RoleName]
           ,[Description])
     VALUES
           ('Admin'
           ,'Admin')
GO




USE [Scheduler]
GO

INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
           ,[FirstName]
           ,[LastName]
           ,[Email]
           ,[RoleID]
           ,[Active])
     VALUES
           ('admin'
           ,'8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918'
           ,'Admin'
           ,''
           ,''
           ,1
           ,1)
GO