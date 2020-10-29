using System;
using System.Linq.Expressions;

namespace SuperFunElection.Domain.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Filter();
    }
}
