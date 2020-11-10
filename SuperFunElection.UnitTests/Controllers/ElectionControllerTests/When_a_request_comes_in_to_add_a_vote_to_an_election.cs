using FakeItEasy.Configuration;
using Machine.Fakes;
using Machine.Specifications;
using Microsoft.AspNetCore.Mvc;
using SuperFunElection.Controllers;
using SuperFunElection.Domain;
using SuperFunElection.requests;
using SuperFunElection.Requests;
using SuperFunElection.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFunElection.UnitTests.Controllers.ElectionControllerTests
{
    class When_a_request_comes_in_to_add_a_vote_to_an_election : WithSubject<ElectionController>
    {
        protected static OkObjectResult Result;

        protected static AddVoteToElectionRequest FakeAddVoteToElectionRequest;
        protected static VoteAddedToElectionResponse FakeVoteAddedToElectionResponse;
        protected static Election FakeElection;
        protected static Candidate FakeCandidate;
        protected static string FakeVoterFirstName;
        protected static string FakeVoterLastName;
        protected static PersonName FakeVoter;
        protected static Ballot FakeBallot;
        
        protected static int FakeElectionId = 1;
        protected static int FakeCandidateId = 4;
        protected static int FakeBallotId = 1;
        protected static Candidacy FakeCandidacy;

        Establish that = () =>
        {
            FakeVoterFirstName ="Salvador";
            FakeVoterLastName = "Dali";
            FakeVoter = new PersonName(FakeVoterFirstName, FakeVoterLastName);

            FakeAddVoteToElectionRequest = new AddVoteToElectionRequest
            {
                ElectionId = FakeElectionId,
                CandidateId = FakeCandidateId,
                firstName = FakeVoterFirstName,
                lastName = FakeVoterLastName
            };

            FakeVoteAddedToElectionResponse = new VoteAddedToElectionResponse
            {
                CandidateId = FakeCandidateId
            };


            FakeCandidate = new Candidate(FakeCandidateId, PersonName.Create("Carol", "Cunningham"), null);

            FakeCandidacy = new Candidacy(FakeElection, FakeCandidate, null);
            FakeBallot = new Ballot(FakeBallotId, FakeVoter, FakeCandidacy);

            FakeElection = new Election(FakeElectionId, DateTime.Now, "Fake Description", new List<Candidacy> { FakeCandidacy });

            The<IElectionService>()
                .WhenToldTo(x => x.AddVoteToElection(FakeElectionId, FakeCandidateId, FakeVoter))
                .Return(Task.FromResult(FakeElection));
        };

        Because of = async () =>
        {
            Result = (OkObjectResult)await Subject.AddVoteToElection(FakeAddVoteToElectionRequest);
        };
   
        It should_have_a_successful_status_code = () =>
            Result.StatusCode.ShouldEqual(200);

        //It should_have_the_ballot_in_the_list = () =>
        //     ((VoteAddedToElectionResponse)Result.Value).Ballots.ShouldContain(FakeBallot);


    }
}

