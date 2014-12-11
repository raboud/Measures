CREATE TABLE [dbo].[OrderNotes] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [OrderId]            INT           NOT NULL,
    [NoteTypeId]         INT           NOT NULL,
    [SpokeWithId]        INT           NOT NULL,
    [ContactName]        VARCHAR (50)  NULL,
    [DateTimeEntered]    DATETIME      NOT NULL,
    [NoteText]           VARCHAR (MAX) NULL,
    [EnteredByUserId]    [dbo].[AspNetUserId]           NULL,
    [CustomerToCallBack] BIT           NOT NULL,
    [Scheduled]          BIT           NOT NULL,
    [UnScheduled]        BIT           NOT NULL,
    [ScheduledAM]        BIT           NULL,
    [ScheduledDate]      DATETIME      NULL,
    [Deleted]            BIT           NOT NULL,
    [SentViaXML]         BIT           NOT NULL,
    [DateTimeSent]       DATETIME      NULL,
    CONSTRAINT [PK_OrderNote] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderNote_EnteredBy] FOREIGN KEY ([EnteredByUserId]) REFERENCES [dbo].[Employee] ([UserId]),
    CONSTRAINT [FK_OrderNote_NoteType] FOREIGN KEY ([NoteTypeId]) REFERENCES [dbo].[NoteType] ([Id]),
    CONSTRAINT [FK_OrderNote_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_OrderNotes_OrderID]
    ON [dbo].[OrderNotes]([OrderId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OrderNotes_NoteTypeID]
    ON [dbo].[OrderNotes]([Id] ASC);

