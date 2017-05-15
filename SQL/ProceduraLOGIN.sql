Use ISS
go
IF OBJECT_ID('ISS..ValidateLogin') is not null DROP Procedure ValidateLogin
go

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
			