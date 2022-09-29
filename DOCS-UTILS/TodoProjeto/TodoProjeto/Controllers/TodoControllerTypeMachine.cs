using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProjeto.Models;

namespace TodoProjeto.Controllers
{
    [Route("api/[TypeMachine]")]
    [ApiController]
    public class TodoControllerTypeMachine : ControllerBase
    {
        private readonly TodoContextTypeMachine _context;

        public TodoControllerTypeMachine(TodoContextTypeMachine context)
        {
            _context = context;

            if (_context.TodoItemsTypeMachine.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItemsTypeMachine.Add(new TodoItemTypeMachine { IdTypeMachine = 1 });
                _context.SaveChanges();
            }
        }
        // GET: api/Projeto
[HttpGet]
public async Task<ActionResult<IEnumerable<TodoItemTypeMachine>>> GetTodoItems()
{
    return await _context.TodoItemsTypeMachine.ToListAsync();
}

// GET: api/Projeto/5
[HttpGet("{IdTypeMachine}")]
public async Task<ActionResult<TodoItemTypeMachine>> GetTodoItem(long IdTypeMachine)
{
    var todoItemTypeMachine = await _context.TodoItemsTypeMachine.FindAsync(IdTypeMachine);

    if (todoItemTypeMachine == null)
    {
        return NotFound();
    }

    return todoItemTypeMachine;
}
// POST: api/Todo
[HttpPost]
public async Task<ActionResult<TodoItemTypeMachine>> PostTodoItem(TodoItemTypeMachine item)
{
    _context.TodoItemsTypeMachine.Add(item);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetTodoItem), new { id = item.IdTypeMachine }, item);
}
    }
   }