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
    public class ReaderBookScoreController : ControllerBase
    {
        private readonly LibraryDatabaseContext _context;

        public ReaderBookScoreController(LibraryDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ReaderBookScore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReaderBookScore>>> GetReaderBookScore()
        {
          if (_context.ReaderBookScore == null)
          {
              return NotFound();
          }
            return await _context.ReaderBookScore.ToListAsync();
        }

        // GET: api/ReaderBookScore/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReaderBookScore>> GetReaderBookScore(int id)
        {
          if (_context.ReaderBookScore == null)
          {
              return NotFound();
          }
            var readerBookScore = await _context.ReaderBookScore.FindAsync(id);

            if (readerBookScore == null)
            {
                return NotFound();
            }

            return readerBookScore;
        }

        // PUT: api/ReaderBookScore/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReaderBookScore(int id, ReaderBookScore readerBookScore)
        {
            if (id != readerBookScore.BookId)
            {
                return BadRequest();
            }

            _context.Entry(readerBookScore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReaderBookScoreExists(id))
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

        // POST: api/ReaderBookScore
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReaderBookScore>> PostReaderBookScore(ReaderBookScore readerBookScore)
        {
          if (_context.ReaderBookScore == null)
          {
              return Problem("Entity set 'LibraryDatabaseContext.ReaderBookScore'  is null.");
          }
            _context.ReaderBookScore.Add(readerBookScore);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReaderBookScoreExists(readerBookScore.BookId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReaderBookScore", new { id = readerBookScore.BookId }, readerBookScore);
        }

        // DELETE: api/ReaderBookScore/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReaderBookScore(int id)
        {
            if (_context.ReaderBookScore == null)
            {
                return NotFound();
            }
            var readerBookScore = await _context.ReaderBookScore.FindAsync(id);
            if (readerBookScore == null)
            {
                return NotFound();
            }

            _context.ReaderBookScore.Remove(readerBookScore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReaderBookScoreExists(int id)
        {
            return (_context.ReaderBookScore?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
