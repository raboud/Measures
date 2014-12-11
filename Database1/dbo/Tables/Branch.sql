CREATE TABLE [dbo].[Branch] (
    [Id]      INT            NOT NULL IDENTITY,
    [Name]    NVARCHAR (40)  NOT NULL,
    [PrinterName]   NVARCHAR (50)  DEFAULT (null) NULL,
    [PrinterPort]   NVARCHAR (50)  DEFAULT (null) NULL,
    [PrinterDriver] NVARCHAR (50)  DEFAULT (null) NULL,
    [Address]       NVARCHAR (255) NULL,
    [City]          NVARCHAR (50)  NULL,
    [State]         NCHAR (2)      NULL,
    [ZipCode]       NCHAR (10)     NULL,
    [PhoneNumber]   NCHAR (13)     NULL,
    [FaxNumber]     NCHAR (13)     NULL,
    [ManagerId]     INT            NULL,
    [Active]        BIT            DEFAULT ((1)) NOT NULL,
    [Latitude]      FLOAT (53)     NULL,
    [Longitude]     FLOAT (53)     NULL,
    [LabelPrinter] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_Branch_Manager] FOREIGN KEY ([ManagerId]) REFERENCES [dbo].[Employees] ([Id])
);

