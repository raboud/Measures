CREATE TABLE [dbo].[ClientTypeReports]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ReportTypeID] INT NOT NULL, 
    [ClientTypeID] INT NOT NULL,
    [Location] NVARCHAR(255) NOT NULL, 
    CONSTRAINT [FK_ClientTypeReports_ReportTypes] FOREIGN KEY ([ReportTypeID]) REFERENCES [ReportType]([Id]), 
    CONSTRAINT [FK_ClientTypeReports_ClientType] FOREIGN KEY ([ClientTypeID]) REFERENCES [StoreType]([Id])
)
