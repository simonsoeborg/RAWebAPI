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

        private bool AuthExists(string id)
        {
            return _context.Auth.Any(e => e.Token == id);
        }
    }
}
