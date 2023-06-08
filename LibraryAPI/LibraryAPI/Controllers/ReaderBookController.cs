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
    public class ReaderBookController : ControllerBase
    {
        private readonly LibraryDatabaseContext _context;

        public ReaderBookController(LibraryDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ReaderBook
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReaderBook>>> GetReaderBook()
        {
          if (_context.ReaderBook == null)
          {
              return NotFound();
          }
            return await _context.ReaderBook.ToListAsync();
        }

        // GET: api/ReaderBook/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReaderBook>> GetReaderBook(int id)
        {
          if (_context.ReaderBook == null)
          {
              return NotFound();
          }
            var readerBook = await _context.ReaderBook.FindAsync(id);

            if (readerBook == null)
            {
                return NotFound();
            }

            return readerBook;
        }

        // PUT: api/ReaderBook/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReaderBook(int id, ReaderBook readerBook)
        {
            if (id != readerBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(readerBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReaderBookExists(id))
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

        // POST: api/ReaderBook
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReaderBook>> PostReaderBook(ReaderBook readerBook)
        {
          if (_context.ReaderBook == null)
          {
              return Problem("Entity set 'LibraryDatabaseContext.ReaderBook'  is null.");
          }
            _context.ReaderBook.Add(readerBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReaderBook", new { id = readerBook.Id }, readerBook);
        }

        // DELETE: api/ReaderBook/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReaderBook(int id)
        {
            if (_context.ReaderBook == null)
            {
                return NotFound();
            }
            var readerBook = await _context.ReaderBook.FindAsync(id);
            if (readerBook == null)
            {
                return NotFound();
            }

            _context.ReaderBook.Remove(readerBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReaderBookExists(int id)
        {
            return (_context.ReaderBook?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
