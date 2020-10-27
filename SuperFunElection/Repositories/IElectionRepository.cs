using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection.Repositories
{
    public interface IElectionRepository
    {
        void AddElection(Election newElection);
    }
}
