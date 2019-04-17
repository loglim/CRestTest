using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRestTest.Dao;
using CRestTest.Model;
using Microsoft.EntityFrameworkCore;

namespace CRestTest.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SuppliesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/supplies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supply>>> GetSupplies()
        {
            return await _context.Supplies.ToListAsync();
        }

        // GET: api/v1/supplies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supply>> GetSupply(long id)
        {
            var supply = await _context.Supplies.FindAsync(id);
            return supply ?? (ActionResult<Supply>) NotFound();
        }

        // POST: api/v1/supplies
        [HttpPost]
        public async Task<ActionResult<Supply>> PostSupply(Supply supply)
        {
            _context.Supplies.Add(supply);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSupply), new {id = supply.ItemId}, supply);
        }

        // PUT: api/v1/supplies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupply(long id, Supply supply)
        {
            if (id != supply.ItemId) return BadRequest();

            _context.Entry(supply).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/v1/supplies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupply(long id)
        {
            var supply = await _context.Supplies.FindAsync(id);
            if (supply == null) return NotFound();

            _context.Supplies.Remove(supply);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
