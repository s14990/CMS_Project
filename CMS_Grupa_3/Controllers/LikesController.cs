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
    public class LikesController : ControllerBase
    {
        private readonly CrossMusicContext _context;

        public LikesController(CrossMusicContext context)
        {
            _context = context;
        }

        // GET: api/Likes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Likes>>> GetLikes()
        {
            return await _context.Likes.ToListAsync();
        }

        // GET: api/Likes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Likes>> GetLikes(int id)
        {
            var likes = await _context.Likes.FindAsync(id);

            if (likes == null)
            {
                return NotFound();
            }

            return likes;
        }

        // PUT: api/Likes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLikes(int id, Likes likes)
        {
            if (id != likes.LikeId)
            {
                return BadRequest();
            }

            _context.Entry(likes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikesExists(id))
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

        // POST: api/Likes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Likes>> PostLikes(Likes likes)
        {
            _context.Likes.Add(likes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLikes", new { id = likes.LikeId }, likes);
        }

        // DELETE: api/Likes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Likes>> DeleteLikes(int id)
        {
            var likes = await _context.Likes.FindAsync(id);
            if (likes == null)
            {
                return NotFound();
            }

            _context.Likes.Remove(likes);
            await _context.SaveChangesAsync();

            return likes;
        }

        private bool LikesExists(int id)
        {
            return _context.Likes.Any(e => e.LikeId == id);
        }
    }
}
