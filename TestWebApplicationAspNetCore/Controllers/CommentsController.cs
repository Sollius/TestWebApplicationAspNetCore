﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApplicationAspNetCore.Data;
using TestWebApplicationAspNetCore.Models;

namespace TestWebApplicationAspNetCore.Controllers
{
    /// <summary>
    /// Comments controller class.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CommentsController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds new comment.
        /// </summary>
        /// <param name="pointId">Id of point where the new comment belongs.</param>
        /// <param name="comment">New comment data.</param>
        /// <returns>Action result.</returns>
        [HttpPost("{pointId}")]
        public async Task<ActionResult<Comment>> AddComment(int pointId, Comment comment)
        {
            var point = await _context.Points.FindAsync(pointId);
            if (point == null) return NotFound();

            comment.PointId = pointId;
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                comment.Id,
                comment.PointId,
                comment.Text,
                comment.BackgroundColor
            });
        }

        /// <summary>
        /// Updates data of existing comment .
        /// </summary>
        /// <param name="id">Id of updating comment.</param>
        /// <param name="updatedComment">New data of updatable comment.</param>
        /// <returns>Action result.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, Comment updatedComment)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return NotFound();

            comment.Text = updatedComment.Text;
            comment.BackgroundColor = updatedComment.BackgroundColor;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}