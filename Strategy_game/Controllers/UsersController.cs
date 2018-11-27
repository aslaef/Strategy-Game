using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Strategy_game.Context;
using Strategy_game.Dto;
using Strategy_game.Models;
using Strategy_game.ServiceInterfaces;

namespace Strategy_game.Controllers
{
    
    public class UsersController : Controller
    {
        private readonly ApplitactionDbContext _context;
        private readonly IUsersService usersService;


        public UsersController(ApplitactionDbContext context, IUsersService us)
        {
            _context = context;
            usersService = us;
        }

        // POST: api/Users
        [HttpPost, Route("api/register")]
        public async Task<IActionResult> PostUser([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            usersService.RegisterUser(user);

            return CreatedAtAction("GetUser", new { id = 10 }, user);
        }

        [HttpPost, Route("api/login")]
        public IActionResult Login([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var countryId = usersService.Login(user);

            return Ok(countryId);
        }

        [HttpGet, Route("api/userscore")]
        public IActionResult UsersScore()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userscores = usersService.usersScore();
            return Ok(userscores);
        }

    }
}