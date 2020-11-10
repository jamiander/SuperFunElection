using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperFunElection.Domain;
using SuperFunElection.Domain.Specifications;
using SuperFunElection.requests;
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

        [HttpGet]
        public async Task<IActionResult> GetAllCandidates([FromQuery] GetAllCandidatesRequest request)
        {
            var query = new GetCandidatesByFilter(request.FirstName, request.LastName);
            var matchedCandidates = await _candidateService.GetCandidates(query);
            return Ok(matchedCandidates);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            var selectedCandidate = await _candidateService.SelectCandidate(id);
            return Ok(selectedCandidate);
            
        }

        [HttpPost()]
        public async Task<IActionResult> CreateNewCandidate(CreateNewCandidateRequest request)
        {
            var newPersonName = PersonName.Create(request.firstName, request.lastName);
            var newCandidate = new Candidate(newPersonName);
            var createdCandidate = await _candidateService.CreateCandidate(newCandidate);

            return CreatedAtAction(nameof(GetCandidateById), new { id = createdCandidate.Id }, createdCandidate);
        }
  
    }
}
