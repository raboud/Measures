CREATE TABLE [dbo].[MeasureMaterial]
(
	[Id] INT IDENTITY (1, 1)  NOT NULL PRIMARY KEY,
	[MaterialTypeId] INT not null,
	[MeasureId] int not null,
	[WidthId] int null,
	[AltWidthId] int null,

    [Description] NVARCHAR(50) NULL, 
    [PatternMatchWidth] DECIMAL(18, 3) NULL, 
    [PatternMatchLength] DECIMAL(18, 3) NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_MeasureMaterial_Measure] FOREIGN KEY ([MeasureId]) REFERENCES [dbo].[Measure] ([Id]) on delete cascade,
    CONSTRAINT [FK_MeasureMaterial_Width] FOREIGN KEY ([WidthId]) REFERENCES [dbo].[Width] ([Id]),
    CONSTRAINT [FK_MeasureMaterial_AltWidth] FOREIGN KEY ([AltWidthId]) REFERENCES [dbo].[Width] ([Id]),
    CONSTRAINT [FK_MeasureMaterial_MaterialType] FOREIGN KEY ([MaterialTypeId]) REFERENCES [dbo].[MaterialType] ([Id]),

)

GO

CREATE INDEX [IX_MeasureMaterial_MeasureId] ON [dbo].[MeasureMaterial] (MeasureId)

GO

CREATE INDEX [IX_MeasureMaterial_Id] ON [dbo].[MeasureMaterial] ([Id])
