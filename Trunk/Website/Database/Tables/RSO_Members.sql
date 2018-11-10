CREATE TABLE [dbo].[RSO_Members]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[RSO_Id] INT NOT NULL,
	[StudentEmail] NVARCHAR(64) NOT NULL,
	[IsAdmin] BIT DEFAULT (0) NOT NULL,
		
    CONSTRAINT [FK_RSO_Members_RegisteredStudentOrganizations] FOREIGN KEY ([RSO_Id]) REFERENCES [RegisteredStudentOrganizations]([Id]),
)
