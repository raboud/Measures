CREATE TABLE [dbo].[CheckCBDetail] (
    [Id] INT             IDENTITY (1, 1) NOT NULL,
    [CheckID]         INT             NOT NULL,
    [ChargeBackID]    INT             NOT NULL,
    [Amount]          NUMERIC (19, 2) NOT NULL,
    CONSTRAINT [PK_CheckCBDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CheckCBDetail_ChargeBacks] FOREIGN KEY ([ChargeBackID]) REFERENCES [dbo].[ChargeBack] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CheckCBDetail_Checks] FOREIGN KEY ([CheckID]) REFERENCES [dbo].[Check] ([Id]) ON DELETE CASCADE
);

