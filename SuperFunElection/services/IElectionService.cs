using System;
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
        Task<Election> AddCandidateToElection(int electionId, int candidateId);
        Task<Election> AddVoteToElection(int electionId, int candidateId, PersonName voter);
        Task<Election> DeleteCandidacy(int candidateId, int electionId);
        Task<Election> TerminateCandidacy(int candidateId, int electionId, DateTime dateTime);

    }
}