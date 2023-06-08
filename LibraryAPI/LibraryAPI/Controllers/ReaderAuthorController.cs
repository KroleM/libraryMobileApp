using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Data;
using LibraryAPI.Models;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderAuthorController : ControllerBase
    {
        private readonly LibraryDatabaseContext _context;

        public ReaderAuthorController(LibraryDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ReaderAuthor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReaderAuthor>>> GetReaderAuthor()
        {
          if (_context.ReaderAuthor == null)
          {
              return NotFound();
          }
            return await _context.ReaderAuthor.ToListAsync();
        }

        // GET: api/ReaderAuthor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReaderAuthor>> GetReaderAuthor(int id)
        {
          if (_context.ReaderAuthor == null)
          {
              return NotFound();
          }
            var readerAuthor = await _context.ReaderAuthor.FindAsync(id);

            if (readerAuthor == null)
            {
                return NotFound();
            }

            return readerAuthor;
        }

        // PUT: api/ReaderAuthor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReaderAuthor(int id, ReaderAuthor readerAuthor)
        {
            if (id != readerAuthor.AuthorId)
            {
                return BadRequest();
            }

            _context.Entry(readerAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReaderAuthorExists(id))
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

        // POST: api/ReaderAuthor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReaderAuthor>> PostReaderAuthor(ReaderAuthor readerAuthor)
        {
          if (_context.ReaderAuthor == null)
          {
              return Problem("Entity set 'LibraryDatabaseContext.ReaderAuthor'  is null.");
          }
            _context.ReaderAuthor.Add(readerAuthor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReaderAuthorExists(readerAuthor.AuthorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReaderAuthor", new { id = readerAuthor.AuthorId }, readerAuthor);
        }

        // DELETE: api/ReaderAuthor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReaderAuthor(int id)
        {
            if (_context.ReaderAuthor == null)
            {
                return NotFound();
            }
            var readerAuthor = await _context.ReaderAuthor.FindAsync(id);
            if (readerAuthor == null)
            {
                return NotFound();
            }

            _context.ReaderAuthor.Remove(readerAuthor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReaderAuthorExists(int id)
        {
            return (_context.ReaderAuthor?.Any(e => e.AuthorId == id)).GetValueOrDefault();
        }
    }
}
