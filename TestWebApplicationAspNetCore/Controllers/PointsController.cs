using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApplicationAspNetCore.Data;
using TestWebApplicationAspNetCore.Models;

namespace TestWebApplicationAspNetCore.Controllers
{
    /// <summary>
    /// Points controller class.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PointsController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        /// <summary>
        /// Gets existing points.
        /// </summary>
        /// <returns>Action result.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Point>>> GetPoints()
        {
            return await _context.Points.Include(p => p.Comments).ToListAsync();
        }

        /// <summary>
        /// Creates new point.
        /// </summary>
        /// <param name="point">New point data.</param>
        /// <returns>Action result.</returns>
        [HttpPost]
        public async Task<ActionResult<Point>> CreatePoint(Point point)
        {
            _context.Points.Add(point);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPoints), new { id = point.Id }, point);
        }

        /// <summary>
        /// Updates existing point.
        /// </summary>
        /// <param name="id">Id of updating point.</param>
        /// <param name="updatedPoint">New data of updating point.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePoint(int id, Point updatedPoint)
        {
            var point = await _context.Points.FindAsync(id);
            if (point == null)
            {
                return NotFound();
            }

            point.X = updatedPoint.X;
            point.Y = updatedPoint.Y;
            point.Radius = updatedPoint.Radius;
            point.Color = updatedPoint.Color;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Deletes point.
        /// </summary>
        /// <param name="id">Id of deleting point.</param>
        /// <returns>Action result.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoint(int id)
        {
            var point = await _context.Points.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
            if (point == null) return NotFound();

            _context.Comments.RemoveRange(point.Comments);
            _context.Points.Remove(point);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}