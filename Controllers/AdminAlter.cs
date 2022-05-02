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
    [Route("api/Admin/Alter")]
    [ApiController]
    public class AdminAlter : Controller
    {

        private readonly DatabaseContext _context;

        public AdminAlter(DatabaseContext context)
        {
            _context = context;
        }

        // Category
        // // [Authorize(Roles = "admin")]
        [HttpPut("Category/{id}")] // Skal have admin token perms
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }

    // ItemView
        // // // [Authorize(Roles = "admin")]
        [HttpPut("ItemView/{id}")] // Skal have admin token perms
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

        private bool ItemViewExists(int id)
        {
            return _context.ItemView.Any(e => e.Id == id);
        }

        // Item
        // // // [Authorize(Roles = "admin")]
        [HttpPut("Item/{id}")] // Skal have admin token perms
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.Id == id);
        }

        // Order
        [HttpPut("Order/{id}")] // Skal have admin token perms
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.id == id);
        }

        // Order Info
        [HttpPut("OrderInfo/{id}")] // Skal have admin token perms
        public async Task<IActionResult> PutOrderInfo(int id)
        {

            OrderInfo updatedInfo = _context.OrderInfo.SingleOrDefault(c => c.tableId == id && c.orderPayed == false);

            if (updatedInfo == null)
            {
                return NotFound();
            }
            else updatedInfo.orderPayed = true;

            _context.OrderInfo.Update(updatedInfo);

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

        private bool OrderInfoExists(int id)
        {
            return _context.OrderInfo.Any(e => e.id == id);
        }

        // SeatingTable
        [HttpPut("SeatingTable/{id}")] // Skal have admin token perms
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

        private bool SeatingTableExists(int id)
        {
            return _context.SeatingTable.Any(e => e.Id == id);
        }
    }
}
