using SuperFunElection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection.requests
{
    public class GetAllCandidatesRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
