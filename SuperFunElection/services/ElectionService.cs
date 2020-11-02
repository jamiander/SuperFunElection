using SuperFunElection.Controllers;
using SuperFunElection.Repositories;
using System.Threading.Tasks;
using SuperFunElection.Domain;
using System.Collections.Generic;
using SuperFunElection.Domain.Specifications;

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

        public async Task<IEnumerable<Election>> GetOpenElections()
        {
            var elections = await _electionRepository.FindByQuery(new GetOpenElectionsSpecification());
            return elections;
        }

        public async Task<IEnumerable<Election>> GetElections(GetElectionsByFilter query)
        {
            var elections = await _electionRepository.FindByQuery(query);
            return elections;
        }

        public Task<Election> AddCandidateToElection(int electionId, int candidateId)
        {
            throw new System.NotImplementedException();
        }
    }
}
