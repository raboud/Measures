CREATE TABLE [dbo].[StoreType] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [StoreTypeName] NVARCHAR (50) NULL,
    [ImageName]     NVARCHAR (50) NULL,
    [Logo]          IMAGE         NULL,
    [QBClass] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_StoreType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

