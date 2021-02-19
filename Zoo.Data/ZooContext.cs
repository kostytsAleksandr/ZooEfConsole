using System.Data.Entity;
using Zoo.Data.Models;

namespace Zoo.Data
{
    public class ZooContext : DbContext
    {
        public ZooContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Breed> Breeds { get; set; }
    }
}
