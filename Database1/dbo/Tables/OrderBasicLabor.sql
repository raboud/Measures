CREATE TABLE [dbo].[OrderBasicLabor] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [OrderID]           INT             NOT NULL,
    [BasicLaborID]      INT             NOT NULL,
    [EntryMethodID]     INT             CONSTRAINT [DF__OrderBasicLaborDetails__EntryMethodID] DEFAULT ((1)) NOT NULL,
    [MaterialStatusID]  INT             NULL,

    [InstallQuantity]   DECIMAL (18, 4) NOT NULL,

    [PrintOnInvoice]    BIT             CONSTRAINT [DF__OrderBasicLaborDetails__PrintOnInvoice] DEFAULT ((1)) NOT NULL,
    [PrintOnWO]         BIT             CONSTRAINT [DF__OrderBasicLaborDetails__PrintOnWO] DEFAULT ((1)) NOT NULL,
    [Deleted]           BIT             CONSTRAINT [DF__OrderBasicLaborDetails__Deleted] DEFAULT ((0)) NOT NULL,
    [Reviewed]          BIT             CONSTRAINT [DF__OrderBasicLaborDetails__Reviewed] DEFAULT ((0)) NOT NULL,

    [ServiceLineNumber] INT             NULL,

    [ReviewedByID]      INT             NULL,
    [ReviewedDate]      DATETIME        NULL,

    [UnitPrice]         DECIMAL (18, 4) NOT NULL,
    [UnitLabor]          DECIMAL (18, 4) NOT NULL,
    [UnitRetail]        MONEY           NULL,
    [UnitMaterialCost]      MONEY           DEFAULT ((0.0)) NOT NULL,

    [ExtendedPrice]     AS              (isnull(case when [PrintOnInvoice]='1' then [UnitPrice]*[InstallQuantity] else (0) end,(0.0))),
    [ExtendedCost]      AS              (isnull(case when [PrintOnWO]='1' then [UnitLabor]*[InstallQuantity] else (0) end,(0.0))),

    CONSTRAINT [PK_OrderBasicLaborDetails] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_OrderBasicLaborDetail_EntryMethod] FOREIGN KEY ([EntryMethodID]) REFERENCES [dbo].[EntryMethod] ([ID]),
    CONSTRAINT [FK_OrderBasicLaborDetail_ReviewedBy] FOREIGN KEY ([ReviewedByID]) REFERENCES [dbo].[Employees] ([UserId]),
    CONSTRAINT [FK_OrderBasicLaborDetails_BasicLabor] FOREIGN KEY ([BasicLaborID]) REFERENCES [dbo].[BasicLabor] ([BasicLaborID]),
    CONSTRAINT [FK_OrderBasicLaborDetails_Orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_OrderBasicLaborDetails_OrderID]
    ON [dbo].[OrderBasicLabor]([OrderID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_OrderBasicLaborDetails_Jobs] 
ON [dbo].[OrderBasicLaborDetails]
(
	[OrderID] ASC,
	[ID] ASC,
	[BasicLaborID] ASC
)
INCLUDE ( 	[InstallQuantity],
	[UnitCost],
	[UnitPrice],
	[UnitRetail],
	[PrintOnInvoice],
	[PrintOnWO],
	[ServiceLineNumber],
	[MaterialStatusID],
	[EntryMethodID],
	[Deleted],
	[Reviewed],
	[ReviewedByID],
	[ReviewedDate],
	[MaterialCost],
	[ExtendedPrice],
	[ExtendedCost]) 
WITH (DROP_EXISTING = OFF, ONLINE = OFF)

