﻿CREATE TABLE [dbo].[Program] (
    [Id]						INT           IDENTITY (1, 1) NOT NULL,
    [StoreTypeID]               INT           NULL,
    [MinimumPrice]              MONEY         NULL,
    [MinimumCost]               MONEY         NULL,
    [MinimumRetail]             MONEY         NULL,
    [CustomMultiplier]          FLOAT (53)    NULL,
    [TripChargeMultiplier]      FLOAT (53)    CONSTRAINT [DF__Program__TripChargeMultiplier] DEFAULT ((0.999)) NULL,
    [CostMultiplier]            FLOAT (53)    CONSTRAINT [DF__Program__CostMultiplier] DEFAULT ((0.5)) NULL,
    [Valid]                     BIT           CONSTRAINT [DF__Program__Valid] DEFAULT ((1)) NULL,
    [OnlyBasicToMinimum]        BIT           NULL,
    [ShortName]                 VARCHAR (20)  NULL,
    [DivisionId]                INT           NULL,
    [Active]                    BIT           NULL,
    [Furnish]                   BIT           CONSTRAINT [DF__Program__Furnish] DEFAULT ((0)) NOT NULL,
    [SKU]                       VARCHAR (12)  CONSTRAINT [DF__Program__SKU] DEFAULT ('') NOT NULL,
    [SKUDesc]                   VARCHAR (255) CONSTRAINT [DF__Program__SKUDesc] DEFAULT ('') NOT NULL,
    [HDType]                    NCHAR (1)     CONSTRAINT [DF__Program__HDType] DEFAULT ('') NOT NULL,
    [Name]						AS            IIF(HDType = 'I', 'INSTALL: ', 'MEASURE: ')+[SKU]+' '+[SKUDesc],
    [InsuranceReplacement]      BIT           CONSTRAINT [DF__Program__InsuranceReplacement] DEFAULT ((0)) NOT NULL,
    [AllowMaterialStatusUpdate] BIT           CONSTRAINT [DF__Program__AllowMaterialStatusUpdate] DEFAULT ((0)) NOT NULL,
    [JobTypeId]                 INT           NULL,
    [WoodWaiver]                BIT           DEFAULT ((0)) NOT NULL,
    [CustomCostByRetail]		BIT NOT NULL DEFAULT 1, 
    [MarkDown]					INT NULL, 
    [MarkDownMin]				INT NULL, 
    [MarkDownMax]				INT NULL, 
    CONSTRAINT [PK_Program] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Program_Division] FOREIGN KEY ([DivisionId]) REFERENCES [dbo].[Division] ([Id]),
    CONSTRAINT [FK_Program_JobType] FOREIGN KEY ([JobTypeId]) REFERENCES [dbo].[JobType] ([Id]),
    CONSTRAINT [FK_Program_StoreType] FOREIGN KEY ([StoreTypeID]) REFERENCES [dbo].[StoreType] ([Id])
);
