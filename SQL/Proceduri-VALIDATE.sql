Use ISS
go
IF OBJECT_ID('ISS..ValidateLogin') is not null DROP Procedure ValidateLogin
IF OBJECT_ID('ISS..ValidateUsernameUnique') is not null DROP Procedure ValidateUsernameUnique
go

--Verifica daca datele pentru login sunt corecte
--Daca da, returneaza id-ul userului(unic si singur datorita faptului ca username e unique)
--Altfel returneaza NULL
Create Procedure ValidateLogin(@username Nvarchar(30), @password Nvarchar(50)) 
AS
BEGIN
	Begin try
		Declare @idUser int=(Select UserId from Users Where Username=@username and Password=@password);
		return @idUser;
	End Try
	Begin Catch
	End Catch
END
Go

--Verifica daca username-ul ce se doreste inregistrat(intrare noua) se mai afla deja in tabela Users
--Daca exista un astfel de username returneaza 0(FALSE-NU SE POATE INSERA CU ACEST USERNAME) 
--Altfel returneaza 1 (TRUE - SE POATE INSERA CU ACEST USERNAME)
Create procedure ValidateUsernameUnique (@username Nvarchar(30))
AS
BEGIN
	Declare @NameValidate int=(Select UserId from Users Where Username=@username);
	if @NameValidate is NULL
		return 1
	Else
		return 0
END
Go
