CREATE TABLE [dbo].[DivisionGroup] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (50) NULL,
    CONSTRAINT [PK_DivisionGroup] PRIMARY KEY CLUSTERED ([Id] ASC)
);

