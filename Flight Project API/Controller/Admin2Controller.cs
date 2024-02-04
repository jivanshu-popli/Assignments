using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using flightapi.Models;

namespace flightapi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin2Controller : ControllerBase
    {
        private readonly Ace52024Context _context;

        public Admin2Controller(Ace52024Context context)
        {
            _context = context;
        }

        // GET: api/Admin2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingsJivanshu>>> GetBookingsJivanshus()
        {
            return await _context.BookingsJivanshus.ToListAsync();
        }

        // GET: api/Admin2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingsJivanshu>> GetBookingsJivanshu(int id)
        {
            var bookingsJivanshu = await _context.BookingsJivanshus.FindAsync(id);

            if (bookingsJivanshu == null)
            {
                return NotFound();
            }

            return bookingsJivanshu;
        }

        // PUT: api/Admin2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingsJivanshu(int id, BookingsJivanshu bookingsJivanshu)
        {
            if (id != bookingsJivanshu.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(bookingsJivanshu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingsJivanshuExists(id))
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

        // POST: api/Admin2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingsJivanshu>> PostBookingsJivanshu(BookingsJivanshu bookingsJivanshu)
        {
            _context.BookingsJivanshus.Add(bookingsJivanshu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingsJivanshu", new { id = bookingsJivanshu.BookingId }, bookingsJivanshu);
        }

        // DELETE: api/Admin2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingsJivanshu(int id)
        {
            var bookingsJivanshu = await _context.BookingsJivanshus.FindAsync(id);
            if (bookingsJivanshu == null)
            {
                return NotFound();
            }

            _context.BookingsJivanshus.Remove(bookingsJivanshu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingsJivanshuExists(int id)
        {
            return _context.BookingsJivanshus.Any(e => e.BookingId == id);
        }
    }
}
