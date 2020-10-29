using SuperFunElection.Controllers;
using SuperFunElection.Repositories;
using System.Threading.Tasks;
using SuperFunElection.Domain;

namespace SuperFunElection
{
    public class ElectionService : IElectionService
    {
        private IElectionRepository _electionRepository;

        public ElectionService(IElectionRepository electionRepository) {
            _electionRepository = electionRepository;
        }

        public async Task<Election> CreateElection(Election newElectionToCreate)
        {
            var createdElection = await _electionRepository.AddElection(newElectionToCreate);
            return createdElection;
        }

        public async Task<Election> SelectElection(int id)
        {
            var selectElection = await _electionRepository.FindById(id);
            return selectElection;
        }
    }
}
