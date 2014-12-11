CREATE TABLE [dbo].[Measure]
(
	[Id] INT  IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
	[CustomerId] INT not null,
    [Enterred] DATETIME NOT NULL,

    [StoreId] INT NOT NULL, 
    [EnterredById] [dbo].[AspNetUserId] NOT NULL, 
    [SpecialInstructions] NTEXT NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    [Status] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Measure_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_Measure_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([Id]),
)

GO

CREATE INDEX [IX_Measure_StoreId] ON [dbo].[Measure] ([StoreId])

GO

CREATE INDEX [IX_Measure_CustomerId] ON [dbo].[Measure] ([CustomerId])
