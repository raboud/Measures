CREATE TABLE [dbo].[EmailTemplate] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
	[EmailTypeId]	int NOT NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    [Content] TEXT          NOT NULL,
    CONSTRAINT [PK_EmailTemplate] PRIMARY KEY CLUSTERED ([Id] ASC),

    CONSTRAINT [FK_EmailTemplate_EmailType] FOREIGN KEY ([EmailTypeId]) REFERENCES [dbo].[EmailType] ([Id]),
);

