CREATE TABLE [dbo].[Measure]
(
	[Id] INT  IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
	[CustomerId] INT not null,
    [Enterred] DATETIME NOT NULL,

    CONSTRAINT [FK_Measure_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]),
)
