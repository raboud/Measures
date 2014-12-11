CREATE TABLE [dbo].[Tech]
(
	[Id] INT  IDENTITY (1, 1) NOT NULL PRIMARY KEY,
    [FirstName]            NVARCHAR (50)  NOT NULL,
    [LastName]             NVARCHAR (50)  NOT NULL,
    [Address]              NVARCHAR (255) NULL,
    [Address2]             NVARCHAR (255) NULL,
    [City]                 NVARCHAR (50)  NULL,
    [State]                NCHAR (2)      CONSTRAINT [DF__TECH__State] DEFAULT ('GA') NULL,
    [ZipCode]              NCHAR (10)     NULL,
    [Latitude]             FLOAT (53)     NULL,
    [Longitude]            FLOAT (53)     NULL,

    [HomeNumber]          [dbo].[PhoneNumber]     NULL,
    [MobileNumber]         [dbo].[PhoneNumber]     NULL,
    [EmailAddress]         [dbo].[EmailAddress] NULL,

    [LastModifiedBy]       INT            NULL,
    [LastModifiedDateTime] DATETIME       NULL,

    [Name] as LastName + ', ' + FirstName PERSISTED

)

