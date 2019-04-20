using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRestTest.Dao;
using CRestTest.Model;
using Microsoft.EntityFrameworkCore;

namespace CRestTest.Controllers
{
    [Route("api/v0/items")]
    [ApiController]
    public class ItemsControllerSimple : ControllerBase
    {
        private readonly MyDbContext _context;

        public ItemsControllerSimple(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/v0/items
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return _context.Items.FromSql("SELECT item_id, name, price, size FROM items").ToList();
        }

        // GET: api/v0/items/5
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(long id)
        {
            return _context.Items.FromSql($"SELECT item_id, name, price, size FROM items WHERE item_id = {id}").FirstOrDefault();
        }

        // POST: api/v0/items
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            await _context.Database.ExecuteSqlCommandAsync(
                $"insert into items (name, price, size) values ({item.Name}, {item.Price}, {item.Size})");

            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item);
        }

        // PUT: api/v0/items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(long id, Item item)
        {
            if (id != item.Id) return BadRequest();

            var old = GetItem(id);
            if (old.Value == null) return PostItem(item).Result.Result; // Insert if no already existing item was found

            // Otherwise update the existing one
            await _context.Database.ExecuteSqlCommandAsync(
                $"update items set name = {item.Name}, price = {item.Price}, size = {item.Size} where item_id = {id}");
            return NoContent();
        }

        // DELETE: api/v0/items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            await _context.Database.ExecuteSqlCommandAsync($"delete from items where item_id = {id}");
            return NoContent();
        }
    }
}
