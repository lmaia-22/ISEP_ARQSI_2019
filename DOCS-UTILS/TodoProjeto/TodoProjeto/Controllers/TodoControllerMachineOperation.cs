using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProjeto.Models;

namespace TodoProjeto.Controllers
{
    [Route("api/[MachineOperation]")]
    [ApiController]
    public class TodoControllerMachineOperation : ControllerBase
    {
        private readonly TodoContextMachineOperation _context;

        public TodoControllerMachineOperation(TodoContextMachineOperation context)
        {
            _context = context;

            if (_context.TodoItemsMachineOperation.Count() == 0)
            {
                // Create a new TodoItemMachines if collection is empty,
                // which means you can't delete all TodoItemsMachines.
                _context.TodoItemsMachineOperation.Add(new TodoItemMachineOperation { IdMachineOperation  = 1 });
                _context.SaveChanges();
            }
        }
        // GET: api/Projeto
[HttpGet]
public async Task<ActionResult<IEnumerable<TodoItemMachineOperation>>> GetTodoItems()
{
    return await _context.TodoItemsMachineOperation.ToListAsync();
}

// GET: api/Projeto/5
[HttpGet("{IdMachineOperation}")]
public async Task<ActionResult<TodoItemMachineOperation>> GetTodoItem(long IdMachineOperation)
{
    var todoItemMachineOperation = await _context.TodoItemsMachineOperation.FindAsync(IdMachineOperation);

    if (todoItemMachineOperation == null)
    {
        return NotFound();
    }

    return todoItemMachineOperation;
}
// POST: api/Todo
[HttpPost]
public async Task<ActionResult<TodoItemMachineOperation>> PostTodoItem(TodoItemMachineOperation item)
{
    _context.TodoItemsMachineOperation.Add(item);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetTodoItem), new { id = item.IdMachineOperation }, item);
}
    }
   }