CREATE TABLE [dbo].[Ballot] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [VoterName]   VARCHAR (100) NOT NULL,
    [CandidacyId] INT           NOT NULL,
    CONSTRAINT [PK_Ballot] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Ballot_Candidacies] FOREIGN KEY ([CandidacyId]) REFERENCES [dbo].[Candidacies] ([Id])
);

