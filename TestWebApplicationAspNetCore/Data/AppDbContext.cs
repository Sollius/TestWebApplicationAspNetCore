using Microsoft.EntityFrameworkCore;
using TestWebApplicationAspNetCore.Models;
using Point = TestWebApplicationAspNetCore.Models.Point;

namespace TestWebApplicationAspNetCore.Data
{
    /// <summary>
    /// Application database context class.
    /// </summary>
    /// <param name="options"></param>
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        /// <summary>
        /// Gets or sets EF collection of points.
        /// </summary>
        public DbSet<Point> Points { get; set; }

        /// <summary>
        /// Gets or sets EF collection of comments.
        /// </summary>
        public DbSet<Comment> Comments { get; set; }
    }
}