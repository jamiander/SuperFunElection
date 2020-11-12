using Machine.Specifications;
using SuperFunElection.Domain;
using SuperFunElection.Repositories;

namespace SuperFunElection.UnitTests.Repositories
{
    public class When_getting_a_candidate_by_id
    {
        protected static FakeSuperFunElectionDbContext FakeDbContext;
        protected static CandidateRepository Subject;
        protected static Candidate Result;
        protected static int CandidateIdToFind;

        Establish that = () =>
        {
            CandidateIdToFind = 2;
            FakeDbContext = new FakeSuperFunElectionDbContext();
            Subject = new CandidateRepository(FakeDbContext);
        };

        Because of = async () =>
            Result = await Subject.FindById(CandidateIdToFind);

        It should_give_me_the_candidate_at_that_id = () =>
            Result.Id.ShouldEqual(CandidateIdToFind);
    }
}
