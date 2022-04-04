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
    public class SeatingTableController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SeatingTableController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SeatingTable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatingTable>>> GetSeatingTable()
        {
            return await _context.SeatingTable.ToListAsync();
        }

        // GET: api/SeatingTable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatingTable>> GetSeatingTable(int id)
        {
            var seatingTable = await _context.SeatingTable.FindAsync(id);

            if (seatingTable == null)
            {
                return NotFound();
            }

            return seatingTable;
        }

        // PUT: api/SeatingTable/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeatingTable(int id, SeatingTable seatingTable)
        {
            if (id != seatingTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(seatingTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatingTableExists(id))
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


        // Delete and post can be addded if they layout of the resturant becomes able. 

        private bool SeatingTableExists(int id)
        {
            return _context.SeatingTable.Any(e => e.Id == id);
        }
    }
}
