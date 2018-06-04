CREATE TABLE [dbo].[Item] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Description]          NVARCHAR (255) NULL,
    [WorkOrderDescription] NVARCHAR (255) NULL,
    [UnitOfMeasureId]      INT            NULL,
    [ApplyToMinimun]       BIT            NOT NULL,
    [PrintOnWorkOrder]     BIT            NOT NULL,
    [Active]               BIT            NOT NULL,
    [ApplyToMinimumWO]     BIT            NOT NULL,
    [Size]                 BIT            DEFAULT ((0)) NOT NULL,
    [JobSize]              BIT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Item_UnitOfMeasure] FOREIGN KEY ([UnitOfMeasureId]) REFERENCES [dbo].[UnitOfMeasure] ([Id])
);

