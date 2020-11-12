using Machine.Fakes;
using Machine.Specifications;
using Microsoft.AspNetCore.Mvc;
using SuperFunElection.Controllers;
using SuperFunElection.Domain;
using SuperFunElection.Responses;
using SuperFunElection.services;
using System.Threading.Tasks;

namespace SuperFunElection.UnitTests.Controllers.CandidateControllerTests
{
    public class When_getting_a_candidate_by_id : WithSubject<CandidateController>
    {
        protected static int FakeCandidateId;
        protected static Candidate FakeCandidate;
        protected static PersonName FakeCandidateName;
        protected static IActionResult Result;

        Establish that = () =>
        {
            FakeCandidateId = 17;
            FakeCandidateName = PersonName.Create("Sadie", "Hawkins");
            FakeCandidate = new Candidate(FakeCandidateId, FakeCandidateName, null);

            The<ICandidateService>()
                .WhenToldTo(x => x.SelectCandidate(FakeCandidateId))
                .Return(Task.FromResult(FakeCandidate));
        };

        Because of = async () =>
            Result = await Subject.GetCandidateById(FakeCandidateId);

        It should_be_an_ok_result = () =>
            Result.ShouldBeOfExactType<OkObjectResult>();

        It should_return_some_response_data = () =>
            ((OkObjectResult)Result).Value.ShouldNotBeNull();

        // In this particular case, the mapping is trivial, but
        // if it were not, I could do this:
        It should_include_the_correct_first_name_in_the_response = () =>
        {
            var controllerResultAfterConversionToOkObjectResult = (OkObjectResult)Result;
            var objectTheResultContainsConvertedToGetCandidateByIdResponse = (GetCandidateByIdResponse)controllerResultAfterConversionToOkObjectResult.Value;

            objectTheResultContainsConvertedToGetCandidateByIdResponse.CandidateId.ShouldEqual(FakeCandidateId);
        };
    }

    public class When_getting_a_candidate_by_id_and_the_candidate_is_not_found : WithSubject<CandidateController>
    {
        protected static int FakeCandidateId;
        protected static IActionResult Result;

        Establish that = () =>
        {
            FakeCandidateId = 17;

            The<ICandidateService>()
                .WhenToldTo(x => x.SelectCandidate(FakeCandidateId))
                .Return(Task.FromResult<Candidate>(null));
        };

        Because of = async () =>
            Result = await Subject.GetCandidateById(FakeCandidateId);

        It should_return_a_not_found_result = () =>
            Result.ShouldBeOfExactType<NotFoundResult>();
    }
}
