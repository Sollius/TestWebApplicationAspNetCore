namespace TestWebApplicationAspNetCore.Models
{
    public class Point
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
        public string Color { get; set; } = "#000000";

        public List<Comment> Comments { get; set; } = new();
    }
}