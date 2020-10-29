using System;
using System.Linq.Expressions;

namespace SuperFunElection.Domain.Specifications
{
    public class GetOpenElectionsSpecification : ISpecification<Election>
    {
        public Expression<Func<Election, bool>> Filter()
        {
            return election => election.Date >= DateTime.Now;
        }
    }
}
