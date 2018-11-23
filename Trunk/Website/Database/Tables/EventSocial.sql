CREATE TABLE [dbo].[EventSocial]
(
	[Id] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	[EventId] INT NOT NULL,
	[UserId] INT NOT NULL,
	[Rating] INT,
	[Comment] NVARCHAR(64),
	[IsDeleted] BIT DEFAULT 0
	
    CONSTRAINT [FK_EventSocial_Events] FOREIGN KEY ([EventId]) REFERENCES [Events]([Id]),
    CONSTRAINT [FK_EventSocial_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
)
