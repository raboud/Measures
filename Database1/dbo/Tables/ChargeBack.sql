CREATE TABLE [dbo].[ChargeBack] (
    [Id]    INT             IDENTITY (1, 1) NOT NULL,
    [Amount]          DECIMAL (19, 2) CONSTRAINT [DF__ChargeBacks__Amount] DEFAULT (0) NOT NULL,
    [SubcontractorId] INT             CONSTRAINT [DF__ChargeBacks__SubcontractorID] DEFAULT (0) NOT NULL,
    [AmountToSub]     DECIMAL (19, 2) CONSTRAINT [DF__ChargeBacks__AmountToSub] DEFAULT (0) NOT NULL,
    [Number]          NVARCHAR (50)   NOT NULL,
    [Name]            NVARCHAR (50)   NULL,
    [Reason]          NVARCHAR (2000) NOT NULL,
    [IssueDate]       DATE   NOT NULL,
    [OriginalPO]      NVARCHAR (50)   NULL,
    [CostAdjustment]  BIT             NULL,
    [OrderId]         INT             NULL,
    [ApprovalNumber]  INT             DEFAULT (0) NOT NULL,
    [Approved]        BIT             DEFAULT (1) NOT NULL,
    CONSTRAINT [PK_ChargeBack] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ChargeBack_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ChargeBack_OrderID]
    ON [dbo].[ChargeBack]([OrderId] ASC)

