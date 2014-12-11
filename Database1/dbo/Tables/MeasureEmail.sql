CREATE TABLE [dbo].[MeasureEmail]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MeasureId] INT NOT NULL, 
	[EmailTypeId] int not null,
    [Sent] DATETIME NOT NULL

    CONSTRAINT [FK_MeasureEmail_Measure] FOREIGN KEY ([MeasureId]) REFERENCES [dbo].[Measure] ([Id]),
    CONSTRAINT [FK_OrderEmail_EmailType] FOREIGN KEY ([EmailTypeId]) REFERENCES [dbo].[EmailType] ([Id]),

)
