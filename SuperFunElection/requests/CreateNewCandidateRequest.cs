using SuperFunElection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection.requests
{
    public class CreateNewCandidateRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        //public PersonName Name { get; set; }

    }
}
