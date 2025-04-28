using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestWebApplicationAspNetCore.Data;
using TestWebApplicationAspNetCore.Models;

namespace TestWebApplicationAspNetCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public List<Point> Points { get; set; } = new();

        public List<Comment> Comments { get; set; } = new();

        public IndexModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            this.Points = this.dbContext.Points.ToList();
            this.Comments = this.dbContext.Comments.Include(c => c.Point).ThenInclude(p => p.Comments).ToList();
        }

        public List<string> UpdateObjectsList()
        {
            return this.dbContext.Points.Select(p => $"{p.Id}").ToList();
        }
    }
}