USE [RSO_Database]
GO
/****** Object:  StoredProcedure [dbo].[AddComment]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddComment]
	@UserId int,
	@EventId int,
	@Comment nvarchar(1024)
AS
BEGIN
	INSERT INTO EventSocial(EventId, UserId, Comment)
	VALUES (@EventId, @UserId, @Comment)
END
GO
/****** Object:  StoredProcedure [dbo].[AddMemberToRso]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddMemberToRso]
@RsoId int,
@StudentEmail nvarchar(128),
@IsAdmin bit = 0
AS
BEGIN
	INSERT INTO RSO_Members(RSO_Id, StudentEmail, IsAdmin)
	VALUES (@RsoId, @StudentEmail, @IsAdmin)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUniversity]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
	@FirstName NVARCHAR(32),
	@LastName NVARCHAR(32),
	@Username NVARCHAR(64),
	@Password NVARCHAR(32),
	@UserType INT
AS
BEGIN
	INSERT INTO Users (FirstName, LastName, Username, Password, UserType)
	VALUES(@FirstName, @LastName, @Username, @Password, @UserType)
END
GO
/****** Object:  StoredProcedure [dbo].[CheckIfUserIsInRso]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[CreateRso]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateRso]
	@Name nvarchar(128),
	@Description nvarchar(128)
AS
INSERT INTO RegisteredStudentOrganizations (Name, [Description])
VALUES (@Name, @Description)
GO
/****** Object:  StoredProcedure [dbo].[DeleteComment]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteComment]
	@Id int
AS
BEGIN
	UPDATE EventSocial
	SET IsDeleted = 1
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[EditComment]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditComment]
	@Id int,
	@EditedComment nvarchar(1024)
AS
BEGIN
	UPDATE EventSocial
	SET Comment = @EditedComment
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllRsos]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllRsos]
AS
BEGIN
	SELECT Id, Name, [Description] FROM RegisteredStudentOrganizations
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUniversities]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[GetCommentsForEvents]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCommentsForEvents]
@EventId int 
AS
BEGIN
	SELECT u.FirstName, u.LastName, e.Comment, e.Id FROM EventSocial e
	INNER JOIN Users u 
	ON u.Id = e.UserId
	WHERE EventId = @EventId AND IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetEventCategories]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEventCategories]
AS
BEGIN
	SELECT	Id,
			[Name]
	FROM	EventCategory
END
GO
/****** Object:  StoredProcedure [dbo].[GetEvents]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEvents]
	@Type int
AS
BEGIN
	IF(@Type = 0)
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
	ELSE 
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
		WHERE e.[Type] = @Type
		GROUP BY e.Id, e.Name, e.[DateTime], e.[Description]		
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetEventTypes]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEventTypes]
AS
BEGIN
	SELECT Id, [Description] FROM EventType
END
GO
/****** Object:  StoredProcedure [dbo].[GetRsoId]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRsoId]
	@RsoName nvarchar(128)
AS
BEGIN
	SELECT Id FROM RegisteredStudentOrganizations WHERE Name = @RsoName
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserTypes]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserTypes]
AS
BEGIN
	SELECT * FROM UserTypes
END
GO
/****** Object:  StoredProcedure [dbo].[JoinRso]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[JoinRso]
	@UserId int,
	@RsoId int
AS
BEGIN
	DECLARE @Username NVARCHAR(128) 
	SET @Username = (SELECT Username from Users where Id = @UserId)

	INSERT INTO RSO_Members(RSO_Id, StudentEmail)
	VALUES (@RsoId, @Username)
END
GO
/****** Object:  StoredProcedure [dbo].[SaveEvent]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[SignIn]    Script Date: 11/23/2018 8:13:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[SignIn]
	@Username nvarchar(128)
AS
BEGIN
	SELECT [Password], Id, UserType FROM Users where Username = @Username
END
GO
