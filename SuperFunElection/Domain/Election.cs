using System;
using System.Collections.Generic;

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
    }
}
