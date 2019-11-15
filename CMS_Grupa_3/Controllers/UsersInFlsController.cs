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
    public class UsersInFlsController : ControllerBase
    {
        private readonly CrossMusicContext _context;

        public UsersInFlsController(CrossMusicContext context)
        {
            _context = context;
        }

        // GET: api/UsersInFls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersInFl>>> GetUsersInFl()
        {
            return await _context.UsersInFl.ToListAsync();
        }

        // GET: api/UsersInFls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersInFl>> GetUsersInFl(int id)
        {
            var usersInFl = await _context.UsersInFl.FindAsync(id);

            if (usersInFl == null)
            {
                return NotFound();
            }

            return usersInFl;
        }

        // PUT: api/UsersInFls/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersInFl(int id, UsersInFl usersInFl)
        {
            if (id != usersInFl.UflId)
            {
                return BadRequest();
            }

            _context.Entry(usersInFl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersInFlExists(id))
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

        // POST: api/UsersInFls
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UsersInFl>> PostUsersInFl(UsersInFl usersInFl)
        {
            _context.UsersInFl.Add(usersInFl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersInFl", new { id = usersInFl.UflId }, usersInFl);
        }

        // DELETE: api/UsersInFls/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsersInFl>> DeleteUsersInFl(int id)
        {
            var usersInFl = await _context.UsersInFl.FindAsync(id);
            if (usersInFl == null)
            {
                return NotFound();
            }

            _context.UsersInFl.Remove(usersInFl);
            await _context.SaveChangesAsync();

            return usersInFl;
        }

        private bool UsersInFlExists(int id)
        {
            return _context.UsersInFl.Any(e => e.UflId == id);
        }
    }
}
