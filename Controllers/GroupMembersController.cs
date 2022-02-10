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
    public class GroupMembersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public GroupMembersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/GroupMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupMembers>>> GetGroupMembers()
        {
            return await _context.GroupMembers.ToListAsync();
        }

        // GET: api/GroupMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupMembers>> GetGroupMembers(int id)
        {
            var groupMembers = await _context.GroupMembers.FindAsync(id);

            if (groupMembers == null)
            {
                return NotFound();
            }

            return groupMembers;
        }

        // PUT: api/GroupMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupMembers(int id, GroupMembers groupMembers)
        {
            if (id != groupMembers.id)
            {
                return BadRequest();
            }

            _context.Entry(groupMembers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupMembersExists(id))
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

        // POST: api/GroupMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupMembers>> PostGroupMembers(GroupMembers groupMembers)
        {
            _context.GroupMembers.Add(groupMembers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupMembers", new { id = groupMembers.id }, groupMembers);
        }

        // DELETE: api/GroupMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupMembers(int id)
        {
            var groupMembers = await _context.GroupMembers.FindAsync(id);
            if (groupMembers == null)
            {
                return NotFound();
            }

            _context.GroupMembers.Remove(groupMembers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupMembersExists(int id)
        {
            return _context.GroupMembers.Any(e => e.id == id);
        }
    }
}
