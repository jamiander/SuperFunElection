using SuperFunElection.Data;
using SuperFunElection.Domain;
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
    }
}
