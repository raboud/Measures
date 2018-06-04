CREATE TABLE [dbo].[Document] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Description]     NVARCHAR (255) NULL,
    [PathAndFilename] NVARCHAR (512) NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED ([Id] ASC)
);

