using System;
using System.Collections.Generic;

namespace SuperFunElection.Domain
{
    public class Candidacy : Entity
    {
        public Election Election { get; private set; }
        public Candidate Candidate { get; private set; }
        public DateTime InstatedOn { get; private set; }
        public DateTime? TerminatedOn { get; private set; }

        public bool IsValidCandidate => TerminatedOn.HasValue;

        private List<Ballot> _ballots = new List<Ballot>();
        public IReadOnlyCollection<Ballot> Ballots => _ballots.AsReadOnly();
    }
}
