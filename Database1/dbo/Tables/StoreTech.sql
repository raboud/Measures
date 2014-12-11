CREATE TABLE [dbo].[StoreTech](
	[StoreId] [int] NOT NULL,
	[TechId] [dbo].[AspNetUserId] NOT NULL,


	CONSTRAINT [FK_StoreTech_Store] FOREIGN KEY([StoreId]) REFERENCES [dbo].[Store] ([Id]), 
	CONSTRAINT [FK_StoreTech_Tech] FOREIGN KEY([TechId]) REFERENCES [dbo].[Tech] ([UserId]),
    CONSTRAINT [PK_StoreTech] PRIMARY KEY ([StoreId], [TechId])
)
