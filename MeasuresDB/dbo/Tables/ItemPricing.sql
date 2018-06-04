CREATE TABLE [dbo].[ItemPricing] (
    [Id] INT      IDENTITY (1, 1) NOT NULL,
    [ItemId]        INT      NOT NULL,
    [BranchId]      INT      NULL,
    [StoreId]       INT      NULL,
	[ProgramId]		INT		null,
    Amount         MONEY    NOT NULL,
    [StartDate]     DATE NOT NULL DEFAULT GetDate(),
    [EndDate]       DATE NULL,
    CONSTRAINT [PK_ItemPricing] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemPricing_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item] ([Id]),
    CONSTRAINT [FK_ItemPricing_Branch] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[Branch] ([Id]),
    CONSTRAINT [FK_ItemPricing_Stores] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([Id]),
    CONSTRAINT [FK_ItemPricing_Program] FOREIGN KEY ([ProgramId]) REFERENCES [dbo].[Program] ([Id])
);
GO

CREATE INDEX [IX_ItemPricing_Labor] ON [dbo].[ItemPricing] ([ItemId])
GO

CREATE INDEX [IX_ItemPricing_Branch] ON [dbo].[ItemPricing] ([BranchId])
GO

CREATE INDEX [IX_ItemPricing_Store] ON [dbo].[ItemPricing] ([StoreId])
go

CREATE INDEX [IX_ItemPricing_Program] ON [dbo].[ItemPricing] ([ProgramId])
go



