CREATE PROCEDURE [dbo].[GetEvents]
AS
BEGIN
	SELECT	e.Id, 
			e.Name, 
			e.[DateTime], 
			e.[Description], 
			ISNULL(
				(SUM(es.Rating) / COUNT(es.Rating)) 
			, 0)
			as EventRating
	FROM [Events] e
	LEFT JOIN EventSocial es
	ON e.Id = es.EventId
	GROUP BY e.Id, e.Name, e.[DateTime], e.[Description]
END