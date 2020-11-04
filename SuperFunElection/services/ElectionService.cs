using SuperFunElection.Controllers;
using SuperFunElection.Repositories;
using System.Threading.Tasks;
using SuperFunElection.Domain;
using System.Collections.Generic;
using SuperFunElection.Domain.Specifications;
using System.Linq;

namespace SuperFunElection
{
    public class ElectionService : IElectionService
    {
        private IElectionRepository _electionRepository;
        private ICandidateRepository _candidateRepository;

        public ElectionService(IElectionRepository electionRepository, ICandidateRepository candidateRepository) {
            _electionRepository = electionRepository;
            _candidateRepository = candidateRepository;
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

        public async Task<Election> AddCandidateToElection(int electionId, int candidateId)
        {
            // Get the election that we're going to use
            var election = await _electionRepository.FindById(electionId);

            if (election is null)
                throw new KeyNotFoundException(nameof(electionId));

            // Find the candidate (assumption: only adding existing candidates)
            var candidate = await _candidateRepository.FindById(candidateId);

            if (candidate is null)
                throw new KeyNotFoundException(nameof(candidateId));

            // Add the candidate to the election's list

            election.AddCandidate(candidate);

            _electionRepository.UpdateCandidate(candidate);

            return election;
        }
    }
}
