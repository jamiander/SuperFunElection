using System;

namespace SuperFunElection.requests
{
    public class CreateNewElectionRequest
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
