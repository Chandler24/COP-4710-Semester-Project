CREATE TABLE [dbo].[Universities]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(64) NOT NULL,
	[Location] INT NOT NULL,
	[Description] NVARCHAR(64) NOT NULL,
	[NumberOfStudents] BIGINT NOT NULL
)
