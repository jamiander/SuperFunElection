using SuperFunElection.Domain;
using SuperFunElection.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperFunElection.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> AddCandidate(Candidate newCandidate);
        Task<Candidate> FindById(int id);
        Task<IEnumerable<Candidate>> FindByQuery(ISpecification<Candidate> candidateSpecification);
        Task<Candidate> UpdateCandidate(Candidate candidate);
    }
}
