using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Order_Management_API.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


        public DbSet<Order> Orders
        {
            get; set;
        }

    }
}
