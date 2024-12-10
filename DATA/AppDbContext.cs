using Microsoft.EntityFrameworkCore;
using CORE.Dto;
using CORE.Models;

namespace DATA
{
    public class AppDbContext : DbContext
    {
        public DbSet<PlantDto> plant { get; set; }
        public DbSet<IssueDto> issue { get; set; }
        public DbSet<UserDto> user { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
