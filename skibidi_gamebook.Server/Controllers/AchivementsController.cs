using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skibidi_gamebook.Server.Data;
using skibidi_gamebook.Server.Models;

namespace skibidi_gamebook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchivementsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AchivementsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Achivements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Achivement>>> GetAchivements()
        {
            return await _context.Achivements.ToListAsync();
        }

        // GET: api/Achivements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Achivement>> GetAchivement(int id)
        {
            var achivement = await _context.Achivements.FindAsync(id);

            if (achivement == null)
            {
                return NotFound();
            }

            return achivement;
        }

        // PUT: api/Achivements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAchivement(int id, Achivement achivement)
        {
            if (id != achivement.AId)
            {
                return BadRequest();
            }

            _context.Entry(achivement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchivementExists(id))
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

        // POST: api/Achivements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Achivement>> PostAchivement(Achivement achivement)
        {
            _context.Achivements.Add(achivement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAchivement", new { id = achivement.AId }, achivement);
        }

        // DELETE: api/Achivements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchivement(int id)
        {
            var achivement = await _context.Achivements.FindAsync(id);
            if (achivement == null)
            {
                return NotFound();
            }

            _context.Achivements.Remove(achivement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AchivementExists(int id)
        {
            return _context.Achivements.Any(e => e.AId == id);
        }
    }
}
