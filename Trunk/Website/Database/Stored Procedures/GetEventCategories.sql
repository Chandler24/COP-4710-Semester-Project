CREATE PROCEDURE [dbo].[GetEventCategories]
AS
BEGIN
	SELECT	Id,
			[Name]
	FROM	EventCategory
END