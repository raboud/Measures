CREATE TABLE [dbo].[Division] (
    [Id]         INT       IDENTITY (1, 1) NOT NULL,
    [Name]           CHAR (20) NULL,
    [VendorID]           INT       NULL,
    [DivisionGroupId]    INT       DEFAULT (1) NOT NULL,
    [PrintStatusReport]  BIT       DEFAULT (1) NOT NULL,
    [MarkBilledWhenPaid] BIT       DEFAULT (0) NOT NULL,
    [Active]             BIT       DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Division] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Division_DivisionGroup] FOREIGN KEY ([DivisionGroupId]) REFERENCES [dbo].[DivisionGroup] ([Id])
);

