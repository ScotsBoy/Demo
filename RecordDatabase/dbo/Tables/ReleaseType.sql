CREATE TABLE [dbo].[ReleaseType] (
    [ReleaseTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ReleaseType] PRIMARY KEY CLUSTERED ([ReleaseTypeId] ASC)
);

