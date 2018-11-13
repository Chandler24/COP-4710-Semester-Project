CREATE PROCEDURE [dbo].[SaveEvent]
	@Name nvarchar(128),
	@Type int,
	@Category int,
	@Description nvarchar(128),
	@Date datetime,
	@Location int,
	@ContactPhone nvarchar(128),
	@ContactEmail nvarchar(128),
	@EventAdmin int,
	@HostUniversity int
AS
BEGIN
	INSERT INTO [Events] (Name, [Type], Category, [Description], [DateTime], [Location], ContactPhone, ContactEmail, EventAdmin, HostUniversity)
	VALUES(@Name, @Type, @Category, @Description, @Date, @Location, @ContactPhone, @ContactEmail, @EventAdmin, @HostUniversity)
END