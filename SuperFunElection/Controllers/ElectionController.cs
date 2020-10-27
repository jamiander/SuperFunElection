using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperFunElection.requests;
using SuperFunElection.Domain;
using System;

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

        //TODO: Get Rid of this

        //[HttpPost ("test")]
        //public async Task<IActionResult> CreateNewElection()
        //{
        //    List<Candidate> can1 = new List<Candidate>
        //    {
        //        new Candidate (1, "Henry", "Blake", 1)
        //    };
        //    List<Ballot> ballot1 = new List<Ballot>
        //    {
        //        new Ballot (1, "Alice", 1, 1)
        //    };
        //    var newElection = new Election(1, "November", can1, ballot1);
        //    return Ok("this worked");
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetElectionById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost()]
        public async Task<IActionResult> CreateNewElection(CreateNewElectionRequest request)
        {
            var newElection = new Election(request.Date, request.Description);
            var createdElection = await _electionService.CreateElection(newElection);

            return CreatedAtAction(nameof(GetElectionById), new { id = createdElection.Id }, createdElection);
        }
    }
}

