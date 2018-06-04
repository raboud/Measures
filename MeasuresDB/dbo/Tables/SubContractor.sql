CREATE TABLE [dbo].[SubContractor] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]                 NVARCHAR (30)   NULL,
    [LastName]                  NVARCHAR (50)   NULL,
    [NickName]                  NVARCHAR (50)   NULL,
    [Address]                   NVARCHAR (255)  NULL,
    [City]                      NVARCHAR (50)   NULL,
    [State]                     NVARCHAR (20)   NULL,
    [ZipCode]                   NVARCHAR (20)   NULL,
    [HomePhoneNumber]           NVARCHAR (30)   NULL,
    [CellPhoneNumber]           NVARCHAR (30)   NULL,
    [Pager]                     NVARCHAR (30)   NULL,
    [SSN]                       NVARCHAR (50)   NULL,

    [WorkmansCompInsuranceOK]   BIT             CONSTRAINT [DF__SubContractors__WorkmansCompInsuranceOK] DEFAULT (0) NULL,
    [LiabilityInsuranceOK]      BIT             CONSTRAINT [DF__SubContractor__LiabilityInsuranceOK] DEFAULT (0) NULL,
    [BackgroundCheckPassed]     BIT             NOT NULL,
	[BackgroundRptRequested]    BIT             DEFAULT (0) NOT NULL,
    [Helper]                    BIT             DEFAULT (0) NOT NULL,


    [Notes]                     NTEXT           NULL,

    [Retainage]                 MONEY           NULL,
    [SavingsRate]               FLOAT (53)      CONSTRAINT [DF__SubContractor__SavingsRate] DEFAULT (0) NULL,
    [RetainageRate]             DECIMAL (18, 2) CONSTRAINT [DF__SubContractor__RetainageRate] DEFAULT (0.1) NULL,
    [InsuranceRate]             DECIMAL (18, 2) DEFAULT (0.0) NOT NULL,
    [InsuranceDollarAmount]     DECIMAL (18, 2) DEFAULT (0.0) NOT NULL,

    [BadgeStatus]               NVARCHAR (50)   DEFAULT (null) NULL,

    [AssignedTo]                INT             NULL,
    [BranchId]                  INT             DEFAULT (1) NULL,
    [Status]                    INT             DEFAULT (1) NOT NULL,
    [StateId]                   INT             DEFAULT ((-1)) NOT NULL,

    [WorkmansCompInsuranceDate] Date   NULL,
    [LiabilityInsuranceDate]    DATE   NULL,
    [BackgroundChkDateApproved] DATE   NULL,

    [PictureFilename]           NVARCHAR (255)  NULL,
    [QBSubContractorId]         VARCHAR (50)    NULL,
	[Name] as  IsNull(LastName, '') + ', ' + IsNull(FirstName, '') PERSISTED
    CONSTRAINT [PK_SubContractor] PRIMARY KEY CLUSTERED ([Id] ASC)
);

