CREATE PROCEDURE [dbo].[EditComment]
	@Id int,
	@EditedComment nvarchar(1024)
AS
BEGIN
	UPDATE EventSocial
	SET Comment = @EditedComment
	WHERE Id = @Id
END
