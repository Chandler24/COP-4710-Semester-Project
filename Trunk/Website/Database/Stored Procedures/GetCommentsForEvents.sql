CREATE PROCEDURE [dbo].[GetCommentsForEvents]
	@EventId int
AS
BEGIN
	SELECT u.FirstName, u.LastName, e.Comment, e.Id FROM EventSocial e
	INNER JOIN Users u 
	ON u.Id = e.UserId
	WHERE EventId = @EventId
END