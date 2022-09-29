using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProjeto.Models;

namespace TodoProjeto.Controllers
{
    [Route("api/fabricplan")] // letras minusculas sem []
    [ApiController]
    public class TodoControllerFabricPlan : ControllerBase
    {
        private readonly TodoContextFabricPlan _context;

        public TodoControllerFabricPlan(TodoContextFabricPlan context)
        {
            _context = context;

            if (_context.TodoItemsFabricPlan.Count() == 0)
            {
                // Create a new TodoItemMachines if collection is empty,
                // which means you can't delete all TodoItemsMachines.
                _context.TodoItemsFabricPlan.Add(new TodoItemFabricPlan { IdFabricPlan  = 1 });
                _context.SaveChanges();
            }
        }
        // GET: api/Projeto
[HttpGet]
public async Task<ActionResult<IEnumerable<TodoItemFabricPlan>>> GetTodoItems()
{
    return await _context.TodoItemsFabricPlan.ToListAsync();
}

// GET: api/Projeto/5
[HttpGet("{IdFabricPlan}")]
public async Task<ActionResult<TodoItemFabricPlan>> GetTodoItem(long IdFabricPlan)
{
    var todoItemFabricPlan = await _context.TodoItemsFabricPlan.FindAsync(IdFabricPlan);

    if (todoItemFabricPlan == null)
    {
        return NotFound();
    }

    return todoItemFabricPlan;
}
// POST: api/Todo
[HttpPost]
public async Task<ActionResult<TodoItemFabricPlan>> PostTodoItem(TodoItemFabricPlan item)
{
    _context.TodoItemsFabricPlan.Add(item);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetTodoItem), new { id = item.IdFabricPlan }, item);
}
    }
   }