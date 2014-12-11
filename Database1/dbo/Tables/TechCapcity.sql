CREATE TABLE [dbo].[TechCapacity]
(
	[Id] INT  IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [TechId] INT NOT NULL, 
    [SlotTypeId] INT NOT NULL, 
    [Capacity] TINYINT NOT NULL,

    [DayOfWeek] TINYINT NOT NULL, 
    CONSTRAINT [FK_TechCapacity_Tech] FOREIGN KEY ([TechId]) REFERENCES [dbo].[Tech] ([Id]), 
    CONSTRAINT [FK_TechCapacity_SlotType] FOREIGN KEY ([SlotTypeId]) REFERENCES [dbo].[SlotType] ([Id]), 
)
