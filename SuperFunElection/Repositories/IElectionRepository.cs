using System.Threading.Tasks;
using SuperFunElection.Domain;

namespace SuperFunElection.Repositories
{
    public interface IElectionRepository
    {
        Task<Election> AddElection(Election newElection);
        Task<Election> FindById(int id);
    }
}
