CREATE TABLE [dbo].[Customer] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]            NVARCHAR (50)  NULL,
    [LastName]             NVARCHAR (50)  NULL,
    [CompanyName]          NVARCHAR (50)  NULL,
    [Address]              NVARCHAR (255) NULL,
    [Address2]             NVARCHAR (255) NULL,
    [City]                 NVARCHAR (50)  NULL,
    [State]                NCHAR (2)      CONSTRAINT [DF__Customer__State] DEFAULT ('GA') NULL,
    [ZipCode]              NVARCHAR(10)     NULL,
    [Latitude]             FLOAT (53)     NULL,
    [Longitude]            FLOAT (53)     NULL,
    [Directions]           TEXT           NULL,

    [PhoneNumber1]          [dbo].[PhoneNumber]     NULL,
    [PhoneNumber2]         [dbo].[PhoneNumber]     NULL,
    [PhoneNumber3]           [dbo].[PhoneNumber]   NULL,
    [EmailAddress]         [dbo].[EmailAddress] NULL,

    [LastModifiedById]       NVARCHAR(128)            NOT NULL,
    [LastModifiedDateTime] DATETIME       NOT NULL,

    [Name] as IIF(CompanyName is null, IsNull(LastName, '') + ', ' + IsNull(FirstName, ''), CompanyName) PERSISTED
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC),
);


GO
CREATE NONCLUSTERED INDEX [CustomerFNameLName]
    ON [dbo].[Customer]([FirstName] ASC, [LastName] ASC) ;


GO
CREATE NONCLUSTERED INDEX [CustomerIDFNameLName]
    ON [dbo].[Customer]([Id] ASC, [FirstName] ASC, [LastName] ASC) ;


GO
CREATE NONCLUSTERED INDEX [CustomersLNameFName]
    ON [dbo].[Customer]([LastName] ASC, [FirstName] ASC);

