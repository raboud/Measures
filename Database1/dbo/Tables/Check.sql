CREATE TABLE [dbo].[Check] (
    [Id]		INT             IDENTITY (1, 1) NOT NULL,
    [Number]	CHAR (10)       NULL,
    [Date]		DATE   NULL,
    [Amount]	money NULL,
    [VendorID]	INT             CONSTRAINT [DF__Check__VendorID] DEFAULT (1) NOT NULL,
    [QBTxnId]	NVARCHAR(50) NULL, 

    CONSTRAINT [PK_Check] PRIMARY KEY CLUSTERED ([Id] ASC)
);

