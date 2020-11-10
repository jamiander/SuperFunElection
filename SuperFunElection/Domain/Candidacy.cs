using System;
using System.Collections.Generic;

namespace SuperFunElection.Domain
{
    public class Candidacy : Entity
    {
        protected Candidacy() { }

        public Candidacy(Election election, Candidate candidate, List<Ballot> ballots)
            : this(election, candidate, DateTime.Now, null, ballots) { }

        public Candidacy(Election election, Candidate candidate, DateTime instatedOn, List<Ballot> ballots)
            : this(election, candidate, instatedOn, null, ballots) { }

        public Candidacy(Election election, Candidate candidate, DateTime instatedOn, DateTime? terminatedOn, List<Ballot> ballots)
        {
            Election = election;
            Candidate = candidate;
            InstatedOn = instatedOn;
            TerminatedOn = terminatedOn;
            _ballots = ballots ?? new List<Ballot>();
        }

        public Election Election { get; private set; }
        public Candidate Candidate { get; private set; }
        public DateTime InstatedOn { get; private set; }
        public DateTime? TerminatedOn { get; private set; }

        public bool IsValidCandidate => TerminatedOn.HasValue;

        private List<Ballot> _ballots = new List<Ballot>();
        public IReadOnlyCollection<Ballot> Ballots => _ballots.AsReadOnly();

        public void AddBallot(Ballot ballot)
        {
            _ballots.Add(ballot);
        }

        public void UpdateCandidacy(DateTime dateTime)
        {
            TerminatedOn = dateTime;
        }
    }
}
