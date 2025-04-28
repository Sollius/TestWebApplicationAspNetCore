namespace TestWebApplicationAspNetCore.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PointId { get; set; }
        public string Text { get; set; } = string.Empty;
        public string BackgroundColor { get; set; } = "#ffffff";

        public Point? Point { get; set; }
    }
}