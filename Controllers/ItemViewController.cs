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
    public class ItemViewController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ItemViewController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ItemView
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemView>>> GetItemView()
        {
            return await _context.ItemView.ToListAsync();
        }

        // GET: api/ItemView/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemView>> GetItemView(int id)
        {
            var itemView = await _context.ItemView.FindAsync(id);

            if (itemView == null)
            {
                return NotFound();
            }

            return itemView;
        }

        // PUT: api/ItemView/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemView(int id, ItemView itemView)
        {
            if (id != itemView.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemView).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemViewExists(id))
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

        // POST: api/ItemView
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemView>> PostItemView(ItemView itemView)
        {
            _context.ItemView.Add(itemView);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemView", new { id = itemView.Id }, itemView);
        }

        // DELETE: api/ItemView/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemView(int id)
        {
            var itemView = await _context.ItemView.FindAsync(id);
            if (itemView == null)
            {
                return NotFound();
            }

            _context.ItemView.Remove(itemView);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemViewExists(int id)
        {
            return _context.ItemView.Any(e => e.Id == id);
        }
    }
}
