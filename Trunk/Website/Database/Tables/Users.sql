﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[FirstName] NVARCHAR(32) NOT NULL,
	[LastName] NVARCHAR(32) NOT NULL,
	[Username] NVARCHAR(64) NOT NULL,
	[Password] NVARCHAR(32) NOT NULL,
	[UserType] INT NOT NULL,
		
    CONSTRAINT [FK_Users_UserType] FOREIGN KEY ([UserType]) REFERENCES [UserTypes]([Id])
)
