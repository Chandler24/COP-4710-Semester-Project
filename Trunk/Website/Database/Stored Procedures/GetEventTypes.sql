CREATE PROCEDURE [dbo].[GetEventTypes]
AS
BEGIN
	SELECT Id, [Description] FROM EventType
END