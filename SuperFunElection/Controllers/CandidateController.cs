using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperFunElection.Domain;
using SuperFunElection.Domain.Specifications;
using SuperFunElection.requests;
using SuperFunElection.Requests;
using SuperFunElection.Responses;
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

            if (selectedCandidate == null)
                return NotFound();

            var result = new GetCandidateByIdResponse
            {
                CandidateId = selectedCandidate.Id,
                FirstName = selectedCandidate.Name.FirstName,
                LastName = selectedCandidate.Name.LastName
            };

            return Ok(result); 
        }

        [HttpPost()]
        public async Task<IActionResult> CreateNewCandidate(CreateNewCandidateRequest request)
        {
            var newPersonName = PersonName.Create(request.firstName, request.lastName);
            var newCandidate = new Candidate(newPersonName);
            var createdCandidate = await _candidateService.CreateCandidate(newCandidate);

            return CreatedAtAction(nameof(GetCandidateById), new { id = createdCandidate.Id }, createdCandidate);
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> UpdateCandidate(UpdateCandidateRequest request)
        {
            var updatedCandidate = await _candidateService.UpdateCandidate(request.CandidateId, request.FirstName, request.LastName);

            var response = new UpdateCandidateResponse
            {
                CandidateId = updatedCandidate.Id,
                FirstName = updatedCandidate.Name.FirstName,
                LastName = updatedCandidate.Name.LastName
            };

            return Ok(response);

        }

    }
}
