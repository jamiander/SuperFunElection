using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperFunElection.services;

namespace SuperFunElection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet("hc")]
        public async Task<IActionResult> HealthCheck()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            var selectedCandidate = await _candidateService.SelectCandidate(id);
            return Ok(selectedCandidate);
            //throw new NotImplementedException();
        }

        /*[HttpPost()]
        public async Task<IActionResult> CreateNewCandidate(CreateNewCandidateRequest request)
        {
            var newElection = new Candidate(request.Date, request.Description);
            var createdElection = await _candidateService.CreateCandidate(newCandidate);

            return CreatedAtAction(nameof(GetCandidateById), new { id = createdCandidate.Id }, createdCandidate);
        }*/
    }
}
