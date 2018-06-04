CREATE TABLE [dbo].[ItemCosting] (
    [Id] INT      IDENTITY (1, 1) NOT NULL,
    [ItemId]        INT      NOT NULL,
    [BranchId]      INT      NULL,
    [StoreId]       INT      NULL,
	[ProgramId]		INT		NULL,
    Amount          MONEY    NOT NULL DEFAULT 0,
    [StartDate]     DATE NOT NULL DEFAULT GetDate(),
    [EndDate]       DATE NULL,
    [DivisionId]    INT      NULL,
    CONSTRAINT [PK_ItemCosting] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ItemCosting_Division] FOREIGN KEY ([DivisionId]) REFERENCES [dbo].[Division] ([Id]),
    CONSTRAINT [FK_ItemCosting_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item] ([Id]),
    CONSTRAINT [FK_ItemCosting_Branch] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[Branch] ([Id]),
    CONSTRAINT [FK_ItemCosting_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([Id]),
    CONSTRAINT [FK_ItemCosting_Program] FOREIGN KEY ([ProgramId]) REFERENCES [dbo].[Program] ([Id]),
);
GO

CREATE INDEX [IX_ItemCosting_Labor] ON [dbo].[ItemCosting] ([ItemId])
GO

CREATE INDEX [IX_ItemCosting_Branch] ON [dbo].[ItemCosting] ([BranchId])
GO

CREATE INDEX [IX_ItemCosting_Store] ON [dbo].[ItemCosting] ([StoreId])
go

CREATE INDEX [IX_ItemCosting_Program] ON [dbo].[ItemCosting] ([ProgramId])
go
