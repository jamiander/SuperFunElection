using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SuperFunElection.Domain.Specifications
{
    public class GetCandidatesByFilter : SpecificationBase<Candidate>
    {
        private string _firstName;
        private string _lastName;
        
        public GetCandidatesByFilter(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            
        }

        public override Expression<Func<Candidate, bool>> Filter()
        {
            Expression<Func<Candidate, bool>> query = x => true;
            if (!String.IsNullOrEmpty(_firstName))
                query = And(query, x => x.Name.FirstName.Contains(_firstName));
            if (!String.IsNullOrEmpty(_lastName))
                query = And(query, x => x.Name.LastName.Contains(_lastName));
            return query;
        }
    }
}
