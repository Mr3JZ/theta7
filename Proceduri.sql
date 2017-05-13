USE ISS
Go
IF OBJECT_ID('ISS..uspInsertPayments') is not null DROP Procedure uspInsertPayments
IF OBJECT_ID('ISS..uspInsertAdditionalAuthors') is not null DROP Procedure uspInsertAdditionalAuthors
IF OBJECT_ID('ISS..uspInsertPapers') is not null DROP Procedure uspInsertPapers
IF OBJECT_ID('ISS..uspInsertBid') is not null DROP Procedure uspInsertBid
IF OBJECT_ID('ISS..createConference') is not null DROP Procedure createConference
IF OBJECT_ID('ISS..createConferenceTopic ') is not null DROP Procedure createConferenceTopic 
IF OBJECT_ID('ISS..createAvailableRoom') is not null DROP Procedure createAvailableRoom
IF OBJECT_ID('ISS..insertUser') is not null DROP Procedure insertUser
IF OBJECT_ID('ISS..createPCMember') is not null DROP Procedure createPCMember
Go

--!!!! Validarile lungimilor stringurilor se vor face in UI, cat si validari precum 
-- si topicul unei lucrari sa apartina conferintei la care este inregistrata lucrarea


-- Creates a new conference. The root table of the application, the most relevant one.
-- It does not depend on any tables, but there are quite a few tables that depend upon this one.
-- Thus, handle with care.
-- Return the id of the Conference
CREATE PROCEDURE createConference @Name nvarchar(50),
           @Edition nvarchar(20),
           @BeginDate datetime,
           @EndDate datetime,
           @City nvarchar(50),
           @Country nvarchar(50),
           @Website nvarchar(50),
           @Price int,
           @DeadlineAbstractPaper datetime,
           @DeadlineCompletePaper datetime,
           @DeadlineBiddingPaper datetime,
           @DeadlineEvaluation datetime,
           @DeadlineParticipation datetime
AS

BEGIN TRY
	BEGIN TRANSACTION createConference
		INSERT INTO Conferences
			(
			Name,
            Edition,
            BeginDate,
            EndDate,
            City,
            Country,
            Website,
            Price,
            DeadlineAbstractPaper,
            DeadlineCompletePaper,
            DeadlineBiddingPaper,
            DeadlineEvaluation,
            DeadlineParticipation
			)
		 VALUES
			(
			@Name,
			@Edition,
			@BeginDate,
			@EndDate,
			@City,
			@Country,
			@Website,
			@Price,
			@DeadlineAbstractPaper,
			@DeadlineCompletePaper,
			@DeadlineBiddingPaper,
			@DeadlineEvaluation,
			@DeadlineParticipation
			)
	COMMIT TRANSACTION createConference
END TRY
BEGIN CATCH
  RAISERROR('Cannot create conference, error occured', 16, 1)
	ROLLBACK TRANSACTION createConference
END CATCH

DECLARE @value int;
SET @value = IDENT_CURRENT('Conferences')
RETURN @value

GO

--Insereaza in tabelul Payments si apoi in ConferenceParticipants
--Are nevoie de id-ul userului, id-ul conferintei si de datele specifice tabelei Payments
--Suma platita, numarul biletelor cumparate, Data si ora la care s-a facut plata si daca tranzactia s-a efectuat cu succes(True/False)
--Returneaza id-ul conferintei adaugate
Create Proc uspInsertPayments(@userId int, @conferenceId int, @paidSum float, @NrTickets int,
								 @Date DateTime, @Successfull bit) 
As
BEGIN
	Begin transaction
	Begin try
		Declare @PayId int=0;
		Insert into Payments(PaymentDate,NrOfTickets,PaidSum,SuccessfulTransaction) Values(@Date,@NrTickets,@paidSum,@Successfull);
		Set @PayId=(Select MAX(P.PaymentId) From Payments P)
		Insert into ConferenceParticipants(UserId,ConferenceId,PaymentId) Values(@userId,@conferenceId,@PayId);
	Commit transaction
	Return @PayId
	End Try
	Begin Catch
		Rollback transaction
		Raiserror ('Error inserting the payment and the participation of the user to the conference',16,1);
	End Catch
END
Go

--Insereaza in tabelul AdditionalAuthors
--Are nevoie de numele autorului, afilierea acestuia si id-ul lucrarii la care contribuie
Create proc uspInsertAdditionalAuthors(@Name NVarchar(50), @Affiliation NVarchar(50), @paperId int)As
BEGIN
	Begin Try
		Insert into AdditionalAuthors(Name,Affiliation,PaperId) Values(@Name,@Affiliation,@paperId);
	End Try
	Begin Catch
		Raiserror ('Error inserting the additional Author of the paper',16,1);
	End Catch
End
Go

--Insereaza in tabelul Papers
--Are nevoie de id-ul userului, id-ul conferintei si de datele specifice tabelei Papers
--Numele lucrarii, rezumatul ei, domeniul si subdomeniul, filepath-ul unde este salvata lucrarea 
--si topicul ei(string) ce apartine de conferinta (se face verificarea in ui)
--Returneaza id-ul lucrarii adaugate
Create proc uspInsertPapers(@userId int, @conferenceId int, @Name Nvarchar(100), @Resume Nvarchar(500), @Domain Nvarchar(30), 
						@Subdomain Nvarchar(30), @filePath Nvarchar(240), @topic Nvarchar(50))
