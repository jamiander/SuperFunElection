using Machine.Fakes;
using Machine.Specifications;
using SuperFunElection.Domain;
using SuperFunElection.Repositories;
using SuperFunElection.services;
using System.Threading.Tasks;

namespace SuperFunElection.UnitTests.Services.CandidateServiceTests
{
    public class When_getting_a_candidate_by_id : WithSubject<CandidateService>
    {
        protected static int FakeCandidateId;
        protected static Candidate Result;
        protected static Candidate FakeCandidateFromRepo;

        Establish that = () =>
        {
            FakeCandidateId = 17;

            FakeCandidateFromRepo = new Candidate(FakeCandidateId, PersonName.Create("DoesNot", "Matter"), null);

            The<ICandidateRepository>()
                .WhenToldTo(x => x.FindById(FakeCandidateId))
                .Return(Task.FromResult(FakeCandidateFromRepo));
        };

        Because of = async () =>
            Result = await Subject.SelectCandidate(FakeCandidateId);

        // We might not care about this - it's an implementation
        // detail that could change in theory
        It should_ask_the_repository_for_a_candidate = () =>
            The<ICandidateRepository>()
                .WasToldTo(x => x.FindById(FakeCandidateId))
                .OnlyOnce();

        It should_return_whatever_came_from_the_repo = () =>
            Result.ShouldEqual(FakeCandidateFromRepo);
            
    }
}
