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

    public class When_addcandidate_is_called_to_add_candidate_to_election_and_the_candidate_is_null : WithSubject<Election>
    {
        protected static Exception _expectedException;

        Because of = () => _expectedException = Catch.Exception(() => Subject.AddCandidate(null));

        It should_throw_an_exception = () =>
            _expectedException.ShouldNotBeNull();

        // This is probably more specific than I actually need bc it really
        // doesn't matter what type the exception is in the code
        It should_be_an_argument_null_exception = () =>
            _expectedException.ShouldBeAssignableTo<ArgumentNullException>();
            
    }

    public class When_addcandidate_is_called_to_add_candidate_to_election_and_the_candidate_is_a_duplicate : WithSubject<Election>
    {
        protected static Candidate FakeCandidate1;
        protected static Candidate FakeCandidate2;

        Establish that = () =>
        {
            FakeCandidate1 = new Candidate(1, PersonName.Create("Jennifer", "Lawrence"), null);
            FakeCandidate2 = new Candidate(2, PersonName.Create("Billy Bob", "Thornton"), null);

            Subject.AddCandidate(FakeCandidate1);
            Subject.AddCandidate(FakeCandidate2);
        };

        Because of = () =>
            Subject.AddCandidate(FakeCandidate2);

        It should_not_add_the_same_candidate_twice = () =>
            Subject.Candidacies
                .Where(x => x.Candidate.Id == FakeCandidate2.Id)
                .Count()
                .ShouldEqual(1);

    }
}
