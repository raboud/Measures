CREATE TABLE [dbo].[MeasureMaterial]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[MaterialTypeId] INT not null,
	[MeasureId] int not null,
	[WidthId] int not null,
	[AltWidthId] int not null,

    CONSTRAINT [FK_MeasureMaterial_Measure] FOREIGN KEY ([MeasureId]) REFERENCES [dbo].[Measure] ([Id]),
    CONSTRAINT [FK_MeasureMaterial_Width] FOREIGN KEY ([WidthId]) REFERENCES [dbo].[Width] ([Id]),
    CONSTRAINT [FK_MeasureMaterial_AltWidth] FOREIGN KEY ([AltWidthId]) REFERENCES [dbo].[Width] ([Id]),
    CONSTRAINT [FK_MeasureMaterial_MaterialType] FOREIGN KEY ([MaterialTypeId]) REFERENCES [dbo].[MaterialType] ([Id]),

)
