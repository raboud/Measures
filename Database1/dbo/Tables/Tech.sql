CREATE TABLE [dbo].[Tech]
(
	[Id] INT  IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[Active] bit not null DEFAULT 1,
    [FirstName]            NVARCHAR (50)  NOT NULL,
    [LastName]             NVARCHAR (50)  NOT NULL,
    [Address]              NVARCHAR (255) NULL,
    [Address2]             NVARCHAR (255) NULL,
    [City]                 NVARCHAR (50)  NULL,
    [State]                NCHAR (2)      CONSTRAINT [DF__TECH__State] DEFAULT ('GA') NULL,
    [ZipCode]              NVARCHAR(10)     NULL,
    [Latitude]             FLOAT (53)     NULL,
    [Longitude]            FLOAT (53)     NULL,

    [PhoneNumber1]          [dbo].[PhoneNumber]     NULL,
    [PhoneNumber2]         [dbo].[PhoneNumber]     NULL,
    [EmailAddress]         [dbo].[EmailAddress] NOT NULL,

    [LastModifiedById]       NVARCHAR(128)            NOT NULL,
    [LastModifiedDateTime] DATETIME       NOT NULL,

    [Name] as LastName + ', ' + FirstName PERSISTED, 
    [UserId] NVARCHAR(128) NOT NULL

)

