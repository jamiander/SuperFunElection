using System;
using System.Collections.Generic;

namespace SuperFunElection.Domain
{
    public class Candidate : Entity
    {
        public Candidate() { }

        public Candidate(PersonName name) : this(0, name, null)
        {
        }
        public Candidate(int id, PersonName name, List<Candidacy> electionCandidacies)
        {
            Id = id;
            Name = name;
            _electionCandidacies = electionCandidacies ?? new List<Candidacy>();
        }

        public PersonName Name { get; set; }

        private List<Candidacy> _electionCandidacies = new List<Candidacy>();
        public IReadOnlyCollection<Candidacy> ElectionCandidacies => _electionCandidacies.AsReadOnly();

        public void AddCandidacy(Candidacy candidacy)
        {
            _electionCandidacies.Add(candidacy);
        }

        public void Update(string firstName, string lastName)
        {
            Name = PersonName.Create(firstName, lastName);
        }
    }
}
