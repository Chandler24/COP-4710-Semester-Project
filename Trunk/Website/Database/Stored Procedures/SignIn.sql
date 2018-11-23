CREATE PROCEDURE [dbo].[SignIn]
	@Username nvarchar(128)
AS
BEGIN
	SELECT [Password], Id, UserType FROM Users where Username = @Username
END