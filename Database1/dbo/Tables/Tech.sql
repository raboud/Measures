CREATE TABLE [dbo].[Tech]
(
	[Active] bit not null DEFAULT 1,
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

    [LastModifiedById]       [dbo].[AspNetUserId]            NOT NULL,
    [LastModifiedDateTime] DATETIME       NOT NULL,

    [UserId] [dbo].[AspNetUserId] NOT NULL, 
    PRIMARY KEY ([UserId])

)

