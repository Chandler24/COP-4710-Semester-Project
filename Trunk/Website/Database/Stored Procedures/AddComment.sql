CREATE PROCEDURE [dbo].[AddComment]
	@UserId int,
	@EventId int,
	@Comment nvarchar(1024)
AS
BEGIN
	INSERT INTO EventSocial(EventId, UserId, Comment)
	VALUES (@EventId, @UserId, @Comment)
END