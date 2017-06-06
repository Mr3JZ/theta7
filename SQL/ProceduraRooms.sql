Use ISS
go
IF OBJECT_ID('ISS..PopulateRoomReservations') is not null DROP Procedure PopulateRoomReservations
go

--Populare tabela RoomReservations pe baza tabelei AvailableRooms si a numarului de lucrari acceptate la o conferinta
Create Proc PopulateRoomReservations (@ConferenceId int)
As
BEGIN
Begin Transaction insertRooms
	Begin Try
		--Declare @ConferenceId int=1
		Declare @topic int, @NrPaper int, @timp int
		--Creez un tabel temporar in care salvez id-ul topicurilor unei conferinte
		-- cu numarul de lucrari acceptate pt fiecare topic si timpul total pentru prezentarea lor
		Create table tempTopic (id int primary key identity(1,1), TopicId int, NrPapers int, Timp int)
		Set NOCOUNT on
		Insert into tempTopic(TopicId,NrPapers,Timp)
		SELECT P.TopicId, Count(P.PaperId), (Count(P.PaperId)*15) as Timp
		FROM Papers P
		Where P.EvaluationResult='APPROVED' and P.ConferenceId=@ConferenceId
		Group by P.TopicId
		Order by Timp Desc
		--Select * from tempTopic
		--Creez un tabel temporar in care salvez id-ul camerei valabile, data de incepere si de sfarsit
		--diferenta in ore si capacitatea camerei
		Create table tempRooms(idTemp int primary key Identity(1,1), RoomId int, BeginDate datetime, EndDate datetime, Valability int, Capacity int)
		Declare @BGDate datetime, @EDate datetime, @roomId int, @capacity int, @TempDate DateTime
		Declare my_cursor Cursor For
		Select AR.RoomId, AR.BeginDate,AR.EndDate, AR.Capacity 
		From AvailableRooms AR
		Where AR.ConferenceId=@ConferenceId
		OPEN my_cursor
		FETCH NEXT 
		FROM my_cursor
		INTO @roomId,@BGDate,@EDate,@capacity;
		While @@FETCH_STATUS=0
			Begin
				while Convert(Date,@BGDate)<>Convert(Date,@EDate)
					Begin
						Set @TempDate=cast(Convert(Date,@BGDate) as datetime)+cast('19:00 PM' as datetime)
						Set NOCOUNT on
						Insert into tempRooms(RoomId,BeginDate,EndDate,Capacity) 
							Values(@roomId,@BGDate,@TempDate,@capacity);
						Update tempRooms
						Set Valability=DateDiff(MINUTE,BeginDate,EndDate)
						Where idTemp=IDENT_CURRENT('tempRooms')
						Set @BGDate=DATEADD(day,1,@BGDate);
						Set @BGDate=cast(Convert(Date,@BGDate) as datetime)+cast('9:00 AM' as datetime)
					End
				Insert into tempRooms(RoomId,BeginDate,EndDate,Capacity) 
							Values(@roomId,@BGDate,@EDate,@capacity);
				Update tempRooms
				Set Valability=DateDiff(Minute,BeginDate,EndDate)
				Where idTemp=IDENT_CURRENT('tempRooms')
				FETCH NEXT
				FROM my_cursor
				INTO @roomId,@BGDate,@EDate,@capacity
			End
		Close my_cursor
		Deallocate my_cursor
		--Verific daca timpul total al lucrarilor e mai mic decat timpul total alocat conferintei
		--Daca nu, modific timpul de vorbire pt o lucrare(il scad)
		Declare @timpLucrare int=15, @sumaLucrari int, @sumaCamere int, @nrLucrari int
		Set @nrLucrari=(Select Sum(NrPapers) from tempTopic)
		Set @sumaLucrari=(Select Sum(Timp) from tempTopic)
		Set @sumaCamere=(Select Sum(Valability) from tempRooms)-IDENT_CURRENT('tempRooms')*60
		While @sumaLucrari>@sumaCamere
			Begin
				Set @timpLucrare=@timpLucrare-1
				Set @sumaLucrari=@nrLucrari*@timpLucrare
			End
		--Refacem tabela tempTopic cu noile valori daca timpul pentru o lucrare s-a modificat
		If @timpLucrare<>15
			Begin
				Delete from tempTopic
				Insert into tempTopic(TopicId,NrPapers,Timp)
				SELECT P.TopicId, Count(P.PaperId), (Count(P.PaperId)*@timpLucrare) as Timp
				FROM Papers P
				Where P.EvaluationResult='APPROVED' and P.ConferenceId=@ConferenceId
				Group by P.TopicId
				Order by Timp desc
			End;		
		--parcurgem randurile din tabela tempTopic si populam tabela RoomReservations
		Declare MYcursor Cursor For
		Select TopicId,NrPapers,Timp from tempTopic
		OPEN MYcursor
		FETCH NEXT 
		FROM MYcursor
		INTO @topic,@NrPaper,@timp;
		While @@FETCH_STATUS=0
			BEGIN
				While @NrPaper<>0
					Begin
						Declare @RRId int, @BDate datetime, @REDate datetime
						Declare @cap int=(Select max(Capacity) from tempRooms)
						Declare @valMax int=(select Max(Valability) from tempRooms where Capacity=@cap), @ID int
						Declare @topicChar Nvarchar(50)=(Select S.Topic from Sessions S inner join Topics t on S.Topic=t.TopicName Where t.ConferenceId=@ConferenceId and t.TopicId=@topic)
						Declare @sessionId int=(Select SessionId from Sessions S Where S.Topic=@topicChar)
						If @timp>@valMax
						Begin 
							Set @ID=(select min(idTemp) from tempRooms where Valability=@valMax and Capacity=@cap)
							Select @RRId=t.RoomId, @BDate=t.BeginDate, @REDate=t.EndDate 
							From tempRooms t
							Where t.idTemp=@ID
							Set NOCOUNT on
							Insert into RoomReservations(SessionId,RoomId,BeginDate,EndDate)
								Values(@sessionId,@RRId,@BDate,@REDate);
							set @NrPaper=@NrPaper-(@valMax-60)/(@timp/@NrPaper)
							set @timp=@timp-@valMax+60
							Delete from tempRooms where idTemp=@ID
						End
						Else
						Begin
							Set @cap=(Select max(Capacity) from tempRooms)
							Declare @Val int=(Select Min(tr.Valability) from tempRooms tr where tr.Valability>@timp and tr.Capacity=@cap)
							Set @ID=(Select min(tr.idTemp) From tempRooms tr Where tr.Valability=@Val and tr.Capacity=@cap)
							Select @RRId=t.RoomId, @BDate=t.BeginDate, @REDate=t.EndDate 
							From tempRooms t
							Where t.idTemp=@ID
							If @timp+60=DateDiff(Minute,@BDate,@REDate)
								Begin
									Set NOCOUNT on
									Insert into RoomReservations(SessionId,RoomId,BeginDate,EndDate)
										Values(@sessionId,@RRId,@BDate,@REDate);
									Delete from tempRooms where idTemp=@ID;
									set @NrPaper=0;
								End
							Else
								Begin
									Set @timp=@timp+60
									Declare @sfarsit time=DateAdd(Minute,@timp,Convert(Time,@BDate))
									Set @REdate=cast(Convert(Date,@REDate) as datetime)+cast(@sfarsit as datetime)
									Set NOCOUNT on
									Insert into RoomReservations(SessionId,RoomId,BeginDate,EndDate)
										Values(@sessionId,@RRId,@BDate,@REDate);
									Update tempRooms
									Set BeginDate=@REDate
									where idTemp=@ID;
									Update tempRooms
									Set Valability=DATEDIFF(Minute,BeginDate,EndDate)
									where idTemp=@ID;
									set @NrPaper=0;
								End
						End
					End
				FETCH NEXT
				FROM MYcursor
				INTO @topic,@NrPaper,@timp;
			END
		Close MYcursor
		Deallocate MYcursor
		Drop table tempTopic
		Drop table tempRooms
		Commit transaction insertRooms
		return @timpLucrare
	End Try
	Begin Catch
		Raiserror('Error inserting in RoomReservations',16,1)
		Rollback transaction insertRooms	
	End Catch
	 BEGIN TRY
        --clean it up 
		Drop table tempTopic
	END TRY
	Begin Catch
	End Catch
	BEGIN TRY
		Drop table tempRooms
	END TRY
	Begin Catch
	End Catch
	BEGIN TRY
		Close my_cursor
		Deallocate my_cursor 
	END TRY
	Begin Catch
	End Catch
	BEGIN TRY        
        Close MYcursor
		Deallocate MYcursor                                 
    END TRY
    BEGIN CATCH
        --do nothing
    END CATCH
END
Go

