using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SuperFunElection.Domain
{
    public class Election : Entity
    {
        protected Election() { }

        public Election(DateTime date, string description) : this(0, date, description, null)
        {
        }

        public Election(int id, DateTime date, string description, List<Candidacy> candidacies) : this()
        {
            Id = id;
            Date = date;
            Description = description;
            _candidacies = candidacies ?? new List<Candidacy>();
        }

        public DateTime Date { get; private set; }
        public string Description { get; private set; }

        private List<Candidacy> _candidacies = new List<Candidacy>();
        public IReadOnlyCollection<Candidacy> Candidacies => _candidacies.AsReadOnly();

        public void AddCandidate(Candidate candidate)
        {
            if (candidate is null)
                throw new ArgumentNullException(nameof(candidate), "You must add an existing candidate to an election.");

            var isThisCandidateADuplicate = _candidacies.FirstOrDefault(x => x.Candidate == candidate) != null;

            if(!isThisCandidateADuplicate)
            {
                var candidacy = new Candidacy(this, candidate, null);
                _candidacies.Add(candidacy);
            }
        }
    }
}
