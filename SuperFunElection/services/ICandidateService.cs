using SuperFunElection.Domain;
using SuperFunElection.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection.services
{
    public interface ICandidateService
    {
        Task<Candidate> SelectCandidate(int id);
        Task<Candidate> CreateCandidate(Candidate candidate);
        Task<IEnumerable<Candidate>> GetCandidates(GetCandidatesByFilter query);
        Task<IEnumerable<Candidate>> GetSelectedCandidate();


    }
}
