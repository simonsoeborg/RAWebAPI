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
    public class resOrdersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public resOrdersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/resOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<resOrders>>> GetresOrders()
        {
            return await _context.resOrders.ToListAsync();
        }

        // GET: api/resOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<resOrders>> GetresOrders(int id)
        {
            var resOrders = await _context.resOrders.FindAsync(id);

            if (resOrders == null)
            {
                return NotFound();
            }

            return resOrders;
        }

        // PUT: api/resOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutresOrders(int id, resOrders resOrders)
        {
            if (id != resOrders.Id)
            {
                return BadRequest();
            }

            _context.Entry(resOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!resOrdersExists(id))
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

        // POST: api/resOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<resOrders>> PostresOrders(resOrders resOrders)
        {
            _context.resOrders.Add(resOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetresOrders", new { id = resOrders.Id }, resOrders);
        }

        // DELETE: api/resOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteresOrders(int id)
        {
            var resOrders = await _context.resOrders.FindAsync(id);
            if (resOrders == null)
            {
                return NotFound();
            }

            _context.resOrders.Remove(resOrders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool resOrdersExists(int id)
        {
            return _context.resOrders.Any(e => e.Id == id);
        }
    }
}
