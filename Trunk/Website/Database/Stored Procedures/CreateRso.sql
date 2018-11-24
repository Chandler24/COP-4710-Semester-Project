CREATE PROCEDURE [dbo].[CreateRso]
	@Name nvarchar(128),
	@Description nvarchar(128)
AS
INSERT INTO RegisteredStudentOrganizations (Name, [Description])
VALUES (@Name, @Description)