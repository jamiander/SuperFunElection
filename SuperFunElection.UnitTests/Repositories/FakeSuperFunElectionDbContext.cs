using Microsoft.EntityFrameworkCore;
using SuperFunElection.Data;
using SuperFunElection.Domain;
using System.Collections.Generic;

namespace SuperFunElection.UnitTests.Repositories
{
    public class FakeSuperFunElectionDbContext : SuperFunElectionDbContext
    {
        public FakeSuperFunElectionDbContext() : base(new DbContextOptionsBuilder<SuperFunElectionDbContext>().UseInMemoryDatabase("SuperFunDb").Options)
        {
            SeedWithFakeData();
        }

        private void SeedWithFakeData()
        {
            var existingCandidates = new List<Candidate>
            {
                new Candidate(1, PersonName.Create("Joe", "Biden"), null),
                new Candidate(2, PersonName.Create("Abraham", "Lincoln"), null),
                new Candidate(3, PersonName.Create("Richard", "Nixon"), null),
            };

            Candidates.AddRange(existingCandidates);
            SaveChanges();
        }
    }
}
