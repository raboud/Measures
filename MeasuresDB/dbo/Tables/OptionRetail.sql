CREATE TABLE [dbo].[OptionRetail]
(
    Id INT      IDENTITY (1, 1) NOT NULL,
    [LaborId]        INT      NOT NULL,
    [BranchId]      INT      NULL,
    [StoreId]       INT      NULL,
    Amount         MONEY    NOT NULL DEFAULT 0,
    [StartDate]     DATE NOT NULL DEFAULT GetDate(),
    [EndDate]       DATE NULL,
    CONSTRAINT [PK_OptionRetail] PRIMARY KEY CLUSTERED (Id ASC),
    CONSTRAINT [FK_OptionRetail_Labor] FOREIGN KEY ([LaborId]) REFERENCES [dbo].[Option] ([Id]),
    CONSTRAINT [FK_OptionRetail_Branch] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[Branch] ([Id]),
    CONSTRAINT [FK_OptionRetail_Stores] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([Id])
)

GO

CREATE INDEX [IX_OptionRetail_Labor] ON [dbo].[OptionRetail] ([LaborId])

GO

CREATE INDEX [IX_OptionRetail_Branch] ON [dbo].[OptionRetail] ([BranchId])

GO

CREATE INDEX [IX_OptionRetail_Store] ON [dbo].[OptionRetail] ([StoreId])
