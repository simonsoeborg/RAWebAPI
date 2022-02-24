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
    public class ViewRestaurantInfoController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ViewRestaurantInfoController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ViewRestaurantInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewRestaurantInfo>>> GetRestaurantListView()
        {
            return await _context.RestaurantListView.ToListAsync();
        }

        // GET: api/ViewRestaurantInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ViewRestaurantInfo>> GetViewRestaurantInfo(int id)
        {
            var viewRestaurantInfo = await _context.RestaurantListView.FindAsync(id);

            if (viewRestaurantInfo == null)
            {
                return NotFound();
            }

            return viewRestaurantInfo;
        }

 
    }
}
