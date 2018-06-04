CREATE TABLE [dbo].[MeasureRoom]
(
	[Id] INT  IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [RoomId] INT NOT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [MaterialId] INT NOT NULL, 

    [IncludeCloset] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_MeasureRoom_Room] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Room] ([Id]),
    CONSTRAINT [FK_MeasureRoom_MeasureMaterial] FOREIGN KEY ([MaterialId]) REFERENCES [dbo].[MeasureMaterial] ([Id]) on delete cascade,
)
