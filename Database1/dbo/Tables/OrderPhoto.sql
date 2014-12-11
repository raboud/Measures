CREATE TABLE [dbo].[POPhotos] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [FilePath]        NVARCHAR (50) NULL,
    [EnteredByUserID] INT           NULL,
    [OrderID]         INT           NOT NULL,
    [Deleted]         BIT           NOT NULL,
    [DateTimeEntered] DATETIME      NOT NULL,
    [Title]           NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_POPhoto] PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_POPhotos_Orders] FOREIGN KEY ([OrderID]) REFERENCES [Order]([Id])
);

