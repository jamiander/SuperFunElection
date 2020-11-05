using Machine.Fakes;
using Machine.Specifications;
using SuperFunElection.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperFunElection.UnitTests.Domains
{
    class when_addcandidate_is_called_to_add_candidate_to_election : WithSubject<Election>
    {
        protected static Election FakeElection;
        protected static Election FakeNewElection;
        protected static Candidate FakeCandidate;
        protected static Election Result;

        protected static DateTime FakeElectionDate;
        protected static string FakeElectionDescription;
        protected static int FakeElectionId;
        protected static List<Candidacy> FakeCandidacies;

        protected static string FakeCandidateFirstName;
        protected static string FakeCandidateLastName;
        protected static int FakeCandidateId;
        protected static PersonName FakePersonName;

        
        Establish that = () =>
         {
             FakeElectionDate = new DateTime(2020, 11, 3);
             FakeElectionDescription = "New Election";
             FakeElectionId = 17;
             FakeCandidacies = new List<Candidacy>();

             FakeCandidateFirstName = "Ada";
             FakeCandidateLastName = "Lovelace";
             FakeCandidateId = 20;
             
             FakePersonName = new PersonName(FakeCandidateFirstName, FakeCandidateLastName);
             FakeCandidate = new Candidate(FakeCandidateId, FakePersonName, null);
             FakeElection = new Election(17, FakeElectionDate, FakeElectionDescription, FakeCandidacies);

         };


        Because of = () =>
         {
             FakeElection.AddCandidate(FakeCandidate);
         };

        It should_have_a_candidacy_in_the_candidacy_list = () =>
             FakeElection.Candidacies.ShouldNotBeEmpty();
    }
}
