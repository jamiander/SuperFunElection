using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection
{
    public class ElectionService
    {
        public async Task CreateElection(Election newElectionToCreate)
        {
            var election = new Election();
            election.CreateNewElection(newElectionToCreate.Id, newElectionToCreate.Date, newElectionToCreate.Candidates, newElectionToCreate.Ballots);
            
        }
    }
}
