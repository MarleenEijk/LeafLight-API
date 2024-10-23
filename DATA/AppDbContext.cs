using Microsoft.EntityFrameworkCore;
using System.Numerics;
using CORE.Dto;

namespace DATA
{
    public class AppDbContext : DbContext
    {
        public DbSet<PlantDto> Plants { get; set; }
        public DbSet<UserDto> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
    }
}
