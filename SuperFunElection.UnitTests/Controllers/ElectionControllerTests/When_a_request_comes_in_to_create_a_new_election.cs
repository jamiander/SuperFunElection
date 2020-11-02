using Machine.Fakes;
using Machine.Specifications;
using Microsoft.AspNetCore.Mvc;
using SuperFunElection.Controllers;
using SuperFunElection.Domain;
using SuperFunElection.requests;
using SuperFunElection.Responses;
using System;
using System.Threading.Tasks;

namespace SuperFunElection.UnitTests.Controllers.ElectionControllerTests
{
    public class When_a_request_comes_in_to_create_a_new_election : WithSubject<ElectionController>
    {
        protected static CreateNewElectionRequest FakeNewElectionRequest;
        protected static CreatedAtActionResult Result;

        protected static DateTime FakeElectionDate;
        protected static string FakeElectionDescription;
        protected static Election FakeCreatedElection;
        protected static int FakeCreatedElectionId;

        Establish that =()=>
        {
            FakeElectionDate = new DateTime(2020, 2, 11);
            FakeElectionDescription = "My New Election";

            FakeCreatedElectionId = 17;

            FakeNewElectionRequest = new CreateNewElectionRequest
            {
                Date = FakeElectionDate,
                Description = FakeElectionDescription
            };

            FakeCreatedElection = new Election(FakeCreatedElectionId, FakeElectionDate, FakeElectionDescription, null);

            The<IElectionService>()
                .WhenToldTo(service => service.CreateElection(Param<Election>.Matches(election => election.Date == FakeElectionDate && election.Description == FakeElectionDescription)))
                .Return(Task.FromResult(FakeCreatedElection));
        };

        Because of = async ()=>
        {
            Result = (CreatedAtActionResult)await Subject.CreateNewElection(FakeNewElectionRequest);
        };

        It should_ask_the_service_to_create_the_new_election =()=>
            The<IElectionService>().WasToldTo(service => service.CreateElection(Param<Election>.Matches(election => election.Date == FakeElectionDate && election.Description == FakeElectionDescription)));

        It should_return_a_created_status_code =()=>
            Result.StatusCode.ShouldEqual(201);

        It should_return_the_new_id =()=>
            ((ElectionCreatedResponse)Result.Value).Id.ShouldEqual(FakeCreatedElectionId);

        It should_contain_the_url_to_access_the_new_election = () =>
             Result.RouteValues["id"].ShouldEqual(FakeCreatedElectionId);
    }
}
