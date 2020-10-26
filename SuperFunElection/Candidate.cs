using System.Collections.Generic;

namespace SuperFunElection
{
    public class Candidate
    {
        public Candidate() { }
        public Candidate(int id, string firstName, string lastName, int electionId)
        {
            Id = id;
            Fname = firstName;
            Lname = lastName;
            ElectionId = electionId;
        }

        int Id { get; set; }
        string Fname { get; set; }
        string Lname { get; set; }
        int ElectionId { get; set; }
    }

}
