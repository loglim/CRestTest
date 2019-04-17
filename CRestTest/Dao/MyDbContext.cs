using CRestTest.Model;
using Microsoft.EntityFrameworkCore;

namespace CRestTest.Dao
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
