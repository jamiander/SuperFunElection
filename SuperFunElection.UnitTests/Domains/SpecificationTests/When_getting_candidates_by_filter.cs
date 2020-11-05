using Machine.Fakes;
using Machine.Specifications;
using SuperFunElection.Domain;
using SuperFunElection.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperFunElection.UnitTests.Domains.SpecificationTests
{
    public class When_getting_candidates_by_filter_by_first_name : WithSubject<GetCandidatesByFilter>
    {
        protected static List<Candidate> CandidateList;
        protected static List<Candidate> FilteredCandidateList;
        protected static GetCandidatesByFilter QueryFilter;

        Establish that = () =>
        {
            QueryFilter = new GetCandidatesByFilter("Fred", null);

            // Prepopulate a list to query
            CandidateList = new List<Candidate>
            {
                new Candidate(1, PersonName.Create("Johnny", "Bravo"), null),
                new Candidate(2, PersonName.Create("Johnny", "Blaze"), null),
                new Candidate(3, PersonName.Create("Johnny", "Five"), null),
                new Candidate(4, PersonName.Create("Fred", "Flintstone"), null)
            };
        };

        Because of = () =>
            FilteredCandidateList = CandidateList.AsQueryable().Where(QueryFilter.Filter()).ToList();

        It should_find_only_the_candidates_with_matching_first_name = () =>
            FilteredCandidateList.All(x => x.Name.FirstName == "Fred").ShouldBeTrue();
    }
}
