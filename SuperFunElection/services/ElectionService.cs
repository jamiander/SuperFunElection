using Microsoft.AspNetCore.DataProtection.Repositories;
using SuperFunElection.Controllers;
using SuperFunElection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection
{
    public class ElectionService : IElectionService
    {
        private IElectionRepository _electionRepository;

        public ElectionService(IElectionRepository electionRepository) {
            _electionRepository = electionRepository;
        }
        public async Task CreateElection(Election newElectionToCreate)
        {
            //var election = new Election();
            //election.CreateNewElection(newElectionToCreate.Id, newElectionToCreate.Date, newElectionToCreate.Candidates, newElectionToCreate.Ballots);
            _electionRepository.AddElection(newElectionToCreate);
        }
    }
}
