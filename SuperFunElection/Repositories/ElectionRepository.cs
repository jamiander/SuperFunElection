using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperFunElection.Data;
using SuperFunElection.Domain;
using SuperFunElection.Domain.Specifications;

namespace SuperFunElection.Repositories
{
    public class ElectionRepository : IElectionRepository
    {
        private SuperFunElectionDbContext _dbContext;

        public ElectionRepository(SuperFunElectionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Election> AddElection(Election newElection)
        {
            _dbContext.Elections.Add(newElection);
            await _dbContext.SaveChangesAsync();
            return newElection;
        }

        public async Task<Election> FindById(int id)
        {
            Election selectedElection = _dbContext.Elections.Find(id);

            return selectedElection;
        }

        public async Task<IEnumerable<Election>> FindByQuery(ISpecification<Election> electionSpecification)
        {
            var validElections = _dbContext.Elections.Where(electionSpecification.Filter());
            return await validElections.ToListAsync();
        }

        public Task<Election> UpdateCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
        }
    }
}
