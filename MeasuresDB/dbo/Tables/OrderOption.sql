CREATE TABLE [dbo].[OrderOption] (
    [Id]    INT             IDENTITY (1, 1) NOT NULL,
    [OrderId]           INT             NOT NULL,
    [OptionId]          INT             NOT NULL,
    [SubContractorId]   INT             NULL,
    [EntryMethodId]     INT             CONSTRAINT [DF__Order Options Details__EntryMethodID] DEFAULT ((1)) NOT NULL,

    [ServiceLineNumber] INT             NULL,


    [Quantity]          DECIMAL (18, 4) CONSTRAINT [DF_Order Options Details_Quantity] DEFAULT ((0)) NOT NULL,

    [SubContractorPaid] BIT             NULL,
    [PrintOnInvoice]    BIT             CONSTRAINT [DF__Order Options Details__PrintOnInvoice] DEFAULT ((1)) NOT NULL,
    [PrintOnWO]         BIT             CONSTRAINT [DF__Order Options Details__PrintOnWO] DEFAULT ((1)) NOT NULL,
    [Deleted]           BIT             CONSTRAINT [DF__Order Options Details__Deleted] DEFAULT ((0)) NOT NULL,
    [Reviewed]          BIT             CONSTRAINT [DF__Order Options Details__Reviewed] DEFAULT ((0)) NOT NULL,




    [ReviewedByID]      dbo.AspNetUserId             NULL,
    [ReviewedDate]      DATETIME        NULL,

    [SubContractorPay]  MONEY			NULL,
    [UnitPrice]         MONEY			NOT NULL,
    [UnitLabor]          MONEY			NOT NULL,
    [UnitRetail]        MONEY           NULL,
    [UnitMaterialCost]  MONEY           DEFAULT ((0.0)) NOT NULL,

    [ExtendedPrice]     AS              (isnull(case when [PrintOnInvoice]='1' then [UnitPrice]*[Quantity] else (0) end,(0.0))),
    [ExtendedCost]      AS              (isnull(case when [PrintOnWO]='1' then [UnitLabor]*[Quantity] else (0) end,(0.0))),

    CONSTRAINT [PK_OrderOption] PRIMARY KEY NONCLUSTERED (Id ASC),
    CONSTRAINT [FK_OrderOption_Option] FOREIGN KEY ([OptionId]) REFERENCES [dbo].[Option] ([Id]),
    CONSTRAINT [FK_OrderOption_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_OrderOption_Employees] FOREIGN KEY ([ReviewedByID]) REFERENCES [dbo].[Employee] ([UserId]),
    CONSTRAINT [FK_OrderOption_EntryMethod] FOREIGN KEY ([EntryMethodId]) REFERENCES [dbo].[EntryMethod] ([Id])
);


GO
CREATE CLUSTERED INDEX [IX_OrderOption_OrderID]
    ON [dbo].[OrderOption]([OrderId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_OrderOption_JOB] 
	ON [dbo].[OrderOption]
(
	[OrderId] ASC,
	[OptionId] ASC
)
INCLUDE ( 	[Id],
	[Quantity],
	[SubContractorId],
	[UnitPrice],
	[UnitLabor],
	[UnitRetail],
	[UnitMaterialCost],
	[SubContractorPaid],
	[SubContractorPay],
	[EntryMethodId],
	[PrintOnInvoice],
	[PrintOnWO],
	[Deleted],
	[Reviewed],
	[ReviewedByID],
	[ReviewedDate],
	[ExtendedPrice],
	[ExtendedCost]) 
WITH (DROP_EXISTING = OFF, ONLINE = OFF)

