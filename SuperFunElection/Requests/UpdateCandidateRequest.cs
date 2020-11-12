using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection.Requests
{
    public class UpdateCandidateRequest
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
