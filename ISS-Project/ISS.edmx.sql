
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/02/2017 18:03:22
-- Generated from EDMX file: C:\Users\Denis\documents\visual studio 2015\Projects\ISS-Project\ISS-Project\ISS.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ISS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ConferenceParticipantsPayments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConferenceParticipants] DROP CONSTRAINT [FK_ConferenceParticipantsPayments];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizingComiteesUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizingComiteeMembers] DROP CONSTRAINT [FK_OrganizingComiteesUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizingComiteesConferences]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizingComiteeMembers] DROP CONSTRAINT [FK_OrganizingComiteesConferences];
GO
IF OBJECT_ID(N'[dbo].[FK_ReviewsOrganizingComitees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_ReviewsOrganizingComitees];
GO
IF OBJECT_ID(N'[dbo].[FK_ReviewsPapers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_ReviewsPapers];
GO
IF OBJECT_ID(N'[dbo].[FK_PaperTagPaper]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaperTags] DROP CONSTRAINT [FK_PaperTagPaper];
GO
IF OBJECT_ID(N'[dbo].[FK_PaperReservationRoomReservation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaperReservations] DROP CONSTRAINT [FK_PaperReservationRoomReservation];
GO
IF OBJECT_ID(N'[dbo].[FK_PaperReservationPaper]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaperReservations] DROP CONSTRAINT [FK_PaperReservationPaper];
GO
IF OBJECT_ID(N'[dbo].[FK_TagPaperTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaperTags] DROP CONSTRAINT [FK_TagPaperTag];
GO
IF OBJECT_ID(N'[dbo].[FK_PaperConference]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Papers] DROP CONSTRAINT [FK_PaperConference];
GO
IF OBJECT_ID(N'[dbo].[FK_PaperUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Papers] DROP CONSTRAINT [FK_PaperUser];
GO
IF OBJECT_ID(N'[dbo].[FK_TopicConference]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Topics] DROP CONSTRAINT [FK_TopicConference];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK_RoomAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_SectionConference]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sections] DROP CONSTRAINT [FK_SectionConference];
GO
IF OBJECT_ID(N'[dbo].[FK_ConferenceParticipantUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConferenceParticipants] DROP CONSTRAINT [FK_ConferenceParticipantUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ConferenceParticipantConference]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConferenceParticipants] DROP CONSTRAINT [FK_ConferenceParticipantConference];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomReservationRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomReservations] DROP CONSTRAINT [FK_RoomReservationRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_RoomReservationSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoomReservations] DROP CONSTRAINT [FK_RoomReservationSection];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizingComiteeMemberSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sections] DROP CONSTRAINT [FK_OrganizingComiteeMemberSection];
GO
IF OBJECT_ID(N'[dbo].[FK_PaperAdditionalAuthor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdditionalAuthors] DROP CONSTRAINT [FK_PaperAdditionalAuthor];
GO
IF OBJECT_ID(N'[dbo].[FK_BidOrganizingComiteeMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [FK_BidOrganizingComiteeMember];
GO
IF OBJECT_ID(N'[dbo].[FK_PaperBid]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [FK_PaperBid];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Conferences]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Conferences];
GO
IF OBJECT_ID(N'[dbo].[Topics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Topics];
GO
IF OBJECT_ID(N'[dbo].[Payments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payments];
GO
IF OBJECT_ID(N'[dbo].[ConferenceParticipants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConferenceParticipants];
GO
IF OBJECT_ID(N'[dbo].[Papers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Papers];
GO
IF OBJECT_ID(N'[dbo].[OrganizingComiteeMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizingComiteeMembers];
GO
IF OBJECT_ID(N'[dbo].[Reviews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reviews];
GO
IF OBJECT_ID(N'[dbo].[AdditionalAuthors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdditionalAuthors];
GO
IF OBJECT_ID(N'[dbo].[Tags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tags];
GO
IF OBJECT_ID(N'[dbo].[PaperTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaperTags];
GO
IF OBJECT_ID(N'[dbo].[Sections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sections];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO
IF OBJECT_ID(N'[dbo].[RoomReservations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoomReservations];
GO
IF OBJECT_ID(N'[dbo].[PaperReservations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaperReservations];
GO
IF OBJECT_ID(N'[dbo].[Bids]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bids];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Username] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [WebPage] nvarchar(max)  NULL,
    [Affilliation] nvarchar(max)  NOT NULL,
    [IsPCMember] bit  NOT NULL,
    [PapersPaperId] int  NOT NULL
);
GO

-- Creating table 'Conferences'
CREATE TABLE [dbo].[Conferences] (
    [ConferenceId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [BeginDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Website] nvarchar(max)  NULL,
    [Price] int  NOT NULL,
    [DeadlineAbstractPaper] datetime  NOT NULL,
    [DeadlineCompletePaper] datetime  NOT NULL,
    [DeadlineEvaluation] datetime  NOT NULL,
    [DeadlineParticipation] datetime  NOT NULL,
    [Section_sectionId] int  NOT NULL
);
GO

-- Creating table 'Topics'
CREATE TABLE [dbo].[Topics] (
    [TopicName] nvarchar(max)  NOT NULL,
    [ConferenceConferenceId] int  NOT NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [PaymentId] int IDENTITY(1,1) NOT NULL,
    [PaymentDate] datetime  NOT NULL,
    [NrOfTickets] int  NOT NULL,
    [SuccessfulTransaction] bit  NOT NULL
);
GO

-- Creating table 'ConferenceParticipants'
CREATE TABLE [dbo].[ConferenceParticipants] (
    [UserUsername] nvarchar(max)  NOT NULL,
    [ConferenceConferenceId] int  NOT NULL,
    [Payment_PaymentId] int  NOT NULL
);
GO

-- Creating table 'Papers'
CREATE TABLE [dbo].[Papers] (
    [PaperId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Resume] nvarchar(max)  NOT NULL,
    [Domain] nvarchar(max)  NOT NULL,
    [Subdomain] nvarchar(max)  NOT NULL,
    [Filepath] nvarchar(max)  NOT NULL,
    [EvaluationResult] nvarchar(max)  NULL,
    [IsEmailSent] bit  NOT NULL,
    [ConferenceConferenceId] int  NOT NULL,
    [UserUsername] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrganizingComiteeMembers'
CREATE TABLE [dbo].[OrganizingComiteeMembers] (
    [isChair] bit  NOT NULL,
    [UserUsername] nvarchar(max)  NOT NULL,
    [ConferenceConferenceId] int  NOT NULL
);
GO

-- Creating table 'Reviews'
CREATE TABLE [dbo].[Reviews] (
    [PapersPaperId] int  NOT NULL,
    [OrganizingComiteeMemberUserUsername] nvarchar(max)  NOT NULL,
    [OrganizingComiteeMemberConferenceConferenceId] int  NOT NULL,
    [Evaluation] nvarchar(max)  NOT NULL,
    [Recommandations] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AdditionalAuthors'
CREATE TABLE [dbo].[AdditionalAuthors] (
    [AdditionalAuthorId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Affiliation] nvarchar(max)  NOT NULL,
    [PaperPaperId] int  NOT NULL
);
GO

-- Creating table 'Tags'
CREATE TABLE [dbo].[Tags] (
    [TagId] int IDENTITY(1,1) NOT NULL,
    [TagName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PaperTags'
CREATE TABLE [dbo].[PaperTags] (
    [PaperPaperId] int  NOT NULL,
    [TagTagId] int  NOT NULL
);
GO

-- Creating table 'Sections'
CREATE TABLE [dbo].[Sections] (
    [SectionId] int IDENTITY(1,1) NOT NULL,
    [ConferenceConferenceId] int  NOT NULL,
    [OrganizingComiteeMemberUserUsername] nvarchar(max)  NOT NULL,
    [OrganizingComiteeMemberConferenceConferenceId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressId] int IDENTITY(1,1) NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [PostalCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [RoomId] int IDENTITY(1,1) NOT NULL,
    [RoomName] nvarchar(max)  NOT NULL,
    [Capacity] nvarchar(max)  NOT NULL,
    [AddressAddressId] int  NOT NULL
);
GO

-- Creating table 'RoomReservations'
CREATE TABLE [dbo].[RoomReservations] (
    [RoomReservationId] int IDENTITY(1,1) NOT NULL,
    [SectionSectionId] int  NOT NULL,
    [RoomRoomId] int  NOT NULL,
    [BeginTime] time  NOT NULL,
    [EndTime] time  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'PaperReservations'
CREATE TABLE [dbo].[PaperReservations] (
    [RoomReservation_roomReservationId] int  NOT NULL,
    [PaperPaperId] int  NOT NULL,
    [BeginTime] nvarchar(max)  NOT NULL,
    [Duration] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bids'
CREATE TABLE [dbo].[Bids] (
    [PaperPaperId] int  NOT NULL,
    [OrganizingComiteeMemberUserUsername] nvarchar(max)  NOT NULL,
    [OrganizingComiteeMemberConferenceConferenceId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Username] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Username] ASC);
GO

-- Creating primary key on [ConferenceId] in table 'Conferences'
ALTER TABLE [dbo].[Conferences]
ADD CONSTRAINT [PK_Conferences]
    PRIMARY KEY CLUSTERED ([ConferenceId] ASC);
GO

-- Creating primary key on [ConferenceConferenceId], [TopicName] in table 'Topics'
ALTER TABLE [dbo].[Topics]
ADD CONSTRAINT [PK_Topics]
    PRIMARY KEY CLUSTERED ([ConferenceConferenceId], [TopicName] ASC);
GO

-- Creating primary key on [PaymentId] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([PaymentId] ASC);
GO

-- Creating primary key on [UserUsername], [ConferenceConferenceId] in table 'ConferenceParticipants'
ALTER TABLE [dbo].[ConferenceParticipants]
ADD CONSTRAINT [PK_ConferenceParticipants]
    PRIMARY KEY CLUSTERED ([UserUsername], [ConferenceConferenceId] ASC);
GO

-- Creating primary key on [PaperId] in table 'Papers'
ALTER TABLE [dbo].[Papers]
ADD CONSTRAINT [PK_Papers]
    PRIMARY KEY CLUSTERED ([PaperId] ASC);
GO

-- Creating primary key on [UserUsername], [ConferenceConferenceId] in table 'OrganizingComiteeMembers'
ALTER TABLE [dbo].[OrganizingComiteeMembers]
ADD CONSTRAINT [PK_OrganizingComiteeMembers]
    PRIMARY KEY CLUSTERED ([UserUsername], [ConferenceConferenceId] ASC);
GO

-- Creating primary key on [PapersPaperId], [OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [PK_Reviews]
    PRIMARY KEY CLUSTERED ([PapersPaperId], [OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId] ASC);
GO

-- Creating primary key on [AdditionalAuthorId] in table 'AdditionalAuthors'
ALTER TABLE [dbo].[AdditionalAuthors]
ADD CONSTRAINT [PK_AdditionalAuthors]
    PRIMARY KEY CLUSTERED ([AdditionalAuthorId] ASC);
GO

-- Creating primary key on [TagId] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [PK_Tags]
    PRIMARY KEY CLUSTERED ([TagId] ASC);
GO

-- Creating primary key on [PaperPaperId], [TagTagId] in table 'PaperTags'
ALTER TABLE [dbo].[PaperTags]
ADD CONSTRAINT [PK_PaperTags]
    PRIMARY KEY CLUSTERED ([PaperPaperId], [TagTagId] ASC);
GO

-- Creating primary key on [SectionId] in table 'Sections'
ALTER TABLE [dbo].[Sections]
ADD CONSTRAINT [PK_Sections]
    PRIMARY KEY CLUSTERED ([SectionId] ASC);
GO

-- Creating primary key on [AddressId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressId] ASC);
GO

-- Creating primary key on [RoomId] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([RoomId] ASC);
GO

-- Creating primary key on [RoomReservationId] in table 'RoomReservations'
ALTER TABLE [dbo].[RoomReservations]
ADD CONSTRAINT [PK_RoomReservations]
    PRIMARY KEY CLUSTERED ([RoomReservationId] ASC);
GO

-- Creating primary key on [RoomReservation_roomReservationId], [PaperPaperId] in table 'PaperReservations'
ALTER TABLE [dbo].[PaperReservations]
ADD CONSTRAINT [PK_PaperReservations]
    PRIMARY KEY CLUSTERED ([RoomReservation_roomReservationId], [PaperPaperId] ASC);
GO

-- Creating primary key on [PaperPaperId], [OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId] in table 'Bids'
ALTER TABLE [dbo].[Bids]
ADD CONSTRAINT [PK_Bids]
    PRIMARY KEY CLUSTERED ([PaperPaperId], [OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Payment_PaymentId] in table 'ConferenceParticipants'
ALTER TABLE [dbo].[ConferenceParticipants]
ADD CONSTRAINT [FK_ConferenceParticipantsPayments]
    FOREIGN KEY ([Payment_PaymentId])
    REFERENCES [dbo].[Payments]
        ([PaymentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConferenceParticipantsPayments'
CREATE INDEX [IX_FK_ConferenceParticipantsPayments]
ON [dbo].[ConferenceParticipants]
    ([Payment_PaymentId]);
GO

-- Creating foreign key on [PapersPaperId] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_ReviewsPapers]
    FOREIGN KEY ([PapersPaperId])
    REFERENCES [dbo].[Papers]
        ([PaperId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PaperPaperId] in table 'PaperTags'
ALTER TABLE [dbo].[PaperTags]
ADD CONSTRAINT [FK_PaperTagPaper]
    FOREIGN KEY ([PaperPaperId])
    REFERENCES [dbo].[Papers]
        ([PaperId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoomReservation_roomReservationId] in table 'PaperReservations'
ALTER TABLE [dbo].[PaperReservations]
ADD CONSTRAINT [FK_PaperReservationRoomReservation]
    FOREIGN KEY ([RoomReservation_roomReservationId])
    REFERENCES [dbo].[RoomReservations]
        ([RoomReservationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PaperPaperId] in table 'PaperReservations'
ALTER TABLE [dbo].[PaperReservations]
ADD CONSTRAINT [FK_PaperReservationPaper]
    FOREIGN KEY ([PaperPaperId])
    REFERENCES [dbo].[Papers]
        ([PaperId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaperReservationPaper'
CREATE INDEX [IX_FK_PaperReservationPaper]
ON [dbo].[PaperReservations]
    ([PaperPaperId]);
GO

-- Creating foreign key on [TagTagId] in table 'PaperTags'
ALTER TABLE [dbo].[PaperTags]
ADD CONSTRAINT [FK_TagPaperTag]
    FOREIGN KEY ([TagTagId])
    REFERENCES [dbo].[Tags]
        ([TagId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TagPaperTag'
CREATE INDEX [IX_FK_TagPaperTag]
ON [dbo].[PaperTags]
    ([TagTagId]);
GO

-- Creating foreign key on [ConferenceConferenceId] in table 'Papers'
ALTER TABLE [dbo].[Papers]
ADD CONSTRAINT [FK_PaperConference]
    FOREIGN KEY ([ConferenceConferenceId])
    REFERENCES [dbo].[Conferences]
        ([ConferenceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaperConference'
CREATE INDEX [IX_FK_PaperConference]
ON [dbo].[Papers]
    ([ConferenceConferenceId]);
GO

-- Creating foreign key on [UserUsername] in table 'Papers'
ALTER TABLE [dbo].[Papers]
ADD CONSTRAINT [FK_PaperUser]
    FOREIGN KEY ([UserUsername])
    REFERENCES [dbo].[Users]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaperUser'
CREATE INDEX [IX_FK_PaperUser]
ON [dbo].[Papers]
    ([UserUsername]);
GO

-- Creating foreign key on [ConferenceConferenceId] in table 'Topics'
ALTER TABLE [dbo].[Topics]
ADD CONSTRAINT [FK_TopicConference]
    FOREIGN KEY ([ConferenceConferenceId])
    REFERENCES [dbo].[Conferences]
        ([ConferenceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AddressAddressId] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_RoomAddress]
    FOREIGN KEY ([AddressAddressId])
    REFERENCES [dbo].[Addresses]
        ([AddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomAddress'
CREATE INDEX [IX_FK_RoomAddress]
ON [dbo].[Rooms]
    ([AddressAddressId]);
GO

-- Creating foreign key on [ConferenceConferenceId] in table 'Sections'
ALTER TABLE [dbo].[Sections]
ADD CONSTRAINT [FK_SectionConference]
    FOREIGN KEY ([ConferenceConferenceId])
    REFERENCES [dbo].[Conferences]
        ([ConferenceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SectionConference'
CREATE INDEX [IX_FK_SectionConference]
ON [dbo].[Sections]
    ([ConferenceConferenceId]);
GO

-- Creating foreign key on [UserUsername] in table 'ConferenceParticipants'
ALTER TABLE [dbo].[ConferenceParticipants]
ADD CONSTRAINT [FK_ConferenceParticipantUser]
    FOREIGN KEY ([UserUsername])
    REFERENCES [dbo].[Users]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ConferenceConferenceId] in table 'ConferenceParticipants'
ALTER TABLE [dbo].[ConferenceParticipants]
ADD CONSTRAINT [FK_ConferenceParticipantConference]
    FOREIGN KEY ([ConferenceConferenceId])
    REFERENCES [dbo].[Conferences]
        ([ConferenceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConferenceParticipantConference'
CREATE INDEX [IX_FK_ConferenceParticipantConference]
ON [dbo].[ConferenceParticipants]
    ([ConferenceConferenceId]);
GO

-- Creating foreign key on [RoomRoomId] in table 'RoomReservations'
ALTER TABLE [dbo].[RoomReservations]
ADD CONSTRAINT [FK_RoomReservationRoom]
    FOREIGN KEY ([RoomRoomId])
    REFERENCES [dbo].[Rooms]
        ([RoomId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomReservationRoom'
CREATE INDEX [IX_FK_RoomReservationRoom]
ON [dbo].[RoomReservations]
    ([RoomRoomId]);
GO

-- Creating foreign key on [SectionSectionId] in table 'RoomReservations'
ALTER TABLE [dbo].[RoomReservations]
ADD CONSTRAINT [FK_RoomReservationSection]
    FOREIGN KEY ([SectionSectionId])
    REFERENCES [dbo].[Sections]
        ([SectionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoomReservationSection'
CREATE INDEX [IX_FK_RoomReservationSection]
ON [dbo].[RoomReservations]
    ([SectionSectionId]);
GO

-- Creating foreign key on [PaperPaperId] in table 'AdditionalAuthors'
ALTER TABLE [dbo].[AdditionalAuthors]
ADD CONSTRAINT [FK_PaperAdditionalAuthor]
    FOREIGN KEY ([PaperPaperId])
    REFERENCES [dbo].[Papers]
        ([PaperId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaperAdditionalAuthor'
CREATE INDEX [IX_FK_PaperAdditionalAuthor]
ON [dbo].[AdditionalAuthors]
    ([PaperPaperId]);
GO

-- Creating foreign key on [PaperPaperId] in table 'Bids'
ALTER TABLE [dbo].[Bids]
ADD CONSTRAINT [FK_PaperBid]
    FOREIGN KEY ([PaperPaperId])
    REFERENCES [dbo].[Papers]
        ([PaperId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserUsername] in table 'OrganizingComiteeMembers'
ALTER TABLE [dbo].[OrganizingComiteeMembers]
ADD CONSTRAINT [FK_OrganizingComiteeMemberUser]
    FOREIGN KEY ([UserUsername])
    REFERENCES [dbo].[Users]
        ([Username])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ConferenceConferenceId] in table 'OrganizingComiteeMembers'
ALTER TABLE [dbo].[OrganizingComiteeMembers]
ADD CONSTRAINT [FK_OrganizingComiteeMemberConference]
    FOREIGN KEY ([ConferenceConferenceId])
    REFERENCES [dbo].[Conferences]
        ([ConferenceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizingComiteeMemberConference'
CREATE INDEX [IX_FK_OrganizingComiteeMemberConference]
ON [dbo].[OrganizingComiteeMembers]
    ([ConferenceConferenceId]);
GO

-- Creating foreign key on [OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId] in table 'Bids'
ALTER TABLE [dbo].[Bids]
ADD CONSTRAINT [FK_BidOrganizingComiteeMember]
    FOREIGN KEY ([OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId])
    REFERENCES [dbo].[OrganizingComiteeMembers]
        ([UserUsername], [ConferenceConferenceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BidOrganizingComiteeMember'
CREATE INDEX [IX_FK_BidOrganizingComiteeMember]
ON [dbo].[Bids]
    ([OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId]);
GO

-- Creating foreign key on [OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_ReviewOrganizingComiteeMember]
    FOREIGN KEY ([OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId])
    REFERENCES [dbo].[OrganizingComiteeMembers]
        ([UserUsername], [ConferenceConferenceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReviewOrganizingComiteeMember'
CREATE INDEX [IX_FK_ReviewOrganizingComiteeMember]
ON [dbo].[Reviews]
    ([OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId]);
GO

-- Creating foreign key on [OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId] in table 'Sections'
ALTER TABLE [dbo].[Sections]
ADD CONSTRAINT [FK_OrganizingComiteeMemberSection]
    FOREIGN KEY ([OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId])
    REFERENCES [dbo].[OrganizingComiteeMembers]
        ([UserUsername], [ConferenceConferenceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizingComiteeMemberSection'
CREATE INDEX [IX_FK_OrganizingComiteeMemberSection]
ON [dbo].[Sections]
    ([OrganizingComiteeMemberUserUsername], [OrganizingComiteeMemberConferenceConferenceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------