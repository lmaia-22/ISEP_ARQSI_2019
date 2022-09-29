using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProjeto.Models;

namespace TodoProjeto.Controllers
{
    [Route("api/[Machines]")]
    [ApiController]
    public class TodoControllerMachines : ControllerBase
    {
        private readonly TodoContextMachines _context;

        public TodoControllerMachines(TodoContextMachines context)
        {
            _context = context;

            if (_context.TodoItemsMachines.Count() == 0)
            {
                // Create a new TodoItemMachines if collection is empty,
                // which means you can't delete all TodoItemsMachines.
                _context.TodoItemsMachines.Add(new TodoItemMachines { IdMachine  = 1 });
                _context.SaveChanges();
            }
        }
        // GET: api/Projeto
[HttpGet]
public async Task<ActionResult<IEnumerable<TodoItemMachines>>> GetTodoItems()
{
    return await _context.TodoItemsMachines.ToListAsync();
}

// GET: api/Projeto/5
[HttpGet("{IdMachine}")]
public async Task<ActionResult<TodoItemMachines>> GetTodoItem(long IdMachine)
{
    var todoItemMachines = await _context.TodoItemsMachines.FindAsync(IdMachine);

    if (todoItemMachines == null)
    {
        return NotFound();
    }

    return todoItemMachines;
}
// POST: api/Todo
[HttpPost]
public async Task<ActionResult<TodoItemMachines>> PostTodoItem(TodoItemMachines item)
{
    _context.TodoItemsMachines.Add(item);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetTodoItem), new { id = item.IdMachine }, item);
}
    }
   }