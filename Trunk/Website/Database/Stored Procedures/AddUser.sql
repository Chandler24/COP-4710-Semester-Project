CREATE PROCEDURE [dbo].[AddUser]
	@FirstName NVARCHAR(32),
	@LastName NVARCHAR(32),
	@Username NVARCHAR(64),
	@Password NVARCHAR(32),
	@UserType INT
AS
BEGIN
	INSERT INTO Users (FirstName, LastName, Username, Password, UserType)
	VALUES(@FirstName, @LastName, @Username, @Password, @UserType)
END