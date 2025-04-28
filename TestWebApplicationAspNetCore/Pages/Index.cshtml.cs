using Microsoft.AspNetCore.Mvc.RazorPages;
using TestWebApplicationAspNetCore.Data;

namespace TestWebApplicationAspNetCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext dbContext;

        public IndexModel(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            // Пока логики нет. Можно потом использовать для передачи данных в Razor.
        }

        public List<string> UpdateObjectsList()
        {
            return this.dbContext.Points.Select(p => $"{p.Id}").ToList();
        }
    }
}