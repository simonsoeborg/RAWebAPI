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
    [Route("api/[controller]/Get")]
    [ApiController]
    public class EasyTap : Controller
    {
         
        private readonly DatabaseContext _context;

        public EasyTap(DatabaseContext context)
        {
            _context = context;
        }

    // Category
        [Authorize(Roles = "waiter")]
        [HttpGet("Category")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _context.Category.ToListAsync();
        }

        [HttpGet("Category/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

    // ItemView
        [HttpGet("ItemView")]
        public async Task<ActionResult<IEnumerable<ItemView>>> GetItemView()
        {
            return await _context.ItemView.ToListAsync();
        }

        [HttpGet("ItemView/{id}")]
        public async Task<ActionResult<ItemView>> GetItemView(int id)
        {
            var itemView = await _context.ItemView.FindAsync(id);

            if (itemView == null)
            {
                return NotFound();
            }

            return itemView;
        }

        [HttpGet("Item/{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Item.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // Order
        [HttpGet("Order")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return await _context.Order.ToListAsync();
        }

        [HttpGet("Order/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

    // Order Info
        [HttpGet("OrderInfo")]
        public async Task<ActionResult<IEnumerable<OrderInfo>>> GetOrderInfo()
        {
            return await _context.OrderInfo.ToListAsync();
        }

        [HttpGet("OrderInfo/{id}")]
        public async Task<ActionResult<OrderInfo>> GetOrderInfo(int id)
        {

            var orderInfo = _context.OrderInfo.Where(item => item.tableId == id && item.orderPayed == false);

            if (orderInfo == null)
            {
                return NotFound();
            }

            return await orderInfo.FirstOrDefaultAsync();
        }

    // Order Overview
        [HttpGet("OrderOverviewView")]
        public async Task<ActionResult<IEnumerable<OrderOverviewView>>> GetOrderOverviewView()
        {
            return await _context.OrderOverviewView.ToListAsync();
        }

        [HttpGet("OrderOverviewView/{id}")]
        public async Task<ActionResult<IEnumerable<OrderOverviewView>>> GetOrderOverviewView(int id)
        {

            var orderOverviewView = _context.OrderOverviewView.Where(item => item.orderId == id);


            if (orderOverviewView == null)
            {
                return NotFound();
            }

            return await orderOverviewView.ToListAsync();
        }

    // SeatingTable
        [HttpGet("SeatingTable")]
        public async Task<ActionResult<IEnumerable<SeatingTable>>> GetSeatingTable()
        {
            return await _context.SeatingTable.ToListAsync();
        }

        [HttpGet("SeatingTable/{id}")]
        public async Task<ActionResult<SeatingTable>> GetSeatingTable(int id)
        {
            var seatingTable = await _context.SeatingTable.FindAsync(id);

            if (seatingTable == null)
            {
                return NotFound();
            }

            return seatingTable;
        }

    // Roles
        [HttpGet("Roles")]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        [HttpGet("Roles/{id}")]
        public async Task<ActionResult<Roles>> GetRoles(int id)
        {
            var roles = await _context.Roles.FindAsync(id);

            if (roles == null)
            {
                return NotFound();
            }

            return roles;
        }
    }
}
