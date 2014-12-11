CREATE TABLE [dbo].[JobType] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Description]           NVARCHAR (50) NULL,
    [AlwaysSkipInitialCall] BIT           CONSTRAINT [DF_JobTypes_AlwaysSkipInitialCall] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_JobType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

