Use ISS
go
IF OBJECT_ID('ISS..collectingReviews') is not null DROP Procedure collectingReviews
IF OBJECT_ID('ISS..createReviewsFromBids') is not null DROP Procedure createReviewsFromBids
IF OBJECT_ID('ISS..sessionCreation') is not null DROP Procedure sessionCreation
go


CREATE PROCEDURE collectingReviews @ConferenceId int
AS
	DECLARE @paperId int, @reviewId int, @reviewCount int, @reviewAvg float
	DECLARE paper_cursor CURSOR FOR
		SELECT p.PaperId FROM Papers p WHERE p.ConferenceId = @ConferenceId

	OPEN paper_cursor
	FETCH NEXT FROM paper_cursor INTO @paperId

	--iteram prin lucrari
	WHILE @@FETCH_STATUS = 0
	BEGIN
		--cate reviewuri avem pt lucrarea curent
		SET @reviewCount = (SELECT COUNT(*) FROM Reviews r WHERE r.PaperId = @paperId)
		IF(@reviewCount = 0)
			BEGIN
				--daca e 0, inseamna ca nu avem reviewuri (lucrarea nu a fost aprobata), get out.
				FETCH NEXT FROM paper_cursor INTO @paperId
				CONTINUE;
			END
		ELSE
			BEGIN
				--this is where the magic BEGINS
				-- daca media reviewurile e peste 2.5, atunci APPROVED. Altfel, rejected.
				-- nu conteaza cate review-uri sunt, doar media lor sa fie peste!!
				SET @reviewAvg = (SELECT AVG(r.Evaluation) FROM Reviews r WHERE r.PaperId = @paperId )
				IF(@reviewAvg > 2.5)
					BEGIN
						UPDATE Papers SET EvaluationResult = 'APPROVED' WHERE PaperId = @paperId
					END
				ELSE
					BEGIN
						UPDATE Papers SET EvaluationResult = 'REJECTED' WHERE PaperId = @paperId
					END
			END
		FETCH NEXT FROM paper_cursor INTO @paperId
	END

	CLOSE paper_cursor
	DEALLOCATE paper_cursor

GO

