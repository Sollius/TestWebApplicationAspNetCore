namespace TestWebApplicationAspNetCore.Models
{
    /// <summary>
    /// EF entity that represents point.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Gets or sets point id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets point X coordinate.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets point Y coordinate.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets point radius.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Gets or sets point color.
        /// </summary>
        public string Color { get; set; } = "#000000";

        /// <summary>
        /// Gets or sets comments collection of comment.
        /// </summary>
        public List<Comment> Comments { get; set; } = new();
    }
}