CREATE TABLE [dbo].[Room]
(
	[Id] INT  IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL,
	[Active] bit not null DEFAULT 1,
)
