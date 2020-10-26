using System.Collections.Generic;

namespace SuperFunElection
{
    public class Ballot
    {
        public Ballot() { }
        public Ballot (int id, string voterName, int electionId, int candidateId)
        {
            Id = id;
            Voter = voterName;
            ElectionId = electionId;
            CandidateId = candidateId;
        }

        int Id { get; set; }
        string Voter { get; set; }
        int ElectionId { get; set; }
        int CandidateId { get; set; }
    }
}
