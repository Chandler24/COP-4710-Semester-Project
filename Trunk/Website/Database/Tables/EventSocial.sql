CREATE TABLE [dbo].[EventSocial]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[EventId] INT NOT NULL,
	[UserId] INT NOT NULL,
	[Rating] INT,
	[Comment] NVARCHAR(64),
	
    CONSTRAINT [FK_EventSocial_Events] FOREIGN KEY ([EventId]) REFERENCES [Events]([Id]),
    CONSTRAINT [FK_EventSocial_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
)
