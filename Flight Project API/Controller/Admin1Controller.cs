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
    public class Admin1Controller : ControllerBase
    {
        private readonly Ace52024Context _context;

        public Admin1Controller(Ace52024Context context)
        {
            _context = context;
        }

        // GET: api/Admin1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightsJivanshu>>> GetFlightsJivanshus()
        {
            return await _context.FlightsJivanshus.ToListAsync();
        }

        // GET: api/Admin1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightsJivanshu>> GetFlightsJivanshu(int id)
        {
            var flightsJivanshu = await _context.FlightsJivanshus.FindAsync(id);

            if (flightsJivanshu == null)
            {
                return NotFound();
            }

            return flightsJivanshu;
        }

        // PUT: api/Admin1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightsJivanshu(int id, FlightsJivanshu flightsJivanshu)
        {
            if (id != flightsJivanshu.FlightId)
            {
                return BadRequest();
            }

            _context.Entry(flightsJivanshu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightsJivanshuExists(id))
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

        // POST: api/Admin1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightsJivanshu>> PostFlightsJivanshu(FlightsJivanshu flightsJivanshu)
        {
            _context.FlightsJivanshus.Add(flightsJivanshu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightsJivanshu", new { id = flightsJivanshu.FlightId }, flightsJivanshu);
        }

        // DELETE: api/Admin1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightsJivanshu(int id)
        {
            var flightsJivanshu = await _context.FlightsJivanshus.FindAsync(id);
            if (flightsJivanshu == null)
            {
                return NotFound();
            }

            _context.FlightsJivanshus.Remove(flightsJivanshu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightsJivanshuExists(int id)
        {
            return _context.FlightsJivanshus.Any(e => e.FlightId == id);
        }
    }
}
