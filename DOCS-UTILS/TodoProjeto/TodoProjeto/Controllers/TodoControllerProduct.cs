using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProjeto.Models;

namespace TodoProjeto.Controllers
{
    [Route("api/[Product]")]
    [ApiController]
    public class TodoControllerProduct : ControllerBase
    {
        private readonly TodoContextProduct _context;

        public TodoControllerProduct(TodoContextProduct context)
        {
            _context = context;

            if (_context.TodoItemsProduct.Count() == 0)
            {
                // Create a new TodoItemMachines if collection is empty,
                // which means you can't delete all TodoItemsMachines.
                _context.TodoItemsProduct.Add(new TodoItemProduct { IdProduct  = 1 });
                _context.SaveChanges();
            }
        }
        // GET: api/Projeto
[HttpGet]
public async Task<ActionResult<IEnumerable<TodoItemProduct>>> GetTodoItems()
{
    return await _context.TodoItemsProduct.ToListAsync();
}

// GET: api/Projeto/5
[HttpGet("{IdFabricPlan}")]
public async Task<ActionResult<TodoItemProduct>> GetTodoItem(long IdProduct)
{
    var todoItemProduct = await _context.TodoItemsProduct.FindAsync(IdProduct);

    if (todoItemProduct == null)
    {
        return NotFound();
    }

    return todoItemProduct;
}
// POST: api/Todo
[HttpPost]
public async Task<ActionResult<TodoItemProduct>> PostTodoItem(TodoItemProduct item)
{
    _context.TodoItemsProduct.Add(item);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetTodoItem), new { id = item.IdProduct }, item);
}
    }
   }