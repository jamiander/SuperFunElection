namespace SuperFunElection.requests
{
    public class AddCandidateToElectionRequest
    {
        public int ElectionId { get; set; }
        public int CandidateId { get; set; }
    }
}
