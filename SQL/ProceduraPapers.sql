Use ISS
go
IF OBJECT_ID('ISS..PopulatePaperReservations') is not null DROP Procedure PopulatePaperReservations
go

--Populare tabela PaperReservations cu toate lucrarile acceptate de la o conferinta si cu ajutorul tabelei RoomReservations
Create Proc PopulatePaperReservations (@ConferenceId int,@Duration int)
As
BEGIN
	Begin Transaction insertPapers
	Begin Try
		--declare @ConferenceId int=1, @Duration int=15
		--Tabel temporar in care retin topicurile de la o conferinta
		Select t.TopicId, t.TopicName, S.SessionId 
		Into #TemporaryTopic
		From Topics t inner join Sessions S on t.TopicName=S.Topic
		Where t.ConferenceId=@ConferenceId;
		--Tabel temporar in care retin toate rezervarile camerelor de la o conferinta
		Select *, DATEDIFF(Minute,R.BeginDate,R.EndDate)-60 as Valabil 
		Into #TemporaryRoomsRes 
		From RoomReservations R 
		Where R.SessionId in (Select S.SessionId From Sessions S Where S.ConferenceId=@ConferenceId)
		--Tabel temporar in care retin id-urile lucrarilor acceptate la o conferinta si id-urile sesiunilor acestora
		Select P.PaperId,t.SessionId
		Into #TempPaper
		From Papers P inner join #TemporaryTopic t on P.TopicId=t.TopicId
	    Where P.ConferenceId=@ConferenceId and EvaluationResult='APPROVED'
		Drop table #TemporaryTopic
		--Parcurgem tabela temporara #TemporaryRoomsRes
		Declare @sessionID int, @roomResID int, @BeginDate datetime, @Valabil int, @BGTIME datetime, @paperId int
		Declare my_cursor Cursor For
		Select t.RoomReservationId,t.SessionId,t.BeginDate,t.Valabil
		From #TemporaryRoomsRes t
		OPEN my_cursor
		FETCH NEXT 
		FROM my_cursor
		INTO @roomResID,@sessionID,@BeginDate,@Valabil;
		While @@FETCH_STATUS=0
		BEGIN
			Set @BGTIME=Dateadd(Minute,5,@BeginDate)
			While @Valabil<>0
			Begin
				Set @paperId=(Select min(PaperId) from #TempPaper Where SessionId=@sessionID);
				If @paperId is not null
				Begin
					Set NOCOUNT on
					Insert into PaperReservations(RoomReservationId,PaperId,BeginTime,Duration)
						Values(@roomResID,@paperId,@BGTIME,@Duration);
					Set @BGTIME=DateAdd(Minute,@Duration,@BGTIME);
					Set @Valabil=@Valabil-@Duration;
					Delete From #TempPaper Where PaperId=@paperId;
				End
			End
			FETCH NEXT 
			FROM my_cursor
			INTO @roomResID,@sessionID,@BeginDate,@Valabil;
		End
		Close my_cursor
		Deallocate my_cursor
		Drop table #TemporaryRoomsRes
		Drop table #TempPaper
		Commit transaction
	End Try
	Begin Catch
		Raiserror('Error inserting in PaperReservations',16,1)
		Rollback transaction insertPapers	
	End Catch
	 BEGIN TRY
        --clean it up 
		Drop table #TemporaryTopic
	END TRY
	Begin Catch
	End Catch
	BEGIN TRY
		Drop table #TemporaryRoomsRes
	END TRY
	Begin Catch
	End Catch
	BEGIN TRY
		Drop table #TempPaper
	END TRY
	Begin Catch
	End Catch
	BEGIN TRY        
        Close my_cursor
		Deallocate my_cursor                               
    END TRY
    BEGIN CATCH
        --do nothing
    END CATCH
END
Go

