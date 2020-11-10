using SuperFunElection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection.Responses
{
    public class VoteAddedToElectionResponse
    {
        public int CandidateId { get; set; }
        public int ElectionId { get; set; }
        public PersonName VoterName { get; set; }
        public int TotalVotes { get; set; }

    }
}
