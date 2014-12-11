CREATE TABLE [dbo].[CompanyInfo] (
    [Id]              INT       IDENTITY (1, 1) NOT NULL,
    [Name]            NCHAR(50) NULL,
    [Address1]        NCHAR(50) NULL,
    [Address2]        NCHAR(50) NULL,
    [City]            NCHAR(30) NULL,
    [State]           NCHAR(2)  NULL,
    [Zip]             NCHAR(10) NULL,
    [Phone1]          NCHAR(13) NULL,
    [Phone2]          NCHAR(13) NULL,
    [Fax1]            NCHAR(13) NULL,
    [Fax2]            NCHAR(13) NULL,
    [VendorNumber]    NCHAR(15) NULL,
    [WaiverSignature] IMAGE     NULL,
    [Logo]            IMAGE     NULL,
    [QRCodePrefix]    CHAR (1)  NULL,
    [TollFree] NCHAR(13) NULL, 
    CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED ([Id] ASC)
)