CREATE TABLE [dbo].[Events]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(64) NOT NULL,
	[Type] INT NOT NULL,
	[Category] INT NOT NULL,	
	[Description] NVARCHAR(256) NOT NULL,
	[DateTime] DateTime NOT NULL,
	[Location] INT NOT NULL,
	[ContactPhone] NVARCHAR(16) NOT NULL,
	[ContactEmail] NVARCHAR(64) NOT NULL,
	[EventAdmin] INT NOT NULL,
	[HostUniversity] INT NOT NULL, 
	
    CONSTRAINT [FK_Events_EventType] FOREIGN KEY ([Type]) REFERENCES [EventType]([Id]),
    CONSTRAINT [FK_Events_EventCategory] FOREIGN KEY ([Category]) REFERENCES [EventCategory]([Id]),
    CONSTRAINT [FK_Events_Locations] FOREIGN KEY ([Location]) REFERENCES [Locations]([Id]),
    CONSTRAINT [FK_Events_Users] FOREIGN KEY ([EventAdmin]) REFERENCES [Users]([Id]),	
    CONSTRAINT [FK_Events_Universities] FOREIGN KEY ([HostUniversity]) REFERENCES [Universities]([Id]),

)
