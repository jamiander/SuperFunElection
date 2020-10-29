using System.Collections.Generic;

namespace SuperFunElection.Responses
{
    public class ElectionDetailResponse
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public IEnumerable<CandidateItem> Results { get; set; } = new List<CandidateItem>();

        public class CandidateItem
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Votes { get; set;}
        }
    }
}
