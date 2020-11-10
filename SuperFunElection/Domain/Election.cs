using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

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

        public void VoteFor(Candidate candidate, PersonName voter)
        {

            if (candidate is null)
                throw new ArgumentNullException(nameof(candidate), "You must vote for an existing candidate.");

            //var candidacy = new Candidacy(this, candidate, null);

            
            //if (voter != null) 
            //    throw new ArgumentException(nameof(voter), "You have already cast a vote.");

            var candidacyToAddVote = _candidacies.Find(x => x.Candidate == candidate);
            var ballot = new Ballot(voter, candidacyToAddVote);

            if (candidacyToAddVote != null)
            {
                candidacyToAddVote.AddBallot(ballot);
            }


            // Basic guards - null candidate, etc.
            // Is this candidate in this election?

            // Has this voter already submitted a ballot?

            // Find the candidacy

            // Create a new Ballot()

            // Add the Ballot to the candidacy's ballot list
        }
    }
}
