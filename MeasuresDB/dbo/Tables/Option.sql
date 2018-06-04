CREATE TABLE [dbo].[Option] (
    [Id]				INT            IDENTITY (1, 1) NOT NULL,

    [UnitOfMeasureId]   INT            NULL,
    [ProgramId]			INT            NULL,
    [ItemId]            INT            NULL,

    [Description]		NVARCHAR (255) NULL,
    [RetailPrice]       MONEY          NULL,

    [Active]            BIT            CONSTRAINT [DF_Options_Active] DEFAULT ((1)) NOT NULL,
    [PrintOnInvoice]    BIT            CONSTRAINT [DF__Options__PrintOnInvoice] DEFAULT ((1)) NULL,
    [PrintOnWO]			BIT            CONSTRAINT [DF__Options__PrintOnWO] DEFAULT ((1)) NULL,

    [ApplyToMinimum]    BIT            CONSTRAINT [DF__Options__ApplyToMinimum] DEFAULT ((0)) NULL,
    [ApplyToMinimumWO]  BIT            CONSTRAINT [DF__Options__ApplyToMinimumWO] DEFAULT ((1)) NULL,
    [Size]              BIT            NULL,

    CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Options_Item] FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Item] ([Id]),
    CONSTRAINT [FK_Options_Program] FOREIGN KEY ([ProgramId]) REFERENCES [dbo].[Program] ([Id]),
    CONSTRAINT [FK_Options_UnitOfMeasure] FOREIGN KEY ([UnitOfMeasureId]) REFERENCES [dbo].[UnitOfMeasure] ([Id])
);

