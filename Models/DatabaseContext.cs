﻿using System;
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

        public DbSet<RAWebAPI.Models.Orders> Orders { get; set; }

        public DbSet<RAWebAPI.Models.User> User { get; set; }
    }
}
