using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProjeto.Models;

namespace TodoProjeto.Controllers
{
    [Route("api/[Operation]")]
    [ApiController]
    public class TodoControllerOperation : ControllerBase
    {
        private readonly TodoContextOperation _context;

        public TodoControllerOperation(TodoContextOperation context)
        {
            _context = context;

            if (_context.TodoItemsOperation.Count() == 0)
            {
                // Create a new TodoItemMachines if collection is empty,
                // which means you can't delete all TodoItemsMachines.
                _context.TodoItemsOperation.Add(new TodoItemOperation { IdOperation  = 1 });
                _context.SaveChanges();
            }
        }
        // GET: api/Projeto
[HttpGet]
public async Task<ActionResult<IEnumerable<TodoItemOperation>>> GetTodoItems()
{
    return await _context.TodoItemsOperation.ToListAsync();
}

// GET: api/Projeto/5
[HttpGet("{IdOperation}")]
public async Task<ActionResult<TodoItemOperation>> GetTodoItem(long IdOperation)
{
    var todoItemOperation = await _context.TodoItemsOperation.FindAsync(IdOperation);

    if (todoItemOperation == null)
    {
        return NotFound();
    }

    return todoItemOperation;
}
// POST: api/Todo
[HttpPost]
public async Task<ActionResult<TodoItemOperation>> PostTodoItem(TodoItemOperation item)
{
    _context.TodoItemsOperation.Add(item);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetTodoItem), new { id = item.IdOperation }, item);
}
    }
   }