using Machine.Fakes;
using Machine.Specifications;
using SuperFunElection.Domain;
using SuperFunElection.Repositories;
using System;
using System.Threading.Tasks;

namespace SuperFunElection.UnitTests.Services.ElectionServiceTests
{
    public class When_creating_a_new_election : WithSubject<ElectionService>
    {
        protected static Election FakeIncomingElection;
        protected static Election FakeAddedElection;
        protected static Election Result;

        protected static DateTime FakeElectionDate;
        protected static string FakeElectionDescription;
        protected static int FakeElectionId;

        Establish that =()=>
        {
            FakeElectionDate = new DateTime(2020, 11, 3);
            FakeElectionDescription = "New Election";
            FakeElectionId = 17;

            FakeIncomingElection = new Election(FakeElectionDate, FakeElectionDescription);
            FakeAddedElection = new Election(FakeElectionId, FakeElectionDate, FakeElectionDescription, null);


            The<IElectionRepository>()
                .WhenToldTo(x => x.AddElection(FakeIncomingElection))
                .Return(Task.FromResult(FakeAddedElection));
        };

        Because of = async ()=>
        {
            Result = await Subject.CreateElection(FakeIncomingElection);
        };

        // NOTE: This ties to an implemention, not a result
        It should_ask_the_repository_to_add_the_election =()=>
            The<IElectionRepository>().WasToldTo(x => x.AddElection(FakeIncomingElection));

        It should_have_an_id =()=>
            Result.Id.ShouldEqual(FakeElectionId);

        // I probably wouldn't bother to check this
        It should_have_the_same_date =()=>
            Result.Date.ShouldEqual(FakeIncomingElection.Date);

        // Or this
        It should_have_the_same_description = () =>
             Result.Description.ShouldEqual(FakeIncomingElection.Description);
    }
}
