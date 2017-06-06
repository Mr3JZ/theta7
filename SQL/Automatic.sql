Use ISS
go
IF OBJECT_ID('ISS..automaticJob') is not null DROP Procedure automaticJob
go

CREATE PROCEDURE automaticJob
AS
	DECLARE @today DATETIME, @yesterday DATETIME
	-- this will be all taken from the current Conference from the conf_cursor.
	DECLARE @dlAbstract DATETIME, @dlCompletePaper DATETIME, @dlBidding DATETIME, @dlReviews DATETIME, @dlParticipation DATETIME
	DECLARE @confId int
	Declare @timpLucrare int
	SET @today = GETDATE()
	SET @yesterday = DATEADD(dd, -1, GETDATE())

	DECLARE conf_cursor CURSOR FOR
		SELECT ConferenceId FROM Conferences

	OPEN conf_cursor
		FETCH NEXT FROM conf_cursor INTO @confId

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @dlAbstract = (SELECT c.DeadlineAbstractPaper FROM Conferences c WHERE c.ConferenceId = @confId)
		SET @dlCompletePaper = (SELECT c.DeadlineCompletePaper FROM Conferences c WHERE c.ConferenceId = @confId)
		SET @dlBidding = (SELECT c.DeadlineBiddingPaper FROM Conferences c WHERE c.ConferenceId = @confId)
		SET @dlReviews = (SELECT c.DeadlineEvaluation FROM Conferences c WHERE c.ConferenceId = @confId)
		SET @dlParticipation = (SELECT c.DeadlineParticipation FROM Conferences c WHERE c.ConferenceId = @confId)

		IF ( @dlAbstract BETWEEN @yesterday AND @today)
		BEGIN
			PRINT 'HI'
		END
		IF ( @dlCompletePaper BETWEEN @yesterday AND @today)
		BEGIN
		PRINT 'HI'
		END
		IF ( @dlBidding BETWEEN @yesterday AND @today)
		BEGIN
			EXEC createReviewsFromBids @confId
		END
		IF ( @dlReviews BETWEEN @yesterday AND @today)
		BEGIN
			EXEC collectingReviews @confId
			Exec @timpLucrare=PopulateRoomReservations @confId
			Exec PopulatePaperReservations @confId, @timpLucrare
		END
		IF ( @dlParticipation BETWEEN @yesterday AND @today)
		BEGIN
		PRINT 'HI'
		END
		FETCH NEXT FROM conf_cursor INTO @confId
	END

	CLOSE conf_cursor
	DEALLOCATE conf_cursor
GO
