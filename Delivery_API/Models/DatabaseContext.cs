using Microsoft.EntityFrameworkCore;

namespace Delivery_API.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


        public DbSet<Delivery> Deliveries
        {
            get; set;
        }

    }
}
