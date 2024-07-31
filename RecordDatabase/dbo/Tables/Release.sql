CREATE TABLE [dbo].[Release] (
    [ReleaseId]     INT            IDENTITY (1, 1) NOT NULL,
    [ArtistId]      INT            NOT NULL,
    [Name]          VARCHAR (50)   NOT NULL,
    [ReleaseTypeId] INT            NOT NULL,
    [MediumId]      INT            NOT NULL,
    [Runtime]       VARBINARY (50) NOT NULL,
    [ReleaseDate]   DATE           NOT NULL,
    CONSTRAINT [PK_Release] PRIMARY KEY CLUSTERED ([ReleaseId] ASC),
    CONSTRAINT [FK_Release_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artist] ([ArtistId]),
    CONSTRAINT [FK_Release_Medium] FOREIGN KEY ([MediumId]) REFERENCES [dbo].[Medium] ([MediumId]),
    CONSTRAINT [FK_Release_ReleaseType] FOREIGN KEY ([ReleaseTypeId]) REFERENCES [dbo].[ReleaseType] ([ReleaseTypeId])
);

