using LeafLight_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace LeafLight_API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
    }
}
