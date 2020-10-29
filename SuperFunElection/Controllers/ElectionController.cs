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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetElectionById(int id)
        {
            var selectedElection = await _electionService.SelectElection(id);
            if(selectedElection == null)
            {
                return NotFound($"Election with id {id} was not found.");
            }
            return Ok(selectedElection);
            
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

