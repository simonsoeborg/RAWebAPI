using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<ActionResult<string>> PostAuthentication(Authentication authentication)
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
                return await CreateToken(authentication);
                // return CreatedAtAction("PostAuthentication", new { id = authentication.Email }, authentication);
            }
            return await CreateToken(authentication);
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

        private async Task<string> CreateToken(Authentication authentication)
        {
            Authentication exists  = await _context.Authentication.FindAsync(authentication.Email);
            if (exists == null)
            {
                throw new Exception("User role was not found in AuthController_CreateToken()!");
            }
            else
            {
                Auth authUser =  GetAuth(authentication.Email).Result.Value;
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.Name, authUser.Name),
                    new Claim(ClaimTypes.Email, authUser.Email),
                    new Claim(ClaimTypes.Role, authUser.Role),
                    new Claim(ClaimTypes.NameIdentifier, authUser.Sub),
                    new Claim(ClaimTypes.Uri, authUser.Picture),
                    new Claim(ClaimTypes.SerialNumber, authUser.Pin.ToString())
                };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        "hemmeligtPassword"));

                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                    var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: credentials);

                    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                    return jwt;
            }
        }
        private static void CreateHash(string email, out byte[] emailHash)
        {
            using var hmac = new HMACSHA512();
            emailHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(email));
        }
    }
}
