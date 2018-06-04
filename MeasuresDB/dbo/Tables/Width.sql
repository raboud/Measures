CREATE TABLE [dbo].[Width]
(
	[Id] [int]  IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[Value] [float] NOT NULL, 
	[MaterialTypeId] [int] NOT null
    CONSTRAINT [FK_Width_MaterialType] FOREIGN KEY ([MaterialTypeId]) REFERENCES [dbo].[MaterialType] ([Id]), 
)
