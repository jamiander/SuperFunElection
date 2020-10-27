﻿using System.Collections.Generic;

namespace SuperFunElection.Domain
{
    public class Candidate : Entity
    {
        public Candidate() { }
        public Candidate(int id, PersonName name, List<Candidacy> electionCandidacies)
        {
            Id = id;
            Name = name;
            _electionCandidacies = electionCandidacies;
        }

        public PersonName Name { get; private set; }

        private List<Candidacy> _electionCandidacies = new List<Candidacy>();
        public IReadOnlyCollection<Candidacy> ElectionCandidacies => _electionCandidacies.AsReadOnly();
    }
}
