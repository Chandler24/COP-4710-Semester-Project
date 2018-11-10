CREATE TABLE [dbo].[Locations]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(64) NOT NULL,
	[Longitude] DECIMAL(9, 6) NOT NULL,
	[Latitude] DECIMAL(9, 6) NOT NULL,
	[Hours] NVARCHAR(16) NOT NULL
)
