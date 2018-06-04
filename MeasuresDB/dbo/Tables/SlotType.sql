CREATE TABLE [dbo].[SlotType]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 1,
)
