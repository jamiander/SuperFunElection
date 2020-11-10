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
        public Candidacy Candidacy { get; set; }
        public Ballot Ballot { get; set; }
        public object ElectionId { get; set; }
        public int[] CandidateIds { get; set; }
        //public List<Ballot> Ballots { get; internal set; }

        //public List<Ballot> Ballots { get; set; }

    }
}
