using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RAWebAPI.DBContext;
using RAWebAPI.Models;

namespace RAWebAPI.Controllers
{
    [Route("api/Admin/Delete")]
    [ApiController]
    public class AdminDelete : Controller
    {

        private readonly DatabaseContext _context;

        public AdminDelete(DatabaseContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("Category/{id}")] // Skal have admin token perms
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ItemView
        [Authorize(Roles = "admin")]
        [HttpDelete("ItemView/{id}")] // Skal have admin token perms
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

        // Order
        [Authorize(Roles = "admin")]
        [HttpDelete("Order/{id}")] // Skal have admin token perms
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Order Info
        [Authorize(Roles = "admin")]
        [HttpDelete("OrderInfo/{id}")] // Skal have admin token perms
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
    }
}
