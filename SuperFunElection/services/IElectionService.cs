using System.Threading.Tasks;
using SuperFunElection.Domain;

namespace SuperFunElection.Controllers
{
    public interface IElectionService
    {
        Task<Election> CreateElection(Election newElection);
    }
}