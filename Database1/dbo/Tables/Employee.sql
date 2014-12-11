CREATE TABLE [dbo].[Employees] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [NickName]         NVARCHAR (50)  NULL,
    [Address1]         NVARCHAR (255) NULL,
    [Address2]         NVARCHAR (255) NULL,
    [City]             NVARCHAR (50)  NULL,
    [State]            NCHAR (2)      NOT NULL,
    [Zip]              NVARCHAR (10)  NULL,
    [PhoneNumber1]       [dbo].[PhoneNumber]  NULL,
    [PhoneNumber2]     [dbo].[PhoneNumber]  NULL,
    [SSN]              NVARCHAR (11)  NULL,
    [Email]            [dbo].[EmailAddress]  NULL,
    [SMTPEmail]        [dbo].[EmailAddress]  NULL,
    [ReceiveCallNotes] BIT            NOT NULL,
    [UserId] [dbo].[AspNetUserId] NOT NULL,
    [Active]           BIT            CONSTRAINT [DF__Employee_Active] DEFAULT (1) NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Id] ASC),

	);

