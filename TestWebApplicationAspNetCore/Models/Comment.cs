namespace TestWebApplicationAspNetCore.Models
{
    /// <summary>
    /// EF entity that represents comment.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets comment id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets id of point where comment belongs.
        /// </summary>
        public int PointId { get; set; }

        /// <summary>
        /// Gets or sets point where comment belongs.
        /// </summary>
        public Point? Point { get; set; }

        /// <summary>
        /// Gets or sets comment text.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets comment backgroung color.
        /// </summary>
        public string BackgroundColor { get; set; } = "#ffffff";
    }
}