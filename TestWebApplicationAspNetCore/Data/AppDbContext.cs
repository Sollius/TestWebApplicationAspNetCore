using Microsoft.EntityFrameworkCore;
using TestWebApplicationAspNetCore.Models;
using Point = TestWebApplicationAspNetCore.Models.Point;

namespace TestWebApplicationAspNetCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Point> Points { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}