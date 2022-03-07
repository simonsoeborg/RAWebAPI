using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RAWebAPI.Models;

namespace RAWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AuthController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Auth
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auth>>> GetAuth()
        {
            return await _context.Auth.ToListAsync();
        }

        // GET: api/Auth/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auth>> GetAuth(string id)
        {
            var auth = await _context.Auth.FindAsync(id);

            if (auth == null)
            {
                return NotFound();
            }

            return auth;
        }

        // PUT: api/Auth/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuth(string id, Auth auth)
        {
            if (id != auth.Token)
            {
                return BadRequest();
            }

            _context.Entry(auth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthExists(id))
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

        // POST: api/Auth
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auth>> PostAuth(Auth auth)
        {
            _context.Auth.Add(auth);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuthExists(auth.Token))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAuth", new { id = auth.Token }, auth);
        }

        // DELETE: api/Auth/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuth(string id)
        {
            var auth = await _context.Auth.FindAsync(id);
            if (auth == null)
            {
                return NotFound();
            }

            _context.Auth.Remove(auth);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthExists(string id)
        {
            return _context.Auth.Any(e => e.Token == id);
        }
    }
}
