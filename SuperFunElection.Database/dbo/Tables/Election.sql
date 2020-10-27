CREATE TABLE [dbo].[Election] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Date]        DATE          NOT NULL,
    [Description] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Election] PRIMARY KEY CLUSTERED ([Id] ASC)
);

