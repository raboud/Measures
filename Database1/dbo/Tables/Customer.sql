CREATE TABLE [dbo].[Customer] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]            NVARCHAR (50)  NULL,
    [LastName]             NVARCHAR (50)  NULL,
    [CompanyName]          NVARCHAR (50)  NULL,
    [Address]              NVARCHAR (255) NULL,
    [Address2]             NVARCHAR (255) NULL,
    [City]                 NVARCHAR (50)  NULL,
    [State]                NCHAR (2)      CONSTRAINT [DF__Customer__State] DEFAULT ('GA') NULL,
    [ZipCode]              NCHAR (10)     NULL,
    [Latitude]             FLOAT (53)     NULL,
    [Longitude]            FLOAT (53)     NULL,
    [Directions]           TEXT           NULL,

    [PhoneNumber]          [dbo].[PhoneNumber]     NULL,
    [MobileNumber]         [dbo].[PhoneNumber]     NULL,
    [WorkNumber]           VARCHAR (50)   NULL,
    [Extension]            VARCHAR (50)   NULL,
    [EmailAddress]         [dbo].[EmailAddress] NULL,

    [LastModifiedBy]       INT            NULL,
    [LastModifiedDateTime] DATETIME       NULL,

    [Name] as IIF(CompanyName is null, IsNull(LastName, '') + ', ' + IsNull(FirstName, ''), CompanyName) PERSISTED
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90),
);


GO
CREATE NONCLUSTERED INDEX [CustomerFNameLName]
    ON [dbo].[Customer]([FirstName] ASC, [LastName] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [CustomerIDFNameLName]
    ON [dbo].[Customer]([Id] ASC, [FirstName] ASC, [LastName] ASC) WITH (FILLFACTOR = 90);


GO
CREATE NONCLUSTERED INDEX [CustomersLNameFName]
    ON [dbo].[Customer]([LastName] ASC, [FirstName] ASC) WITH (FILLFACTOR = 90);

