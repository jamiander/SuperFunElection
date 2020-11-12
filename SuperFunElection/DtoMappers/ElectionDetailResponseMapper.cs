using SuperFunElection.Domain;
using SuperFunElection.Responses;
using System.Linq;

namespace SuperFunElection.DtoMappers
{
    public class ElectionDetailResponseMapper : IMap<Election, ElectionDetailResponse>
    {
        public ElectionDetailResponse MapFrom(Election selectedElection)
        {
            var response = new ElectionDetailResponse
            {
                Id = selectedElection.Id,
                Description = selectedElection.Description,
                Date = selectedElection.Date.ToShortDateString(),
                Results = selectedElection.Candidacies.Select(c => new ElectionDetailResponse.CandidateItem
                {
                    FirstName = c.Candidate.Name.FirstName,
                    LastName = c.Candidate.Name.LastName,
                    Votes = c.Ballots.Count()
                })
            };

            return response;
        }
    }
}
