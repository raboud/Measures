CREATE TABLE [dbo].[CheckDetail] (
    [Id] INT             IDENTITY (1, 1) NOT NULL,
    [CheckID]       INT             NOT NULL,
    [OrderID]       INT             NOT NULL,
    [Amount]        NUMERIC (19, 2) NOT NULL,
    CONSTRAINT [PK_CheckDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CheckDetail_Checks] FOREIGN KEY ([CheckID]) REFERENCES [dbo].[Check] ([Id]),
    CONSTRAINT [FK_CheckDetail_Orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CheckDetail_OrderID]
    ON [dbo].[CheckDetail]([OrderID] ASC);

