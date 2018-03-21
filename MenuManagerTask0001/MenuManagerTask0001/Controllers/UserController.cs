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
                return NotFound();
            }

        }
        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] UserDto userDto)
        {
            try
            {
                if(!ValidateObjectHelper.IsUserDtoValid(userDto) || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                userDto = _userManager.AddUser(userDto);
                if(userDto != null)
                {
                    return Ok(userDto);
                }

                return Unauthorized();
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
