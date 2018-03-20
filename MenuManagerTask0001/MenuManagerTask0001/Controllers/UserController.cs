using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Abstract;
using BL.DTO;
using BL.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuManagerTask0001.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: api/user
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _userManager.GetAllUsers();

                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

        }
        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] UserDto userDto)
        {
            try
            {
                if(!ValidateObjectHelper.IsUserDtoValid(userDto))
                {
                    return BadRequest("User object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                userDto = _userManager.AddUser(userDto);
                if(userDto != null)
                {
                    return Ok(userDto);
                }

                return StatusCode(500, "Internal server error");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
