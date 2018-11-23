CREATE PROCEDURE [dbo].[GetAllRsos]
AS
BEGIN
	SELECT Id, Name, [Description] FROM RegisteredStudentOrganizations
END