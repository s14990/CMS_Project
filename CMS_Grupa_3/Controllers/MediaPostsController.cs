using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS_Grupa_3.Models;

namespace CMS_Grupa_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaPostsController : ControllerBase
    {
        private readonly cmsmainContext _context;

        public MediaPostsController(cmsmainContext context)
        {
            _context = context;
        }

        // GET: api/MediaPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaPost>>> GetMediaPost()
        {
            return await _context.MediaPost.ToListAsync();
        }

        // GET: api/MediaPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaPost>> GetMediaPost(int id)
        {
            var mediaPost = await _context.MediaPost.FindAsync(id);

            if (mediaPost == null)
            {
                return NotFound();
            }

            return mediaPost;
        }

        // PUT: api/MediaPosts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediaPost(int id, MediaPost mediaPost)
        {
            if (id != mediaPost.PostId)
            {
                return BadRequest();
            }

            _context.Entry(mediaPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MediaPosts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MediaPost>> PostMediaPost(MediaPost mediaPost)
        {
            _context.MediaPost.Add(mediaPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMediaPost", new { id = mediaPost.PostId }, mediaPost);
        }

        // DELETE: api/MediaPosts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MediaPost>> DeleteMediaPost(int id)
        {
            var mediaPost = await _context.MediaPost.FindAsync(id);
            if (mediaPost == null)
            {
                return NotFound();
            }

            mediaPost.PostDate = DateTime.Now;
            _context.MediaPost.Remove(mediaPost);
            await _context.SaveChangesAsync();

            return mediaPost;
        }

        private bool MediaPostExists(int id)
        {
            return _context.MediaPost.Any(e => e.PostId == id);
        }
    }
}
