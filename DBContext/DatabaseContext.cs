using Microsoft.EntityFrameworkCore;

namespace RAWebAPI.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<RAWebAPI.Models.Category> Category { get; set; }

        public DbSet<RAWebAPI.Models.ItemView> ItemView { get; set; }

        public DbSet<RAWebAPI.Models.Roles> Roles { get; set; }

        public DbSet<RAWebAPI.Models.Auth> Auth { get; set; }

        public DbSet<RAWebAPI.Models.Authentication> Authentication { get; set; }

        public DbSet<RAWebAPI.Models.SeatingTable> SeatingTable { get; set; }

        public DbSet<RAWebAPI.Models.Order> Order { get; set; }

        public DbSet<RAWebAPI.Models.OrderInfo> OrderInfo { get; set; }

        public DbSet<RAWebAPI.Models.OrderOverviewView> OrderOverviewView { get; set; }
    }
}
