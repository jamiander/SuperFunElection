using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuperFunElection.Domain.Specifications
{
    public class GetSelectedCandidatesSpecification : ISpecification<Candidate>
    {
        public Expression<Func<Candidate, bool>> Filter()
        {
            throw new NotImplementedException();
        }
    }
}
