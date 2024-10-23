using Microsoft.EntityFrameworkCore;
using System.Numerics;
using CORE.Dto;

namespace DATA
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plant_dto> Plants { get; set; }
        public DbSet<User_dto> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
    }
}