----------------------------------------------------------------------------------------------------------------

	CREATE PROCEDURE createReviewsFromBids @ConferenceId int
	AS
		-- temp id for user that are going to be choosen for reviews.
		DECLARE @tempUserId int
		DECLARE @tempConfId int

		DECLARE @paperId int
		DECLARE @bidCount int
		DECLARE @bidAvg float
		DECLARE @random float

		DECLARE paper_cursor CURSOR FOR
			SELECT p.PaperId FROM Papers p WHERE ConferenceId = @ConferenceId

		OPEN paper_cursor
		FETCH NEXT FROM paper_cursor INTO @paperId

		WHILE @@FETCH_STATUS = 0
				BEGIN
					--biduri per lucrarea curenta.
					SET @bidCount = (SELECT COUNT(*) FROM Bids b WHERE b.PaperId = @paperId)

					IF @bidCount = 0
							BEGIN
								--cazul in care nu exista deloc bids
								DECLARE no_bids CURSOR FOR
									SELECT TOP 3 p.UserId, p.ConferenceId FROM PCMembers p WHERE p.ConferenceId = @ConferenceId ORDER BY NEWID()
								OPEN no_bids
								FETCH NEXT FROM no_bids INTO @tempUserId, @tempConfId
								WHILE @@FETCH_STATUS = 0
									BEGIN
										INSERT INTO Reviews(PCMemberUserId, PCMemberConferenceId, PaperId, Evaluation, Recommandations)
											VALUES (@tempUserId, @tempConfId, @paperId, 0, '')
										FETCH NEXT FROM no_bids INTO @tempUserId, @tempConfId
									END
								CLOSE no_bids
								DEALLOCATE no_bids
							FETCH NEXT FROM paper_cursor INTO @paperId
							CONTINUE;
							END
					ELSE
						BEGIN
							SET @random = (RAND())
							IF (@random < 0.4)
								-- 2 inserturi aka 2 reviews
								BEGIN
									DECLARE rev_2 CURSOR FOR
										SELECT TOP 2 b.PCMemberUserId, b.PCMemberConferenceId FROM Bids b WHERE b.BiddingEvaluation >=1 ORDER BY b.BiddingEvaluation DESC
									OPEN rev_2
									FETCH NEXT FROM rev_2 INTO @tempUserId, @tempConfId
									WHILE @@FETCH_STATUS = 0
										BEGIN
											INSERT INTO Reviews(PCMemberUserId, PCMemberConferenceId, PaperId, Evaluation, Recommandations)
												VALUES (@tempUserId, @tempConfId, @paperId, 0, '')
											FETCH NEXT FROM rev_2 INTO @tempUserId, @tempConfId
										END
									-- cleanup.
									CLOSE rev_2
									DEALLOCATE rev_2
								END
							ELSE IF (@random < 0.7 AND @random > 0.4)
								BEGIN
								-- 3 reviews
									DECLARE rev_3 CURSOR FOR
										SELECT TOP 3 b.PCMemberUserId, b.PCMemberConferenceId FROM Bids b WHERE b.BiddingEvaluation >=1 ORDER BY b.BiddingEvaluation DESC
									OPEN rev_3
									FETCH NEXT FROM rev_3 INTO @tempUserId, @tempConfId
									WHILE @@FETCH_STATUS = 0
										BEGIN
											INSERT INTO Reviews(PCMemberUserId, PCMemberConferenceId, PaperId, Evaluation, Recommandations)
												VALUES (@tempUserId, @tempConfId, @paperId, 0, '')
											FETCH NEXT FROM rev_3 INTO @tempUserId, @tempConfId
										END
									-- cleanup.
									CLOSE rev_3
									DEALLOCATE rev_3
								END
							ELSE
								BEGIN
								-- 4 reviews.
									DECLARE rev_4 CURSOR FOR
										SELECT TOP 4 b.PCMemberUserId, b.PCMemberConferenceId FROM Bids b WHERE b.BiddingEvaluation >=1 ORDER BY b.BiddingEvaluation DESC
									OPEN rev_4
									FETCH NEXT FROM rev_4 INTO @tempUserId, @tempConfId
									WHILE @@FETCH_STATUS = 0
										BEGIN
											INSERT INTO Reviews(PCMemberUserId, PCMemberConferenceId, PaperId, Evaluation, Recommandations)
												VALUES (@tempUserId, @tempConfId, @paperId, 0, '')
											FETCH NEXT FROM rev_4 INTO @tempUserId, @tempConfId
										END
									-- cleanup.
									CLOSE rev_4
									DEALLOCATE rev_4
								END
						END
					FETCH NEXT FROM paper_cursor INTO @paperId
				END
				--finally closing all the papers, hooray.
				CLOSE paper_cursor
				DEALLOCATE paper_cursor

	GO

-------------------------------------------------------------------------------------------------------

CREATE PROCEDURE sessionCreation @ConferenceId int
AS
	DECLARE @topicId int

	--cursorul care itereaza prin topicurile unei conferinte
	DECLARE topic_cursor CURSOR FOR
		SELECT t.TopicId FROM Topics t WHERE t.ConferenceId = @ConferenceId

	OPEN topic_cursor
		FETCH NEXT FROM topic_cursor INTO @topicId

	WHILE @@FETCH_STATUS = 0
	BEGIN
		DECLARE @newUserId int, @newConfId int
		DECLARE @topicName nvarchar(50)
		SET @topicName = (SELECT TOP 1 TopicName FROM Topics WHERE TopicId = @topicId)
		SELECT TOP 1 @newUserId = pc.UserId, @newConfId = pc.ConferenceId
			-- selectul din from e pt pcmemberi
			-- iar pe PCMembers ii luam daca id-ul lor nu apare in lista de paperuri
			-- la topicul respectiv si la conferinta respectiva.
			FROM (SELECT * FROM PCMembers p WHERE p.UserId IN
					( SELECT userId FROM Papers WHERE TopicId <> @topicId AND ConferenceId = @ConferenceId)
					) pc ORDER BY NEWID()
		--this is to pick one random eligible PCMember.
		INSERT INTO Sessions(ConferenceId, SessionChairId, PCMemberConferenceId, Name, Topic)
			VALUES(@ConferenceId, @newUserId, @newConfId, @topicName, @topicName)
		FETCH NEXT FROM topic_cursor INTO @topicId
	END

	CLOSE topic_cursor
	DEALLOCATE topic_cursor
GO