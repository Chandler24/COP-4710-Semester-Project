CREATE PROCEDURE [dbo].[DeleteComment]
	@Id int
AS
BEGIN
	UPDATE EventSocial
	SET IsDeleted = 1
	WHERE Id = @Id
END