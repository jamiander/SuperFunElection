CREATE TABLE [dbo].[Candidate] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (20) NOT NULL,
    [LastName]  VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_Candidate] PRIMARY KEY CLUSTERED ([Id] ASC)
);

