CREATE TABLE [dbo].[OrderCustom] (
    [Id]     INT             IDENTITY (1, 1) NOT NULL,
    [OrderID]           INT             NOT NULL,

    [SubContractorID]   INT             NULL,
    [EntryMethodID]     INT             CONSTRAINT [DF__OrderCustomDetails__EntryMethodID] DEFAULT (1) NOT NULL,

    [Description]       VARCHAR (1024)  NULL,
    [CustomItemNumber]  INT             NULL,

    [Quanity]           DECIMAL (18, 4) NOT NULL,

    [SubContractorPaid] BIT             NULL,
    [UnitOfMeasureID]   INT             NULL,
    [NotOnInvoice]      BIT             CONSTRAINT [DF__OrderCustomDetails__NotOnInvoice] DEFAULT (0) NULL,
    [NotOnWorkOrder]    BIT             CONSTRAINT [DF__OrderCustomDetails__NotOnWorkOrder] DEFAULT (0) NULL,
    [PrintOnWorkOrder]  as              isnull(CONVERT(bit, case when [NotOnWorkOrder] = 1 then 0 else 1 end), 0),
    [PrintOnInvoice]    as              isnull(CONVERT(bit, case when [NotOnInvoice] = 1 then 0 else 1 end), 0),
    [Deleted]           BIT             CONSTRAINT [DF__OrderCustomDetails__Deleted] DEFAULT (0) NOT NULL,
    [Reviewed]          BIT             CONSTRAINT [DF__OrderCustomDetails__Reviewed] DEFAULT (0) NOT NULL,

    [ReviewedByID]      dbo.AspNetUserId             NULL,
    [ReviewedDate]      DATETIME        NULL,

    [SubContractorPay]  FLOAT (53)      NULL,
    [UnitPrice]         DECIMAL (18, 4) DEFAULT (0) NOT NULL,
    [UnitLabor]         DECIMAL (18, 4) NOT NULL,
    [UnitRetail]       DECIMAL (18, 4) NULL,
    [UnitMaterialCost]  MONEY           DEFAULT ((0.0)) NOT NULL,

    [ExtendedPrice]     AS              (isnull(case when [NotOnInvoice]='0' then [UnitPrice]*[Quanity] else (0) end,(0.0))),
    [ExtendedCost]      AS              (isnull(case when [NotOnWorkOrder]='0' then [UnitLabor]*[Quanity] else (0) end,(0.0))),

    CONSTRAINT [PK_OrderCustomDetails] PRIMARY KEY NONCLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderCustomDetails_Employees] FOREIGN KEY ([ReviewedByID]) REFERENCES [dbo].[Employee] ([UserId]),
    CONSTRAINT [FK_OrderCustomDetails_EntryMethod] FOREIGN KEY ([EntryMethodID]) REFERENCES [dbo].[EntryMethod] ([Id]),
    CONSTRAINT [FK_OrderCustomDetails_Orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_OrderCustomDetails_SubContractor] FOREIGN KEY ([SubContractorID]) REFERENCES [dbo].[SubContractor] ([Id]),
    CONSTRAINT [FK_OrderCustomDetails_UnitOfMeasure] FOREIGN KEY ([UnitOfMeasureID]) REFERENCES [dbo].[UnitOfMeasure] ([Id])
);


GO
CREATE CLUSTERED INDEX [IX_OrderCustomDetails_OrderID]
    ON [dbo].[OrderCustom]([OrderID] ASC);


GO
CREATE STATISTICS [Statistic_Reviewed]
    ON [dbo].[OrderCustom]([Reviewed]);

