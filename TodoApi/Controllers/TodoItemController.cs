using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly DataContext _context;

        public TodoItemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> getItem()
        {
         
            return Ok(await _context.TodoItems.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<TodoItem>>> addItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return Ok(await _context.TodoItems.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<TodoItem>>> deleteItem(int id)
        {
            TodoItem dbItem = await _context.TodoItems.FindAsync(id);
            if (dbItem == null)
                return BadRequest("Item not found.");
            
            _context.TodoItems.Remove(dbItem);
            await _context.SaveChangesAsync();
            return Ok(await _context.TodoItems.ToListAsync());
        }
    }
}
