using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RAWebAPI.DBContext;
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

        // GET: api/Category
        [Authorize(Roles = "admin")]
        [HttpGet("AuthenticatedUsers/{token}")]
        public async Task<ActionResult<IEnumerable<Authentication>>> GetAllUsers(string token)
        {
            // Decode JWT
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            // Check Role
            var role = jsonToken.Claims.First(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
            // If Else
            if (role == "admin")
            {
                return await _context.Authentication.ToListAsync();
            }

            return NoContent();
        }

        // GET: api/Authentication/
        [Authorize(Roles = "admin")]
        [HttpGet("{email}/{token}")]
        public async Task<ActionResult<Authentication>> GetAuthentication(string email, string token)
        {
            var authentication = await _context.Authentication.FindAsync(email);
            // Decode JWT
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            // Check Role
            var role = jsonToken.Claims.First(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
            // If Else
            if (role == "admin")
            {
                return authentication;
            }

            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPut("AuthenticatedUsers/{token}/{email}")]
        public async Task<IActionResult> PutAuthUser(string email, Authentication authUser)
        {
            if (email != authUser.Email)
            {
                return BadRequest();
            }

            _context.Entry(authUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthenticationExists(email))
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

        // POST: api/Authentication
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
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
