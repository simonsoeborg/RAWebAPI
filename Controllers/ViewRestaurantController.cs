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
    public class ViewRestaurantController : ControllerBase
    {

        //This view controler is for accesing a sql-view a there for only contains Get requests. 

        private readonly DatabaseContext _context;

        public ViewRestaurantController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Restaurant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurant()
        {
            return await _context.RestaurantListView.ToListAsync();
        }

        // GET: api/Restaurant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _context.RestaurantListView.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }
    }
}