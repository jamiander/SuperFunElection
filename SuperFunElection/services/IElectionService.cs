using System.Collections.Generic;
using System.Threading.Tasks;
using SuperFunElection.Domain;
using SuperFunElection.Domain.Specifications;

namespace SuperFunElection.Controllers
{
    public interface IElectionService
    {
        Task<Election> CreateElection(Election newElection);
        Task<Election> SelectElection(int id);
        Task<IEnumerable<Election>> GetElections(GetElectionsByFilter query);
    }
}