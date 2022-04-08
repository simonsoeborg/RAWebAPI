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
    public class OrderInfoController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OrderInfoController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/OrderInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderInfo>>> GetOrderInfo()
        {
            return await _context.OrderInfo.ToListAsync();
        }

        // GET: api/OrderInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderInfo>> GetOrderInfo(int id)
        {
            var orderInfo = await _context.OrderInfo.FindAsync(id);

            if (orderInfo == null)
            {
                return NotFound();
            }

            return orderInfo;
        }

        // PUT: api/OrderInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderInfo(int id, OrderInfo orderInfo)
        {
            if (id != orderInfo.id)
            {
                return BadRequest();
            }

            _context.Entry(orderInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderInfoExists(id))
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

        // POST: api/OrderInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderInfo>> PostOrderInfo(OrderInfo orderInfo)
        {
            _context.OrderInfo.Add(orderInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderInfo", new { id = orderInfo.id }, orderInfo);
        }

        // DELETE: api/OrderInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderInfo(int id)
        {
            var orderInfo = await _context.OrderInfo.FindAsync(id);
            if (orderInfo == null)
            {
                return NotFound();
            }

            _context.OrderInfo.Remove(orderInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderInfoExists(int id)
        {
            return _context.OrderInfo.Any(e => e.id == id);
        }
    }
}
