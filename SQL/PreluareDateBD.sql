Use ISS
IF OBJECT_ID('ISS..getUsers') is not null Drop View getUsers
IF OBJECT_ID('ISS..getPossiblePCMembers') is not null Drop View getPossiblePCMembers
IF OBJECT_ID('ISS..getConferences') is not null Drop View getConferences
IF OBJECT_ID('ISS..getMessagesAll') is not null Drop View getMessagesAll

IF OBJECT_ID('ISS..getTopicsFor1Conference') is not null Drop Function getTopicsFor1Conference
IF OBJECT_ID('ISS..getSessionsForConference') is not null Drop Function getSessionsForConference
IF OBJECT_ID('ISS..getParticpantsConference') is not null Drop Function getParticpantsConference
IF OBJECT_ID('ISS..getPCMembersConference') is not null Drop Function getPCMembersConference
IF OBJECT_ID('ISS..getPayment') is not null Drop Function getPayment
IF OBJECT_ID('ISS..getPapersConference') is not null Drop Function getPapersConference
IF OBJECT_ID('ISS..getAdditionalAuthors') is not null Drop Function getAdditionalAuthors
IF OBJECT_ID('ISS..getBidsResult') is not null Drop Function getBidsResult
IF OBJECT_ID('ISS..getReviewsPaper') is not null Drop Function getReviewsPaper
IF OBJECT_ID('ISS..getMessagesUser') is not null Drop Function getMessagesUser
IF OBJECT_ID('ISS..getReviewsPcMember') is not null Drop Function getReviewsPcMember
IF OBJECT_ID('ISS..getReservationPaper') is not null Drop Function getReservationPaper
IF OBJECT_ID('ISS..getPapersSession') is not null Drop Function getPapersSession

Go

--Preia toate datele utilizatorilor
--Ordine : userId, username, name ,password, email, affilliation, webPage, canBePcMember
Create View getUsers
As
	Select * from Users
Go

--Preia toate mesajele din baza de date
-- daca aveti nevoie
--Ordine: messageId, id-ul userului care primeste mesajul, corpul mesajului
Create View getMessagesAll
As
	Select *
	From MessagesC
Go

--Preia toate mesajele transmise unui utilizator
Create function getMessagesUser(@idUser int)
Returns Table
As
	Return (Select m.MessageId, m.MessageBody
		From MessagesC m
		Where m.UserId=@idUser)
Go


--Preia toate conferintele cu toate datele acesteia
--in diagrama de clasa este lista de participanti, sesiuni si topicuri,
-- acestea se vor prelua folosind functii ce returneaza pt o conferinta toti participantii/toate sesiunile..
--Datele sunt de tipul DateTime
--Ordine: ConferendeId, Name, Edition, BeginDate, EndDate, city, country, website, price,
--	deadlineAbstractPaper, deadlineCompletePaper, deadlineBidding, deadlineEvaluation(pt Review),deadlineParticipation
Create View getConferences
As
	Select *
	From Conferences
Go

--Pentru o conferinta returneaza toate topicurile ei(stringuri)
--Cere id-ul conferintei
Create function getTopicsFor1Conference(@idConference int)
Returns Table
As
	Return(Select t.TopicName
	From Topics t
	Where t.ConferenceId=@idConference)
Go

--Ia sesiunile pt o conferinta, mai exact numele sesiunii si sessionChair
--Cere id-ul conferintei
Create function getSessionsForConference(@idConference int)
Returns Table
As
	Return(Select S.SessionId,S.Name, S.SessionChairId
		From Sessions S
		Where S.ConferenceId=@idConference)
Go

--Returneaza id-urile userilor ce participa la o conferinta
-- ca si participanti 'normali'(nu pcMemberi) [acestia au platit ca sa participe la conferinta]
Create function getParticpantsConference(@idConference int)
Returns Table
As
	Return(Select cp.UserId
		From ConferenceParticipants cp 
		Where cp.ConferenceId=@idConference)
Go


--Returneaza id-urile PcMembers de la o conferinta, impreuna cu rolurile acestora
Create function getPCMembersConference(@idConference int)
Returns Table
As
	Return (Select pc.UserId,pc.isChair,pc.isCoChair
		From PCMembers pc
		Where pc.ConferenceId=@idConference)
Go


