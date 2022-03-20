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
    public class AuthViewController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AuthViewController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Auth/{email}
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthView>> GetAuth(string email)
        {
            var auth = await _context.AuthView.FindAsync(email);

            if (auth == null)
            {
                return NotFound();
            }

            return auth;
        }

        private bool AuthExists(string id)
        {
            return _context.AuthView.Any(e => e.Email == id);
        }
    }
}
