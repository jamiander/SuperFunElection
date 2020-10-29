using System;
using System.Linq.Expressions;

namespace SuperFunElection.Domain.Specifications
{
    public class GetElectionsByFilter : SpecificationBase<Election>
    {
        private DateTime? _startDate;
        private DateTime? _endDate;
        private string _descriptionSegment;

        public GetElectionsByFilter(DateTime? startDate, DateTime? endDate, string descriptionSegment)
        {
            _startDate = startDate;
            _endDate = endDate;
            _descriptionSegment = descriptionSegment;
        }

        public override Expression<Func<Election, bool>> Filter()
        {
            // 1. Establish a base expression with no criteria
            Expression<Func<Election, bool>> query = x => true; // Everybody passes!

            // 2. If there's a start date, add that in
            if (_startDate.HasValue)
                query = And(query, x => x.Date >= _startDate);

            // 3. If there's an end date, add that in
            if (_endDate.HasValue)
                query = And(query, x => x.Date <= _endDate);

            // 4. If there's a description segment, add that in
            if (!String.IsNullOrEmpty(_descriptionSegment))
                query = And(query, x => x.Description.Contains(_descriptionSegment));

            // 5. Return expression
            return query;
        }
    }
}
