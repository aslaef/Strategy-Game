using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Strategy_game.Context;
using Strategy_game.Models;

namespace Strategy_game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchersController : ControllerBase
    {
        private readonly ApplitactionDbContext _context;

        public ArchersController(ApplitactionDbContext context)
        {
            _context = context;
        }

        // GET: api/Archers
        [HttpGet]
        public IEnumerable<Archer> GetArchers()
        {
            return _context.Archers;
        }

        // GET: api/Archers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArcher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var archer = await _context.Archers.FindAsync(id);

            if (archer == null)
            {
                return NotFound();
            }

            return Ok(archer);
        }

        // PUT: api/Archers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArcher([FromRoute] int id, [FromBody] Archer archer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != archer.UnitId)
            {
                return BadRequest();
            }

            _context.Entry(archer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArcherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Archers
        [HttpPost]
        public async Task<IActionResult> PostArcher([FromBody] Archer archer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Archers.Add(archer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArcher", new { id = archer.UnitId }, archer);
        }

        // DELETE: api/Archers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArcher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var archer = await _context.Archers.FindAsync(id);
            if (archer == null)
            {
                return NotFound();
            }

            _context.Archers.Remove(archer);
            await _context.SaveChangesAsync();

            return Ok(archer);
        }

        private bool ArcherExists(int id)
        {
            return _context.Archers.Any(e => e.UnitId == id);
        }
    }
}