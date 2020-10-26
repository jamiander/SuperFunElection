using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection.requests
{
    public class CreateNewElectionRequest
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public List<Candidate> Candidates { get; set; }
        public List<Ballot> Ballots { get; set; }
    }
}
