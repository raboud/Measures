CREATE TABLE [dbo].[UnitOfMeasure] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Description]         NVARCHAR (50) NOT NULL,
    [Divisor]             INT           NOT NULL,
    [NumberOfDecimals]    INT           NULL,
    [LongDescription]     NVARCHAR (50) NULL,
    [LongDescriptionSOSI] NVARCHAR (50) NULL,
    CONSTRAINT [PK_UnitOfMeasure] PRIMARY KEY CLUSTERED ([Id] ASC)
);

