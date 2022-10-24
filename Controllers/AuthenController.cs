using JobGetter.BL.IRepository;
using JobGetter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobGetter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAuthenRep _authenRep;
        public AuthenController(IAuthenRep aservice)
        {
            _authenRep = aservice;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authenRep.RegisterAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpPost("Token")]
        public async Task<IActionResult> GetTokenAsync([FromForm] TokenModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authenRep.GetTokenAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            return Ok(result);
        }


        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromForm] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authenRep.addRoleAsync(model);
            return Ok(result);
        }




    }
}
