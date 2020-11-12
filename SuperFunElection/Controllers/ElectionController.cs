using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperFunElection.requests;
using SuperFunElection.Domain;
using System;
using SuperFunElection.Responses;
using System.Linq;
using SuperFunElection.Domain.Specifications;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using SuperFunElection.Requests;
using System.Collections.Generic;
using SuperFunElection.Repositories;

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

        //URL: POST api/election/17/candidates
        [HttpPost("{id}/candidates")]
        public async Task<IActionResult> AddCandidateToElection(AddCandidateToElectionRequest request)
        {
            var election = await _electionService.AddCandidateToElection(request.ElectionId, request.CandidateId);

            var response = new CandidateAddedToElectionResponse
            {
                ElectionId = election.Id,
                CandidateIds = election.Candidacies.Select(x => x.Candidate.Id).ToArray()
            };

            return Ok(response);
        }

         [HttpPost("{id}/votes")]
        public async Task<IActionResult> AddVoteToElection(AddVoteToElectionRequest request)
        {
            var Voter = PersonName.Create(request.firstName, request.lastName);
             
            Election election = await _electionService.AddVoteToElection(request.ElectionId, request.CandidateId, Voter);
            var currentCandidacy = election.Candidacies.First(x => x.Candidate.Id == request.CandidateId);
            var response = new VoteAddedToElectionResponse
            {
                ElectionId = request.ElectionId,
                CandidateId = request.CandidateId,
                VoterName = Voter,
                TotalVotes = currentCandidacy.Ballots.Count()
            };
            
            return Ok(response);
        }

        [HttpPost("{id}/deleteCandidacy")]
        public async Task<IActionResult> DeleteCandidacy(DeleteCandidacyRequest request)
        {
            var selectedCandidacy = await _electionService.DeleteCandidacy(request.CandidateId, request.ElectionId);

            var response = new DeleteCandidacyResponse
            {

                CandidacyId = selectedCandidacy.Id

            };

            return Ok(response);
        }

        [HttpPost("{id}/terminateCandidacy")]
        public async Task<IActionResult> TerminateCandidacy(TerminateCandidacyRequest request)
        {
            var selectedCandidacy = await _electionService.TerminateCandidacy(request.CandidateId, request.ElectionId, DateTime.Now);

            var response = new TerminateCandidacyResponse
            {

                CandidacyId = selectedCandidacy.Id,
                DateTime = DateTime.Now

            };

            return Ok(response);
        }
    }
}

