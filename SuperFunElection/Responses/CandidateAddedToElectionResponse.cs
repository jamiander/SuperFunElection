namespace SuperFunElection.Responses
{
    public class CandidateAddedToElectionResponse
    {
        public int ElectionId { get; set; }
        public int[] CandidateIds { get; set; }
    }
}
