using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RAWebAPI.Models;

namespace RAWebAPI.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<RAWebAPI.Models.GroupMembers> GroupMembers { get; set; }

        public DbSet<RAWebAPI.Models.User> User { get; set; }

        public DbSet<RAWebAPI.Models.Restaurant> RestaurantListView { get; set; }

        public DbSet<RAWebAPI.Models.Category> Category { get; set; }

        public DbSet<RAWebAPI.Models.ItemView> ItemView { get; set; }

        public DbSet<RAWebAPI.Models.Staff> Staff { get; set; }

        public DbSet<RAWebAPI.Models.UserRoles> UserRoles { get; set; }

        public DbSet<RAWebAPI.Models.Roles> Roles { get; set; }

        public DbSet<RAWebAPI.Models.Auth> Auth { get; set; }

        public DbSet<RAWebAPI.Models.Authentication> Authentication { get; set; }

        public DbSet<RAWebAPI.Models.SeatingTable> SeatingTable { get; set; }

        public DbSet<RAWebAPI.Models.Order> Order { get; set; }

        public DbSet<RAWebAPI.Models.OrderInfo> OrderInfo { get; set; }
    }
}
