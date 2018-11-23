CREATE PROCEDURE [dbo].[JoinRso]
	@UserId int,
	@RsoId int
AS
BEGIN
	DECLARE @Username NVARCHAR(128) 
	SET @Username = (SELECT Username from Users where Id = @UserId)

	INSERT INTO RSO_Members(RSO_Id, StudentEmail)
	VALUES (@RsoId, @Username)
END
