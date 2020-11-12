using SuperFunElection.Domain;
using SuperFunElection.Domain.Specifications;
using SuperFunElection.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperFunElection.services
{
    public class CandidateService : ICandidateService
    {
        private ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<Candidate> CreateCandidate(Candidate newCandidateToCreate)
        {
            var createdCandidate = await _candidateRepository.AddCandidate(newCandidateToCreate);
            return createdCandidate;
        }

        public async Task<Candidate> SelectCandidate(int id)
        {
            var selectCandidate = await _candidateRepository.FindById(id);
            return selectCandidate;
        }

        public async Task<IEnumerable<Candidate>> GetSelectedCandidate()
        {
            var candidates = await _candidateRepository.FindByQuery(new GetSelectedCandidatesSpecification());
            return candidates;
        }

        public async Task<IEnumerable<Candidate>> GetCandidates(GetCandidatesByFilter query)
        {
            var candidates = await _candidateRepository.FindByQuery(query);
            return candidates;
        }

        public async Task<Candidate> UpdateCandidate(int candidateId, string firstName, string lastName)
        {
            var updatedCandidate = await _candidateRepository.FindById(candidateId);
            updatedCandidate.Update(firstName, lastName);

            await _candidateRepository.UpdateCandidate(updatedCandidate);

            return updatedCandidate;
        }

    }
}
