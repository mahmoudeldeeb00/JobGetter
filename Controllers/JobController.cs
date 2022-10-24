using JobGetter.BL.IRepository;
using JobGetter.DAL.Entities;
using JobGetter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobGetter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="User")]
    public class JobController : ControllerBase
    {
        private readonly IJobRep _job;
        private readonly UserManager<AppUser> _userManager;

        public JobController(IJobRep job,UserManager<AppUser> userManager)
        {
            this._job = job;
            _userManager = userManager;
        }
        [HttpPost("AddJobOpportunity")]
        public IActionResult AddJobOpportunity([FromBody]JobOpportunityVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = _job.AddJobOpprtunity(model);
            return result == "Good" ? Ok("Job opportunity Added Succesfully ") : BadRequest(result);
        }
      
        [HttpGet("Time Line ")]
        public IActionResult TimeLine()
        {
            var UserName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return UserName is not null ? Ok(_job.GetAppropriateJobOpportunitiesToUser(UserName)) : BadRequest("your User is not Found  ");         
        }
        [HttpPost("Request Jop Opportunity")]
        
        public IActionResult RequestJopOpportunity( [FromForm]JobOpportunityRequestVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _job.RequestJopOpportunity(model);
            return result == "Good" ? Ok("Request Confirmed Successfully") : BadRequest(result);

        }
        [HttpGet("Opprtunities in My City")]
        public IActionResult OpportunitiesInMyCity()
        {
            var UserName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return UserName is not null ? Ok(_job.GetOpportunitiesInMyCity(UserName)) : BadRequest("your User is not Found ");

        }
        [HttpGet("Opprtunities in My Country")]
     
        public IActionResult OpportunitiesInMyCountry()
        {
            var UserName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return UserName is not null ? Ok(_job.GetOpportunitiesInMyCountry(UserName)) : BadRequest("your User is not Found ");

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Finish The Opportunity")]       
        public IActionResult FinishOpportunity(int Id)
        {
            var result = _job.FinishOpportunity(Id);
            return result == "Good" ? Ok($" {result} : opportunity Finished Succesfully ") : BadRequest(result);
        }


    }
}
