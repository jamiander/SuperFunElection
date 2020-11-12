using Machine.Fakes;
using Machine.Specifications;
using SuperFunElection.Domain;
using SuperFunElection.Repositories;
using SuperFunElection.services;
using System.Threading.Tasks;

namespace SuperFunElection.UnitTests.Services.CandidateServiceTests
{
    public class When_updating_a_candidate : WithSubject<CandidateService>
    {
        protected static int FakeCandidateId;
        protected static Candidate Result;
        protected static Candidate FakeCandidateFromRepo;
        protected static string NewFirstName;
        protected static string NewLastName;

        Establish that = () =>
        {
            FakeCandidateId = 17;

            FakeCandidateFromRepo = new Candidate(FakeCandidateId, PersonName.Create("DoesNot", "Matter"), null);

            The<ICandidateRepository>()
                .WhenToldTo(x => x.FindById(FakeCandidateId))
                .Return(Task.FromResult(FakeCandidateFromRepo));

            NewFirstName = "Marky";
            NewLastName = "Mark";
        };

        Because of = async () =>
            Result = await Subject.UpdateCandidate(FakeCandidateId, NewFirstName, NewLastName);

        It should_ask_the_repo_to_save_changes_with_the_new_names = () =>
            The<ICandidateRepository>()
                .WasToldTo(x => x.UpdateCandidate(Param<Candidate>.Matches(c => c.Name.FirstName == NewFirstName && c.Name.LastName == NewLastName)));

        It should_return_the_candidate_with_the_new_first_name = () =>
            Result.Name.FirstName.ShouldEqual(NewFirstName);

        It should_return_the_candidate_with_the_new_last_name = () =>
            Result.Name.LastName.ShouldEqual(NewLastName);
    }
}