AS
BEGIN
	Begin try
		Declare @TopicId int=0, @paperId int=0;
		Set @TopicId=(Select t.TopicId From Topics T Where t.TopicName=@topic and t.ConferenceId=@conferenceId)
		Insert into Papers(Name,Resume,Domain,Subdomain,Filepath,ConferenceId,UserId,TopicId)
				Values(@Name,@Resume,@Domain,@Subdomain,@filePath,@conferenceId,@userId,@TopicId);
		Set @paperId=(Select max(p.PaperId) from Papers p)
		Return @paperId
	End Try
	Begin Catch
		Raiserror ('Error inserting the paper',16,1);
	End Catch
END
Go

--Insereaza in tabelul Bids
--Are nevoie de id-ul PCMember-ului, id-ul conferintei, id-ul lucrarii pentru care face licitarea si evaluarea acestei licitari
--Evaluarea este un int corespunzator enumararii din modelul obiectual(Status)
Create proc uspInsertBid(@PCMemberId int, @conferenceId int, @paperId int, @evaluation int) As
BEGIN
	Begin try
		Insert into Bids(PCMemberUserId,PCMemberConferenceId,PaperId,BiddingEvaluation)
			Values (@PCMemberId, @conferenceId, @paperId, @evaluation);
	End try
	Begin Catch
		Raiserror ('Error inserting the bid',16,1);
	End Catch
End
Go

-- Create a topic for an existing conference
-- Usually, these are created immediatly after the conference itself.
-- 1 Topic = 1 Session
CREATE PROCEDURE createConferenceTopic @ConferenceId int, @TopicName nvarchar(50)
AS

BEGIN TRY
	BEGIN TRANSACTION createConferenceTopicTran
		INSERT INTO Topics(ConferenceId, TopicName) VALUES (@ConferenceId, @TopicName)
	COMMIT TRANSACTION createConferenceTopicTran
END TRY
BEGIN CATCH
	RAISERROR('Cannot add conference topic, error occured', 16, 1)
	ROLLBACK TRANSACTION createConferenceTopicTran
END CATCH

GO

-- Takes an existing user and a conference, and creates a PC member with certain powers
-- isChair is he's chair, isCoChair if he's coChair.
CREATE PROCEDURE createPCMember @UserId int, @ConferenceId int,
								@isChair bit, @isCoChair bit
AS

BEGIN TRY
	BEGIN TRANSACTION createPCMember
		INSERT INTO PCMembers(UserId, ConferenceId, isChair, isCoChair) VALUES(@UserId, @ConferenceId, @isChair, @isCoChair)
	COMMIT TRANSACTION createPCMember
END TRY
BEGIN CATCH
	RAISERROR('Cannot create PCMember from user, error occured', 16, 1)
	ROLLBACK TRANSACTION createPCMember
END CATCH

GO

-- Executes the user insertion within a stored procedure, to catch and cancel the possible errors that might occur.
CREATE PROCEDURE insertUser @Username nvarchar(20), @Name nvarchar(50),
							@Password nvarchar(50), @Email nvarchar(50),
							@Affiliation nvarchar(50), @WebPage nvarchar(50)
AS

BEGIN TRY
	BEGIN TRANSACTION userInsertion
		INSERT INTO Users(Username, Name, Password, Email, Affilliation, WebPage, canBePCMember) VALUES(@Username, @Name, @Password, @Email, @Affiliation, @WebPage, 0)
	COMMIT TRANSACTION userInsertion
END TRY
BEGIN CATCH
  RAISERROR('Cannot insert user, error occured', 16, 1)
	ROLLBACK TRANSACTION userInsertion
END CATCH

DECLARE @value int;
SET @value = IDENT_CURRENT('Users')
RETURN @value

GO

-- Creates a new available room.
-- It also inserts an address, and using that address it creates an available room
-- with additional options, such as Capacity, begin and end date.
CREATE PROCEDURE createAvailableRoom @Street nvarchar(30), @City nvarchar(30),
																   	 @PostalCode nvarchar(30), @ConferenceId int,
																		 @RoomName nvarchar(50), @Capacity int,
																		 @BeginDate datetime, @EndDate datetime
AS

BEGIN TRY
	BEGIN TRANSACTION createAvailableRoom
		INSERT INTO Addresses(Street, City, PostalCode) VALUES(@Street, @City, @PostalCode)
		DECLARE @AddressId int = 0;
		SET @AddressId = IDENT_CURRENT('Addresses')
		INSERT INTO AvailableRooms(ConferenceId, AddressId, RoomName, Capacity, BeginDate, EndDate)
			VALUES(@ConferenceId, @AddressId, @RoomName, @Capacity, @BeginDate, @EndDate)
	COMMIT TRANSACTION createAvailableRoom
END TRY
BEGIN CATCH
	RAISERROR('Cannot create available room, error occured', 16, 1)
	ROLLBACK TRANSACTION createAvailableRoom
END CATCH

GO


