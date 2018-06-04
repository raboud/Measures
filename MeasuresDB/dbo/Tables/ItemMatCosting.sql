CREATE TABLE [dbo].[ItemMatCosting] (
    [Id] INT        IDENTITY (1, 1) NOT NULL,
    [ItemId]           INT        NOT NULL,
    [BranchId]         INT        NOT NULL,
    [StoreId]          INT        NULL,
	[ProgramId]		INT		null,
    [MatCost]          MONEY      NULL,
    [StartDate]        DATE   NULL DEFAULT GetDate(),
    [EndDate]          DATE   NULL,
    [Freight]          MONEY      NULL,
    [SalesTax]         FLOAT (53) NULL,
    CONSTRAINT [PK_ItemMatCosting] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemMatCosting_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item] ([Id]),
    CONSTRAINT [FK_ItemMatCosting_Branch] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[Branch] ([Id]),
    CONSTRAINT [FK_ItemMatCosting_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([Id]),
    CONSTRAINT [FK_ItemMatCosting_Program] FOREIGN KEY ([ProgramId]) REFERENCES [dbo].[Program] ([Id])
);
go

CREATE INDEX [IX_ItemMatCosting_Labor] ON [dbo].[ItemMatCosting] ([ItemId])
GO

CREATE INDEX [IX_ItemMatCosting_Branch] ON [dbo].[ItemMatCosting] ([BranchId])
GO

CREATE INDEX [IX_ItemMatCosting_Store] ON [dbo].[ItemMatCosting] ([StoreId])
go

CREATE INDEX [IX_ItemMatCosting_Program] ON [dbo].[ItemMatCosting] ([ProgramId])
go




