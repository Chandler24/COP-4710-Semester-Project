CREATE PROCEDURE [dbo].[GetAllUniversities]
AS
BEGIN
	SELECT	Id,
			City,
			[Description],
			Name,
			NumberOfStudents,
			Address1,
			Address2,
			[State],
			Zip
	FROM	Universities
END