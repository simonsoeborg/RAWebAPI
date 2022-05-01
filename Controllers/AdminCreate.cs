using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RAWebAPI.DBContext;
using RAWebAPI.Models;

namespace RAWebAPI.Controllers
{
    [Route("api/Admin/Create")]
    [ApiController]
    public class AdminCreate : Controller
    {
        private readonly DatabaseContext _context;

        public AdminCreate(DatabaseContext context)
        {
            _context = context;
        }

        // Category
        // [Authorize(Roles = "admin")]
        [HttpPost("Category")]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostCategory", new { id = category.Id }, category);
        }
        // ItemView
        // [Authorize(Roles = "admin")]
        [HttpPost("ItemView")]
        public async Task<ActionResult<ItemView>> PostItemView(ItemView itemView)
        {
            _context.ItemView.Add(itemView);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostItemView", new { id = itemView.Id }, itemView);
        }
        // Item
        // [Authorize(Roles = "admin")]
        [HttpPost("Item")]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Item.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostItem", new { id = item.Id }, item);
        }
        // Order
        [HttpPost("Order")]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostOrder", new { id = order.id }, order);
        }

    // Order Info
        [HttpPost("OrderInfo")]
        public async Task<ActionResult<OrderInfo>> PostOrderInfo(OrderInfo orderInfo)
        {
            _context.OrderInfo.Add(orderInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostOrderInfo", new { id = orderInfo.id }, orderInfo);
        }
    }
}
