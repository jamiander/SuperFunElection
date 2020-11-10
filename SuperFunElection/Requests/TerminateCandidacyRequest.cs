using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection.Requests
{
    public class TerminateCandidacyRequest
    {
        public int ElectionId { get; set; }
        public int CandidateId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
