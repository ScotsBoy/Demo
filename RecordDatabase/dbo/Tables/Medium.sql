﻿CREATE TABLE [dbo].[Medium] (
    [MediumId] INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Medium] PRIMARY KEY CLUSTERED ([MediumId] ASC)
);

