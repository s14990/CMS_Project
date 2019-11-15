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
    public class MsgsController : ControllerBase
    {
        private readonly CrossMusicContext _context;

        public MsgsController(CrossMusicContext context)
        {
            _context = context;
        }

        // GET: api/Msgs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Msg>>> GetMsg()
        {
            return await _context.Msg.ToListAsync();
        }

        // GET: api/Msgs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Msg>> GetMsg(int id)
        {
            var msg = await _context.Msg.FindAsync(id);

            if (msg == null)
            {
                return NotFound();
            }

            return msg;
        }

        // PUT: api/Msgs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMsg(int id, Msg msg)
        {
            if (id != msg.MsgId)
            {
                return BadRequest();
            }

            _context.Entry(msg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MsgExists(id))
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

        // POST: api/Msgs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Msg>> PostMsg(Msg msg)
        {
            _context.Msg.Add(msg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMsg", new { id = msg.MsgId }, msg);
        }

        // DELETE: api/Msgs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Msg>> DeleteMsg(int id)
        {
            var msg = await _context.Msg.FindAsync(id);
            if (msg == null)
            {
                return NotFound();
            }

            _context.Msg.Remove(msg);
            await _context.SaveChangesAsync();

            return msg;
        }

        private bool MsgExists(int id)
        {
            return _context.Msg.Any(e => e.MsgId == id);
        }
    }
}
