CREATE TABLE [dbo].[StoreTech]
(
	[StoreId] INT NOT NULL, 
    [TechId] INT NOT NULL, 
    CONSTRAINT [PK_StoreTech] PRIMARY KEY ([TechId], [StoreId]),

	CONSTRAINT [FK_StoreTech_Tech] FOREIGN KEY ([TechId]) REFERENCES [dbo].[Tech] ([Id]),
    CONSTRAINT [FK_StoreTech_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([Id]),
)
