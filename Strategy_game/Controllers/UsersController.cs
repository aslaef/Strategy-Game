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

        //// GET: api/Users
        //[HttpGet]
        //public IEnumerable<User> GetUsers()
        //{
        //    return _context.Users;
        //}

        //// GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetUser([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = await _context.Users.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(user);
        //}

        //// PUT: api/Users/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != user.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

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



        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return Ok(user);
        //}

        //private bool UserExists(int id)
        //{
        //    return _context.Users.Any(e => e.UserId == id);
        //}
    }
}