--Preia din Users acei utilizatori ce ai atributul canBePCMember=1
--Acestia pot fi PcMembers pt o conferinta
--Ordine : la fel ca la getUsers
Create View getPossiblePCMembers
As
	Select *
	From Users
	Where canBePCMember=1
Go

--Returneaza un payment pt un participant(user) la o conferinta
--Cere id-ul userului si id-ul conferintei
--Ordine: paymentId, paymentDate(dateTime), NrofTickets, paidSum, SuccessfulTransaction
Create function getPayment(@idUser int, @idConference int)
Returns Table
As
	Return (Select p.PaymentId,p.PaymentDate,p.NrOfTickets,p.PaidSum,p.SuccessfulTransaction
	From Payments p inner join ConferenceParticipants cp on p.PaymentId=cp.PaymentId
	Where cp.UserId=@idUser and cp.ConferenceId=@idConference)
Go

--Returneaza lucrarile de la o conferinta
--name(titlu in aplicatie),filepath(string), UserId(int - sa spuneti daca vreti toate atributele userului...
										--desi o sa iasa un select luuung)
Create Function getPapersConference(@idConference int)
Returns Table
As
	Return(Select p.PaperId,p.Name, p.Resume, p.Domain, p.Subdomain, p.Filepath, p.EvaluationResult,
		p.IsEmailSent,p.UserId
	From Papers p
	Where p.ConferenceId=@idConference)
Go

--Returneaza autorii ce au contribuit la o lucrare
create function getAdditionalAuthors(@idPaper int)
Returns Table
As
	Return(Select a.Name, a.Affiliation
		From AdditionalAuthors a
		Where a.PaperId=@idPaper)
Go

--Pentru o lucrare returneaza rezultatele acesteia de la Bidding
--Forma: idUser si rezultatul
create function getBidsResult(@idPaper int)
Returns Table
As
	Return (Select b.PCMemberUserId, b.BiddingEvaluation
		From Bids b
		Where b.PaperId=@idPaper)
Go

--Pentru o lucrare returneaza Reviewurile acesteia
--In Bd se va pastra in Evaluation valoarea int asociata enumerarii Verdict din aplicatie
Create function getReviewsPaper(@idPaper int)
Returns Table
As
	Return (Select r.PCMemberUserId, r.Evaluation, r.Recommandations
	From Reviews r
	Where r.PaperId=@idPaper)
Go

--Retuneaza pt un PCMember id-urile lucrarilor pe care trebuie sa le evalueaze la o conferinta
Create function getReviewsPcMember(@idPcMember int, @idConference int)
Returns Table
As
	Return(Select r.PaperId
		From Reviews r
		Where r.PCMemberUserId=@idPcMember and r.PCMemberConferenceId=@idConference)
Go

--Rezervarea unei lucrari [primeste id-ul lucrarii)
--Returneaza id-ul sesiunii la care face parte
--Numele camerei, strada, orasul si codul postal->in aplicatie se concateneaza intr-un string
--Data, ora si durata prezentarii
Create Function getReservationPaper(@idPaper int)
Returns Table
As
	Return( Select S.SessionId,A.RoomName, Ad.Street, Ad.City, Ad.PostalCode, CONVERT(date,p.BeginTime) as Data,
	 Convert(time,p.BeginTime) as Timp, p.Duration
		From PaperReservations p inner join RoomReservations RR ON P.RoomReservationId=RR.RoomId
		Inner Join Sessions S on S.SessionId=RR.SessionId Inner Join AvailableRooms A on A.RoomId=RR.RoomId
		Inner Join Addresses Ad on A.AddressId=Ad.AddressId
		Where p.PaperId=@idPaper)
Go


--Returneaza toate lucrarile de la o sesiune
Create Function getPapersSession(@idSession int)
Returns Table
As
	Return(Select p.PaperId,p.Name, p.Resume, p.Domain, p.Subdomain, p.Filepath, p.EvaluationResult,
		p.IsEmailSent,p.UserId, t.TopicName, pr.RoomReservationId, pr.BeginTime, pr.Duration
	From Sessions s inner join RoomReservations r on s.SessionId=r.SessionId inner join
	PaperReservations pr on r.RoomReservationId=pr.RoomReservationId inner join
	Papers p on pr.PaperId=p.PaperId inner join Topics t on p.TopicId=t.TopicId
	Where s.SessionId=@idSession)
Go