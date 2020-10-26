using System.Threading.Tasks;

namespace SuperFunElection.Controllers
{
    public interface IElectionService
    {
        Task CreateElection(Election newElection);
    }
}