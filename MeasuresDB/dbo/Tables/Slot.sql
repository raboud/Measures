CREATE TABLE [dbo].[Slot]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATE NOT NULL, 
    [UserId] [dbo].[AspNetUserId] NOT NULL, 
    [SlotTypeId] INT NOT NULL, 
    [MeasureId] INT NOT NULL,

    CONSTRAINT [FK_Slot_Measure] FOREIGN KEY ([MeasureId]) REFERENCES [dbo].[Measure] ([Id]) on delete cascade,
    CONSTRAINT [FK_Slot_SlotType] FOREIGN KEY ([SlotTypeId]) REFERENCES [dbo].[SlotType] ([Id]) on delete cascade,

)
