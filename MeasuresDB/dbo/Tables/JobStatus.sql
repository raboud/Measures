CREATE TABLE [dbo].[JobStatus] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [JobStatusDescription] NVARCHAR (50) NULL,
    CONSTRAINT [PK_JobStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);

