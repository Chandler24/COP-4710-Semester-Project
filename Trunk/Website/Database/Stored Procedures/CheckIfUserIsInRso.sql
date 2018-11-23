CREATE PROCEDURE [dbo].[CheckIfUserIsInRso]
@UserId int,
@RsoId int
AS
BEGIN
	SELECT Username FROM Users u
	INNER JOIN 
	RSO_Members rso 
	ON rso.StudentEmail = u.Username 
	WHERE u.Id = @UserId AND rso.RSO_Id = @RsoId
END