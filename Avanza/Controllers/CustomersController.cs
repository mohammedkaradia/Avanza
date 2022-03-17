using Avanza.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Avanza.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly Avanza_DBContext _avanza_DBContext;

        public CustomersController(Avanza_DBContext avanza_DBContext)
        {
            _avanza_DBContext = avanza_DBContext;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            return await _avanza_DBContext.Customers.ToListAsync();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomer(int id)
        {
            var customer = await _avanza_DBContext.Customers.FindAsync(id);

            if(customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomer(Customers customers)
        {
            _avanza_DBContext.Customers.Add(customers);
            await _avanza_DBContext.SaveChangesAsync();

            return CreatedAtAction("GetCustomers", new { id = customers.Id }, customers);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customers customers)
        {
            if (id != customers.Id)
            {
                return BadRequest();
            }

            _avanza_DBContext.Entry(customers).State = EntityState.Modified;

            try
            {
                await _avanza_DBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new ArgumentException(ex.Message);
                }
            }

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _avanza_DBContext.Customers.Any(e => e.Id == id);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customers>> DeleteCustomer(int id)
        {
            var customer = await _avanza_DBContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _avanza_DBContext.Customers.Remove(customer);
            await _avanza_DBContext.SaveChangesAsync();

            return customer;
        }
    }
}
