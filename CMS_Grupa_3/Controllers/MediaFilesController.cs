using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS_Grupa_3.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace CMS_Grupa_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaFilesController : ControllerBase
    {
        private readonly cmsmainContext _context;

        public MediaFilesController(cmsmainContext context)
        {
            _context = context;
        }

        // GET: api/MediaFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaFile>>> GetMediaFile()
        {
            return await _context.MediaFile.ToListAsync();
        }

        // GET: api/MediaFiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaFile>> GetMediaFile(int id)
        {
            var mediaFile = await _context.MediaFile.FindAsync(id);

            if (mediaFile == null)
            {
                return NotFound();
            }

            return mediaFile;
        }

        // PUT: api/MediaFiles/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediaFile(int id, MediaFile mediaFile)
        {
            if (id != mediaFile.FileId)
            {
                return BadRequest();
            }

            _context.Entry(mediaFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaFileExists(id))
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

        // POST: api/MediaFiles
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MediaFile>> PostMediaFile([FromForm] UploadFile model)
        {
            IFormFile file = model.File;
           
            Account account = new Account(
            "dn2pht7no",
            "763416155661231",
            "Y8_D6HDCOUNJAUoPvi8wtVWhkmE");

            Cloudinary cloudinary = new Cloudinary(account);

            var fs = file.OpenReadStream();
            var uploadParams = new VideoUploadParams()
            {
                File = new FileDescription(file.FileName,fs)
            };
            var uploadResult = cloudinary.Upload(uploadParams);

            MediaFile mediaFile = new MediaFile();
            mediaFile.MediaName = "Test";
            mediaFile.MediaType = "video";
            mediaFile.MediaDescription = "...";
            mediaFile.MediaDate = DateTime.Now;
            mediaFile.FileName = "test";
            mediaFile.FileType = "mp4";
            mediaFile.FileLink= uploadResult.Uri.ToString();
            var u = await _context.User.SingleOrDefaultAsync(u => u.UserName == "admin");
            mediaFile.Uploader = u;
            _context.MediaFile.Add(mediaFile);
            await _context.SaveChangesAsync();
            System.Console.WriteLine(mediaFile.FileId);
            return CreatedAtAction("GetMediaFile", new { id = mediaFile.FileId }, mediaFile);
        }

        // DELETE: api/MediaFiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MediaFile>> DeleteMediaFile(int id)
        {
            var mediaFile = await _context.MediaFile.FindAsync(id);
            if (mediaFile == null)
            {
                return NotFound();
            }

            _context.MediaFile.Remove(mediaFile);
            await _context.SaveChangesAsync();

            return mediaFile;
        }

        private bool MediaFileExists(int id)
        {
            return _context.MediaFile.Any(e => e.FileId == id);
        }
    }
}
