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
    public class ConnectionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConnectionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Connections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Connection>>> GetConnections()
        {
            return await _context.Connections.ToListAsync();
        }

        // GET: api/Connections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Connection>> GetConnection(int id)
        {
            var connection = await _context.Connections.FindAsync(id);

            if (connection == null)
            {
                return NotFound();
            }

            return connection;
        }

        // GET: api/Connections/From/{fromId}
        [HttpGet("From/{fromId}")]
        public async Task<ActionResult<IEnumerable<Connection>>> GetConnectionsByFromId(int fromId)
        {
            var connections = await _context.Connections
                .Where(c => c.FromId == fromId)
                .ToListAsync();

            if (connections == null || connections.Count == 0)
            {
                return NotFound();
            }

            return Ok(connections);
        }

        // PUT: api/Connections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConnection(int id, Connection connection)
        {
            if (id != connection.CId)
            {
                return BadRequest();
            }

            _context.Entry(connection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectionExists(id))
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

        // POST: api/Connections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Connection>> PostConnection(Connection connection)
        {
            _context.Connections.Add(connection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConnection", new { id = connection.CId }, connection);
        }

        // DELETE: api/Connections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConnection(int id)
        {
            var connection = await _context.Connections.FindAsync(id);
            if (connection == null)
            {
                return NotFound();
            }

            _context.Connections.Remove(connection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConnectionExists(int id)
        {
            return _context.Connections.Any(e => e.CId == id);
        }
    }
}
