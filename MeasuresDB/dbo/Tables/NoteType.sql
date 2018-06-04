CREATE TABLE [dbo].[NoteType] (
    [Id]                         INT           IDENTITY (1, 1) NOT NULL,
    [NoteTypeDescription]        NVARCHAR (50) NOT NULL,
    [ShowInList]                 BIT           NOT NULL,
    [ShowEmployees]              BIT           NOT NULL,
    [ShowSpokeWith]              BIT           NOT NULL,
    [RequireSpokeWith]           BIT           NOT NULL,
    [EnableSchedulingInfo]       BIT           NOT NULL,
    [CanSendToExpeditor]         BIT           NOT NULL,
    [ShowStoreManagement]        BIT           CONSTRAINT [DF_NoteType_ShowStoreManagement] DEFAULT (0) NOT NULL,
    [PermissionRequiredToSelect] BIT           CONSTRAINT [DF_NoteType_RequirePermission] DEFAULT (0) NOT NULL,
    [DisplayOrder]               TINYINT       NULL,
    CONSTRAINT [PK_NoteTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

