CREATE PROCEDURE [dbo].[AddMemberToRso]
@RsoId int,
@StudentEmail nvarchar(128),
@IsAdmin bit = 0
AS
BEGIN
	INSERT INTO RSO_Members(RSO_Id, StudentEmail, IsAdmin)
	VALUES (@RsoId, @StudentEmail, @IsAdmin)
END