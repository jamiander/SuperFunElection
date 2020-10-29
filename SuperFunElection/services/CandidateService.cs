using SuperFunElection.Domain;
using SuperFunElection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
