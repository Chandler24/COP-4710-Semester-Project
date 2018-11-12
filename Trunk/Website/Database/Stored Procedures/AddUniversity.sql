CREATE PROCEDURE [dbo].[AddUniversity]
	@Name nvarchar(128),
	@PrimaryAddress nvarchar(256),
	@SecondaryAddress nvarchar(256) = null,
	@City nvarchar(32),
	@State nvarchar(16),
	@Zip nvarchar(16),
	@NumberOfStudents int,
	@Description nvarchar(max)
AS
BEGIN
	INSERT INTO Universities(Name, Address1, Address2, City, [State], Zip, NumberOfStudents, [Description])
	VALUES (@Name, @PrimaryAddress, @SecondaryAddress, @City, @State, @Zip, @NumberOfStudents, @Description)
END