using Machine.Fakes;
using Machine.Specifications;
using Microsoft.AspNetCore.Mvc;
using SuperFunElection.Controllers;
using SuperFunElection.Domain;
using SuperFunElection.requests;
using SuperFunElection.Responses;
using SuperFunElection.services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperFunElection.UnitTests.Controllers.ElectionControllerTests
{
    public class When_a_request_comes_in_to_add_a_candidate_to_an_election : WithSubject<ElectionController>
    {
        protected static OkObjectResult Result;

        protected static AddCandidateToElectionRequest FakeAddCandidateToElectionRequest;
        protected static CandidateAddedToElectionResponse FakeCandidateAddedToElectionResponse;
        protected static Election FakeElection;
        protected static Candidate FakeCandidate;
        protected static Candidacy FakeCandidacy;

        protected static int FakeElectionId = 1;
        protected static int FakeCandidateId = 4;

        Establish that =()=>
        {
            FakeAddCandidateToElectionRequest = new AddCandidateToElectionRequest
            {
                ElectionId = FakeElectionId,
                CandidateId = FakeCandidateId
            };

            FakeCandidateAddedToElectionResponse = new CandidateAddedToElectionResponse
            {
                ElectionId = FakeElectionId,
                CandidateIds = new int[]
                {
                    FakeCandidateId
                }
            };

            FakeCandidate = new Candidate(FakeCandidateId, PersonName.Create("Carol", "Cunningham"), null);

            FakeCandidacy = new Candidacy(FakeElection, FakeCandidate, null);

            FakeElection = new Election(FakeElectionId, DateTime.Now, "Fake Description", new List<Candidacy>{ FakeCandidacy });

            The<IElectionService>()
                .WhenToldTo(x => x.AddCandidateToElection(FakeElectionId, FakeCandidateId))
                .Return(Task.FromResult(FakeElection));
        };

        Because of = async ()=>
        {
            Result = (OkObjectResult) await Subject.AddCandidateToElection(FakeAddCandidateToElectionRequest);
        };

        It should_have_the_candidate_in_the_list =()=>
            ((CandidateAddedToElectionResponse)Result.Value).CandidateIds.ShouldContain(FakeCandidateId);

        It should_have_a_successful_status_code =()=>
            Result.StatusCode.ShouldEqual(200);
    }
}
