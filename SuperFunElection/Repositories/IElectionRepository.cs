using System.Collections.Generic;
using System.Threading.Tasks;
using SuperFunElection.Domain;
using SuperFunElection.Domain.Specifications;

namespace SuperFunElection.Repositories
{
    public interface IElectionRepository
    {
        Task<Election> AddElection(Election newElection);
        Task<Election> FindById(int id);
        Task<IEnumerable<Election>> FindByQuery(ISpecification<Election> electionSpecification);
        Task<Election> UpdateCandidate(Candidate candidate);
    }
}
