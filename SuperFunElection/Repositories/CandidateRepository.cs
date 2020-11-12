using Microsoft.EntityFrameworkCore;
using SuperFunElection.Data;
using SuperFunElection.Domain;
using SuperFunElection.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private SuperFunElectionDbContext _dbContext;

        public CandidateRepository(SuperFunElectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Candidate> AddCandidate(Candidate newCandidate)
        {
            _dbContext.Candidates.Add(newCandidate);
            await _dbContext.SaveChangesAsync();
            return newCandidate;
        }

        public async Task<Candidate> FindById(int id)
        {
            Candidate selectedCandidate = _dbContext.Candidates.Find(id);

            return selectedCandidate;
        }

        public async Task<IEnumerable<Candidate>> FindByQuery(ISpecification<Candidate> candidateSpecification)
        {
            var validCandidates = _dbContext.Candidates.Where(candidateSpecification.Filter());
            return await validCandidates.ToListAsync();
        }

        public async Task<Candidate> UpdateCandidate(Candidate candidate)
        {
            await _dbContext.SaveChangesAsync();
            return candidate;
        }

    }
}
