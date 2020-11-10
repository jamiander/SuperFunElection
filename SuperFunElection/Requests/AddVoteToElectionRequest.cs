using SuperFunElection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection.Requests
{
    public class AddVoteToElectionRequest
    {
        public int ElectionId { get; set; }
        public int CandidateId { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }

    }
}
