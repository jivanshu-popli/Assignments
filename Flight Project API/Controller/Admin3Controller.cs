using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using flightapi.Models;
using flightapi.Service;

namespace flightapi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin3Controller : ControllerBase
    {
        private readonly IAdmin3Serv<CustomersJivanshu> _context;

        public Admin3Controller(IAdmin3Serv<CustomersJivanshu> context)
        {
            _context = context;
        }

        // GET: api/Admin3
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomersJivanshu>>> GetCustomersJivanshus()
        {
            return _context.GetAllCustomers();
        }

        // GET: api/Admin3/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomersJivanshu>> GetCustomersJivanshu(int id)
        {
            var customersJivanshu = _context.GetCustomerById(id);

            if (customersJivanshu == null)
            {
                return NotFound();
            }

            return customersJivanshu;
        }

        // PUT: api/Admin3/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomersJivanshu(int id, CustomersJivanshu customersJivanshu)
        {
            if (id != customersJivanshu.CustomerId)
            {
                return BadRequest();
            }

            //_context.Entry(customersJivanshu).State = EntityState.Modified;

            try
            {
                _context.UpdateCustomer(id, customersJivanshu);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersJivanshuExists(id))
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

        // POST: api/Admin3
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomersJivanshu>> PostCustomersJivanshu(CustomersJivanshu customersJivanshu)
        {
            try{
                _context.AddCustomer(customersJivanshu);
            }
            catch(DbUpdateException){
                if(CustomersJivanshuExists(customersJivanshu.CustomerId)){
                    return Conflict();
                }
                else{
                    throw;
                }
            }

            return CreatedAtAction("GetCustomersJivanshu", new { id = customersJivanshu.CustomerId }, customersJivanshu);
        }

        // DELETE: api/Admin3/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomersJivanshu(int id)
        {
            var customersJivanshu = _context.GetCustomerById(id);
            if (customersJivanshu == null)
            {
                return NotFound();
            }

            _context.DeleteCustomer(id);

            return NoContent();
        }

        private bool CustomersJivanshuExists(int id)
        {
            CustomersJivanshu j = _context.GetCustomerById(id);
            if(j != null){
                return true;
            }
            else{
                return false;
            }
        }
    }
}
