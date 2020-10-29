using System;

namespace SuperFunElection.requests
{
    public class GetAllElectionsRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string DescriptionSegment { get; set; }
    }
}
