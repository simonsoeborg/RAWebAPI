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
    public class OrderOverviewViewController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OrderOverviewViewController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/OrderOverviewView
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderOverviewView>>> GetOrderOverviewView()
        {
            return await _context.OrderOverviewView.ToListAsync();
        }

        // GET: api/OrderOverviewView/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderOverviewView>>> GetOrderOverviewView(int id)
        {

            var orderOverviewView = _context.OrderOverviewView.Where(item => item.orderId == id);


            if (orderOverviewView == null)
            {
                return NotFound();
            }

            return await orderOverviewView.ToListAsync();
        }
    }
}
