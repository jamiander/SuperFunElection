using Microsoft.AspNetCore.Mvc;
using SuperFunElection.Domain;
using SuperFunElection.Domain.Specifications;
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

    }
}
