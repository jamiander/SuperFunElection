using System;
using System.Threading.Tasks;
using SuperFunElection.Data;
using SuperFunElection.Domain;

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
    }
}
