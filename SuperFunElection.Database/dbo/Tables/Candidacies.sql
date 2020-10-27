CREATE TABLE [dbo].[Candidacies] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [ElectionId]    INT      NOT NULL,
    [CandidateId]   INT      NOT NULL,
    [EstablishedOn] DATETIME CONSTRAINT [DF_Candidacies_EstablishedOn] DEFAULT (getdate()) NOT NULL,
    [TerminatedOn]  DATETIME NULL,
    CONSTRAINT [PK_Candidacies] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Candidacies_Candidate] FOREIGN KEY ([CandidateId]) REFERENCES [dbo].[Candidate] ([Id]),
    CONSTRAINT [FK_Candidacies_Election] FOREIGN KEY ([ElectionId]) REFERENCES [dbo].[Election] ([Id])
);

