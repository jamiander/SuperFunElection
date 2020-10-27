using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperFunElection.requests;

namespace SuperFunElection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectionController : ControllerBase
    {
        private IElectionService _electionService;

        public ElectionController(IElectionService electionService)
        {
            _electionService = electionService;
        }

        [HttpGet ("test")]
        public async Task<IActionResult> TestElection()
        {
            return Ok("This is a election!");
        }

        [HttpPost ("test")]
        public async Task<IActionResult> CreateNewElection()
        {
            List<Candidate> can1 = new List<Candidate>
            {
                new Candidate (1, "Henry", "Blake", 1)
            };
            List<Ballot> ballot1 = new List<Ballot>
            {
                new Ballot (1, "Alice", 1, 1)
            };
            var newElection = new Election(1, "November", can1, ballot1);
            return Ok("this worked");
        }

        [HttpPost ("create")]

        public async Task<IActionResult> CreateNewElection(CreateNewElectionRequest request)
        {

            var newElection = new Election(request.Id, request.Date, request.Candidates, request.Ballots);
            await _electionService.CreateElection(newElection);
            return Ok();
        }
    }
}

