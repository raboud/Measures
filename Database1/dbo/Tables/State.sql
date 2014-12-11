CREATE TABLE [dbo].[State] (
    [Id]           INT            NOT NULL,
    [Name]         NVARCHAR (255) NULL,
    [Abbreviation] NCHAR(2) NULL,
    CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED ([Id] ASC)
);

