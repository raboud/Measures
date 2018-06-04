CREATE TABLE [dbo].[Order] (
    [Id]					INT            IDENTITY (1, 1) NOT NULL,

    [CustomerId]			INT            NOT NULL,
    [ProgramId]				INT            NOT NULL,
    [StoreId]				INT            NOT NULL,
    [JobStatusId]			INT             NULL,
    [PrimaryOrderId]		INT             NULL,

    [AssignedToId]			dbo.AspNetUserId             NULL,
    [CreatedByID]			dbo.AspNetUserId             NULL,
    [SalesPersonId]			dbo.AspNetUserId            NULL,
    [EnteredById]			dbo.AspNetUserId            NULL,
    [ReviewedById]			dbo.AspNetUserId            NULL,

    [OrderDate]				DATETIME       NULL,
    [BilledDate]			DATETIME       NULL,

    [PONumber]				CHAR (8)       NULL,
    [OriginalPO]           CHAR (8)       NULL,
    [OrderNo]              CHAR (15)      NULL,

    [ScheduleStartDate]		DATE       NULL,
    [DrawingDate]			DATETIME       NULL,
    [FollowUpDate]			DATETIME       CONSTRAINT [DF__Orders__FollowUpDate] DEFAULT (NULL) NULL,
    [Entered]				DATETIME       NULL,

    [SpecialInstructions]                VARCHAR (MAX)  NULL,
    [InternalNotes]			TEXT           NULL,

    [Scheduled]				BIT            CONSTRAINT [DF__Orders__Scheduled] DEFAULT ((0)) NOT NULL,
    [Billed]				BIT            CONSTRAINT [DF__Orders__Billed] DEFAULT ((0)) NOT NULL,
    [Paid]					BIT            CONSTRAINT [DF__Orders__Paid] DEFAULT ((0)) NOT NULL,
    [Called]				BIT            CONSTRAINT [DF__Orders__Called] DEFAULT ((0)) NOT NULL,
    [CustomerToCall]       BIT            CONSTRAINT [DF__Orders__CustomerToCall] DEFAULT ((0)) NOT NULL,
    [Invoice]              BIT            CONSTRAINT [DF__Orders__Invoice] DEFAULT ((0)) NOT NULL,
    [NoMinimum]				BIT            CONSTRAINT [DF__Orders__NoMinimum] DEFAULT ((0)) NOT NULL,
    [ScheduledAM]			BIT            CONSTRAINT [DF__Orders__ScheduledAM] DEFAULT ((0)) NOT NULL,
    [Cancelled]				BIT            CONSTRAINT [DF__Orders__Cancelled] DEFAULT ((0)) NOT NULL,
    [Warrenty]				BIT            CONSTRAINT [DF__Orders__Warrenty] DEFAULT ((0)) NOT NULL,
    [SevenDay]				BIT            CONSTRAINT [DF__Orders__SevenDay] DEFAULT ((0)) NOT NULL,

    [CostAmount]			MONEY          CONSTRAINT [DF__Orders__CostAmount] DEFAULT ((0)) NOT NULL,
    [BilledAmount]			MONEY          NOT NULL DEFAULT ((0)),
    [OrderAmount]			MONEY          NOT NULL DEFAULT ((0)),
    [TripCharge]			MONEY          CONSTRAINT [DF__Orders__TripCharge] DEFAULT ((0)) NOT NULL,
    [RetailAmount]			MONEY          NOT NULL DEFAULT ((0)),

    [DrawingNumber]			TEXT           NULL,
    [EntryMethodId]			INT            CONSTRAINT [DF__Orders__EntryMethodID] DEFAULT ((1)) NOT NULL,
    [FollowUpAction]		VARCHAR (1024) CONSTRAINT [DF__Orders__FollowUpAction] DEFAULT (NULL) NULL,
    [ServiceLineNo]			INT            CONSTRAINT [DF__Orders__ServiceLineNo] DEFAULT (NULL) NULL,
    [SPNNotes]				TEXT           NULL,
    [XMLOrderCostAmount]	INT            NOT NULL DEFAULT ((0)),
    [Deleted]				BIT            CONSTRAINT [DF__Orders__Deleted] DEFAULT ((0)) NOT NULL,
    [Reviewed]				BIT            CONSTRAINT [DF__Orders__Reviewed] DEFAULT ((0)) NOT NULL,
    [VendorID]				INT            CONSTRAINT [DF__Orders__VendorID] DEFAULT (NULL) NULL,
    [CustomerOrderNumber]	NVARCHAR (30)  CONSTRAINT [DF__Orders__CustomerOrderNumber] DEFAULT (NULL) NULL,
    [CorrelationID]			NVARCHAR (255) CONSTRAINT [DF__Orders__CorrelationID] DEFAULT (NULL) NULL,
    [KeyRecNumber]			NVARCHAR (15)  CONSTRAINT [DF__Orders__KeyRecNu__13402AD9] DEFAULT (NULL) NULL,
    [LastModifiedDateTime]	DATETIME       NULL,
    [CreatedDateTime]		DATETIME        NULL,
    [ReviewedDate]			DATETIME       NULL,
    [KeyRecDate]			DATETIME       CONSTRAINT [DF__Orders__KeyRecDa__14344F12] DEFAULT (NULL) NULL,
    [SvcCompleteSentDate]	DATETIME       CONSTRAINT [DF__Orders__SvcCompl__1528734B] DEFAULT (NULL) NULL,
    [ScheduleEndDate]		DATE       NULL,
    [Estimate]				BIT            NOT NULL DEFAULT ((0)),
    [NUMBER]				AS             (case when [Estimate]='1' OR len([PONumber])<>(8) OR [PONumber] IS NULL then str([Id]) else [PONumber] end),
    [MarkDown]				INT NULL, 
    [JobSize]				DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_AssignedTo] FOREIGN KEY ([AssignedToId]) REFERENCES [dbo].[Employee] ([UserId]),
	CONSTRAINT [FK_Order_EnteredBy] FOREIGN KEY ([EnteredById]) REFERENCES [dbo].[Employee] ([UserId]),
    CONSTRAINT [FK_Order_ReviewedBy] FOREIGN KEY ([ReviewedById]) REFERENCES [dbo].[Employee] ([UserId]),
    CONSTRAINT [FK_Order_SalesPerson] FOREIGN KEY ([SalesPersonId]) REFERENCES [dbo].[Employee] ([UserId]),

    CONSTRAINT [FK_Order_JobStatus] FOREIGN KEY ([JobStatusId]) REFERENCES [dbo].[JobStatus] ([Id]),
    CONSTRAINT [FK_Order_Order] FOREIGN KEY ([PrimaryOrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_Order_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_Order_EntryMethod] FOREIGN KEY ([EntryMethodId]) REFERENCES [dbo].[EntryMethod] ([Id]),
    CONSTRAINT [FK_Order_Program] FOREIGN KEY ([ProgramId]) REFERENCES [dbo].[Program] ([Id]),
);


GO
CREATE NONCLUSTERED INDEX [IX_Orders_CustomerID]
    ON [dbo].[Order]([CustomerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Orders_StoreID]
    ON [dbo].[Order]([StoreId]);


GO
CREATE NONCLUSTERED INDEX [OrdersPO]
    ON [dbo].[Order]([PONumber] ASC);


GO

CREATE INDEX [IX_Orders_Job] ON [dbo].[Order] ([PrimaryOrderId])
