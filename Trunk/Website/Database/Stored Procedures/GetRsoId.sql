CREATE PROCEDURE [dbo].[GetRsoId]
	@RsoName nvarchar(128)
AS
BEGIN
	SELECT Id FROM RegisteredStudentOrganizations WHERE Name = @RsoName
END