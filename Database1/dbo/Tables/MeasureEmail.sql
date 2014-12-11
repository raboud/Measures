CREATE TABLE [dbo].[MeasureEmail]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MeasureId] INT NOT NULL, 
	[EmailTemplateId] int not null,
    [Sent] DATETIME NOT NULL

    CONSTRAINT [FK_MeasureEmail_Measure] FOREIGN KEY ([MeasureId]) REFERENCES [dbo].[Measure] ([Id]),
    CONSTRAINT [FK_OrderEmail_EmailTemplate] FOREIGN KEY ([EmailTemplateId]) REFERENCES [dbo].[EmailTemplate] ([Id]),

)
