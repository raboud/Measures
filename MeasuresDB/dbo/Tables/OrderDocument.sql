CREATE TABLE [dbo].[OrderDocument] (
    [DocumentID] INT NOT NULL,
    [OrderID]    INT NOT NULL,
    CONSTRAINT [PK_OrderDocument] PRIMARY KEY CLUSTERED ([OrderID] ASC, [DocumentID] ASC),
    CONSTRAINT [FK_OrderDocument_Document] FOREIGN KEY ([DocumentID]) REFERENCES [dbo].[Document] ([Id]),
    CONSTRAINT [FK_OrderDocument_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([Id])
);

