﻿CREATE TABLE [dbo].[Store] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [TypeID]              INT            NOT NULL,
    [Number]              NVARCHAR (50)  NULL,
    [Address]           NVARCHAR (255) NULL,
    [City]                     NVARCHAR (50)  NULL,
    [State]                    NVARCHAR (20)  NULL,
    [ZipCode]                  NVARCHAR (20)  NULL,
    [StorePhoneNumber]         [dbo].[PhoneNumber]  NULL,
    [DirectPhoneNumber]        [dbo].[PhoneNumber]  NULL,
    [FaxNumber]                [dbo].[PhoneNumber]  NULL,
    [Notes]                    NTEXT          NULL,
    [BranchId]                 INT            NOT NULL,
    [Active]                   BIT            CONSTRAINT [DF__Store__Active] DEFAULT ((1)) NOT NULL,
    [NickName]            NVARCHAR (50)  CONSTRAINT [DF__Store__StoreNickName] DEFAULT (NULL) NULL,
    [Latitude]                 FLOAT (53)     NULL,
    [Longitude]                FLOAT (53)     NULL,
    [DistrictNumber]             SMALLINT       NULL,
    [IncludeInStatusReportAll] BIT            CONSTRAINT [DF_Store_IncludeInStatusReportAll] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Store_Branch] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[Branch] ([Id]),
    CONSTRAINT [FK_Store_StoreType] FOREIGN KEY ([TypeID]) REFERENCES [dbo].[StoreType] ([Id]), 
);

