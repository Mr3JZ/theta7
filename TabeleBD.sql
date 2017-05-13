
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/29/2017 16:44:39
-- Generated from EDMX file: C:\Users\Denis\documents\visual studio 2015\Projects\ISS-Project\ISS-Project\ISS.edmx
-- --------------------------------------------------

USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='ISS')
	DROP DATABASE ISS
CREATE DATABASE ISS
GO
USE ISS

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------
IF OBJECT_ID('FK__PaperRese__Paper__3C34F16F') IS NOT NULL
	ALTER TABLE PaperReservations Drop Constraint FK__PaperRese__Paper__3C34F16F
IF OBJECT_ID(N'[dbo].[ConferenceParticipants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConferenceParticipants];
GO
IF OBJECT_ID(N'[dbo].[Bids]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bids];
GO
IF OBJECT_ID(N'[dbo].[Reviews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reviews];
GO
IF OBJECT_ID(N'[dbo].[AdditionalAuthors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdditionalAuthors];
GO
IF OBJECT_ID(N'[dbo].[PaperReservations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaperReservations];
GO
IF OBJECT_ID(N'[dbo].[RoomReservations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomReservations];
GO
IF OBJECT_ID(N'[dbo].[Papers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Papers];
GO
IF OBJECT_ID(N'[dbo].[Sessions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sessions];
GO
IF OBJECT_ID(N'[dbo].[PCMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PCMembers];
GO
IF OBJECT_ID(N'[dbo].[Topics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Topics];
GO
IF OBJECT_ID(N'[dbo].[AvailableRooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AvailableRooms];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Payments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payments];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Conferences]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Conferences];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
	[UserId] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Username] nvarchar(20)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Affilliation] nvarchar(100)  NOT NULL,
	[WebPage] nvarchar(50)  NULL,
    [canBePCMember] bit  NOT NULL,
);
GO

-- Creating table 'Conferences'
CREATE TABLE [dbo].[Conferences] (
    [ConferenceId] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
	[Edition] nvarchar(20),
    [BeginDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [City] nvarchar(50)  NOT NULL,
    [Country] nvarchar(50)  NOT NULL,
    [Website] nvarchar(50)  NULL,
    [Price] int  NOT NULL,
    [DeadlineAbstractPaper] datetime  NOT NULL,
    [DeadlineCompletePaper] datetime  NOT NULL,
	[DeadlineBiddingPaper] datetime NOT NULL,
    [DeadlineEvaluation] datetime  NOT NULL,
    [DeadlineParticipation] datetime  NOT NULL
);
GO

-- Creating table 'Topics'
CREATE TABLE [dbo].[Topics] (
	[TopicId] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [TopicName] nvarchar(50)  NOT NULL,
    [ConferenceId] int Foreign Key References Conferences(ConferenceId) NOT NULL,
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [PaymentId] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [PaymentDate] datetime  NOT NULL,
    [NrOfTickets] int  NOT NULL,
	[PaidSum] int NOT NULL,
    [SuccessfulTransaction] bit  NOT NULL
);
GO

-- Creating table 'ConferenceParticipants'
CREATE TABLE [dbo].[ConferenceParticipants] (
    [UserId] int Foreign Key References Users(UserId)  NOT NULL,
    [ConferenceId] int FOREIGN KEY REFERENCES Conferences(ConferenceId)  NOT NULL,
    [PaymentId] int  FOREIGN KEY REFERENCES Payments(PaymentId) NOT NULL,
	PRIMARY KEY(UserId, ConferenceId, PaymentId)
);
GO

-- Creating table 'Papers'
CREATE TABLE [dbo].[Papers] (
    [PaperId] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Resume] nvarchar(500)  NOT NULL,
    [Domain] nvarchar(30)  NOT NULL,
    [Subdomain] nvarchar(30)  NOT NULL,
    [Filepath] nvarchar(240)  NOT NULL,
    [EvaluationResult] nvarchar(50)  NULL,
    [IsEmailSent] bit  NOT NULL,
    [ConferenceId] int FOREIGN KEY REFERENCES Conferences(ConferenceId)  NOT NULL,
    [UserId] int FOREIGN KEY REFERENCES Users(UserId) NOT NULL,
	[TopicId] int FOREIGN KEY REFERENCES Topics(TopicId) NOT NULL
);
GO

-- Creating table '[PCMembers]'
CREATE TABLE [dbo].[PCMembers] (
	[UserId] int FOREIGN KEY REFERENCES Users(UserId) NOT NULL,
	[ConferenceId] int FOREIGN KEY REFERENCES Conferences(ConferenceId)  NOT NULL,
    [isChair] bit  NOT NULL,
	[isCoChair] bit Not Null,
	Primary Key (UserId, ConferenceId)
);
GO

-- Creating table 'Reviews'
CREATE TABLE [dbo].[Reviews] (
    [PCMemberUserId] int  NOT NULL,
    [PCMemberConferenceId] int NOT NULL,
	[PaperId] int FOREIGN KEY REFERENCES Papers(PaperId)  NOT NULL,
    [Evaluation] nvarchar(40) NULL,
    [Recommandations] nvarchar(200) NULL,
	Foreign Key ([PCMemberUserId], [PCMemberConferenceId]) REFERENCES PcMembers(UserId, ConferenceId),
	PRIMARY KEY([PCMemberUserId], [PCMemberConferenceId], [PaperId])
);
GO

-- Creating table 'AdditionalAuthors'
CREATE TABLE [dbo].[AdditionalAuthors] (
    [AdditionalAuthorId] int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Affiliation] nvarchar(50)  NOT NULL,
    [PaperId] int FOREIGN KEY REFERENCES Papers(PaperId)  NOT NULL
);
GO

-- Creating table 'Sessions'
CREATE TABLE [dbo].[Sessions] (
    [SessionId] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [ConferenceId] int FOREIGN KEY REFERENCES Conferences(ConferenceId) NOT NULL,
    [Name] nvarchar(60)  NOT NULL,
	[Topic] nvarchar(50) Not NULL,
	[SessionChairId] int  NOT NULL,
    [PCMemberConferenceId] int NOT NULL,
	Foreign Key ([SessionChairId], [PCMemberConferenceId]) REFERENCES PcMembers(UserId, ConferenceId)
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressId] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [Street] nvarchar(30)  NOT NULL,
    [City] nvarchar(30)  NOT NULL,
    [PostalCode] nvarchar(30)  NOT NULL
);
GO


-- Creating table 'AvailableRooms', this is just a helper for the future trigger.
CREATE TABLE [dbo].[AvailableRooms] (
	[RoomId]  int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[ConferenceId] int FOREIGN KEY REFERENCES Conferences(ConferenceId) NOT NULL,
	[RoomName] nvarchar(50)  NOT NULL,
    [Capacity] int NOT NULL,
    [AddressId] int FOREIGN KEY REFERENCES Addresses(AddressId) NOT NULL,
	[BeginDate] datetime NOT NULL,
	[EndDate] datetime NOT NULL
);
GO

-- Creating table 'RoomReservations'
CREATE TABLE [dbo].[RoomReservations] (
    [RoomReservationId] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [SessionId] int FOREIGN KEY REFERENCES Sessions(SessionId)  NOT NULL,	
    [RoomId] int FOREIGN KEY REFERENCES AvailableRooms(RoomId) NOT NULL,
	[BeginDate] datetime NOT NULL,
	[EndDate] datetime NOT NULL	
);
GO

-- Creating table 'PaperReservations'
CREATE TABLE [dbo].[PaperReservations] (
	[PaperReservationId] int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    [RoomReservationId] int FOREIGN KEY REFERENCES RoomReservations(RoomReservationId) NULL,
    [PaperId] int UNIQUE FOREIGN KEY REFERENCES Papers(PaperId) NOT NULL,
    [BeginTime] datetime  NULL,
    [Duration] int DEFAULT '15' NOT NULL
);
GO

-- Creating table 'Bids'
CREATE TABLE [dbo].[Bids] (
	[PCMemberUserId] int  NOT NULL,
    [PCMemberConferenceId] int NOT NULL,
    [PaperId] int FOREIGN KEY REFERENCES Papers(PaperId) NOT NULL,
    [BiddingEvaluation] int  NOT NULL,
	Foreign Key ([PCMemberUserId], [PCMemberConferenceId]) REFERENCES PcMembers(UserId, ConferenceId),
	PRIMARY KEY(PcMemberUserId, [PCMemberConferenceId], PaperId)
);
GO
