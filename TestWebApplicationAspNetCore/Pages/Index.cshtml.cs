using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestWebApplicationAspNetCore.Data;
using TestWebApplicationAspNetCore.Models;

namespace TestWebApplicationAspNetCore.Pages
{
    /// <summary>
    /// Index page model class.
    /// </summary>
    /// <param name="dbContext">Application database context.</param>
    public class IndexModel(AppDbContext dbContext) : PageModel
    {
        private readonly AppDbContext dbContext = dbContext;

        /// <summary>
        /// Gets or sets collection of points.
        /// </summary>
        public List<Point> Points { get; set; } = [];

        /// <summary>
        /// Gets or sets collection of comments.
        /// </summary>
        public List<Comment> Comments { get; set; } = [];

        /// <summary>
        /// Automatically executed as a result of a GET request.
        /// </summary>
        public void OnGet()
        {
            this.Points = this.dbContext.Points.ToList();
            this.Comments = this.dbContext.Comments.Include(c => c.Point).ThenInclude(p => p.Comments).ToList();
        }
    }
}