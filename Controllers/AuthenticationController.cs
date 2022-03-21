using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RAWebAPI.Models;

namespace RAWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AuthenticationController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Authentication/5
        [HttpGet("{email}")]
        public async Task<ActionResult<Authentication>> GetAuthentication(string email)
        {
            var authentication = await _context.Authentication.FindAsync(email);

            if (authentication == null)
            {
                return NotFound();
            }

            return authentication;
        }

        // POST: api/Authentication
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auth>> PostAuthentication(Authentication authentication)
        {
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            if (await _context.Authentication.FindAsync(authentication.Email) == null)
            {
                _context.Authentication.Add(authentication);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (AuthenticationExists(authentication.Email))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
                return await GetAuth(authentication.Email);
                // return CreatedAtAction("PostAuthentication", new { id = authentication.Email }, authentication);
            }
            return await GetAuth(authentication.Email);
        }

        // GET: api/Authentication/Auth/email
        [HttpGet("Auth/{email}")]
        public async Task<ActionResult<Auth>> GetAuth(string email)
        {
            var auth = await _context.Auth.FindAsync(email);

            if (auth == null)
            {
                return NotFound();
            }

            return auth;
        }

        // DELETE: api/Authentication/5
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteAuthentication(string email)
        {
            var authentication = await _context.Authentication.FindAsync(email);
            if (authentication == null)
            {
                return NotFound();
            }

            _context.Authentication.Remove(authentication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthenticationExists(string id)
        {
            return _context.Authentication.Any(e => e.Email == id);
        }
    }
}
