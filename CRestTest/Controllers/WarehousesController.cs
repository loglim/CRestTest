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
    public class WarehousesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public WarehousesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/warehouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehouses()
        {
            return await _context.Warehouses.ToListAsync();
        }

        // GET: api/v1/warehouses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> GetWarehouse(long id)
        {
            var supply = await _context.Warehouses.FindAsync(id);
            return supply ?? (ActionResult<Warehouse>) NotFound();
        }

        // POST: api/v1/warehouses
        [HttpPost]
        public async Task<ActionResult<Warehouse>> PostWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWarehouse), new {id = warehouse.Id}, warehouse);
        }

        // PUT: api/v1/warehouses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarehouse(long id, Warehouse warehouse)
        {
            if (id != warehouse.Id) return BadRequest();

            _context.Entry(warehouse).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/v1/warehouses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(long id)
        {
            var supply = await _context.Warehouses.FindAsync(id);
            if (supply == null) return NotFound();

            _context.Warehouses.Remove(supply);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
