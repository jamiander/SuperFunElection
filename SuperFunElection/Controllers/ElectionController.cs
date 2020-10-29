using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperFunElection.requests;
using SuperFunElection.Domain;
using System;
using SuperFunElection.Responses;
using System.Linq;
using SuperFunElection.Domain.Specifications;

namespace SuperFunElection.Controllers
{
    // api/election
    [Route("api/[controller]")]
    [ApiController]
    public class ElectionController : ControllerBase
    {
        private IElectionService _electionService;

        public ElectionController(IElectionService electionService)
        {
            _electionService = electionService;
        }

        [HttpGet("hc")]
        public async Task<IActionResult> HealthCheck()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllElections([FromQuery] GetAllElectionsRequest request)
        {
            var query = new GetElectionsByFilter(request.StartDate, request.EndDate, request.DescriptionSegment);
            var matchedElections = await _electionService.GetElections(query);
            return Ok(matchedElections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetElectionById(int id)
        {
            var selectedElection = await _electionService.SelectElection(id);
            if(selectedElection == null)
            {
                return NotFound($"Election with id {id} was not found.");
            }

            var response = new ElectionDetailResponse
            {
                Id = selectedElection.Id,
                Description = selectedElection.Description,
                Date = selectedElection.Date.ToShortDateString(),
                Results = selectedElection.Candidacies.Select(c => new ElectionDetailResponse.CandidateItem { 
                    FirstName = c.Candidate.Name.FirstName,
                    LastName = c.Candidate.Name.LastName,
                    Votes = c.Ballots.Count()
                })
            };

            return Ok(response);         
        }

        [HttpPost()]
        public async Task<IActionResult> CreateNewElection(CreateNewElectionRequest request)
        {
            var newElection = new Election(request.Date, request.Description);
            var createdElection = await _electionService.CreateElection(newElection);

            var response = new ElectionCreatedResponse
            {
                Id = createdElection.Id
            };

            return CreatedAtAction(nameof(GetElectionById), new { id = createdElection.Id }, response);
        }
    }
}

