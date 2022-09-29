using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProjeto.Models;

namespace TodoProjeto.Controllers
{
    [Route("api/[Tools]")]
    [ApiController]
    public class TodoControllerTools : ControllerBase
    {
        private readonly TodoContextTools _context;

        public TodoControllerTools(TodoContextTools context)
        {
            _context = context;

            if (_context.TodoItemsTools.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItemsTools.Add(new TodoItemTools { IdTools = 1 });
                _context.SaveChanges();
            }
        }
        // GET: api/Projeto
[HttpGet]
public async Task<ActionResult<IEnumerable<TodoItemTools>>> GetTodoItems()
{
    return await _context.TodoItemsTools.ToListAsync();
}

// GET: api/Projeto/5
[HttpGet("{IdTools}")]
public async Task<ActionResult<TodoItemTools>> GetTodoItem(long IdTools)
{
    var todoItemTools = await _context.TodoItemsTools.FindAsync(IdTools);

    if (todoItemTools == null)
    {
        return NotFound();
    }

    return todoItemTools;
}
// POST: api/Todo
[HttpPost]
public async Task<ActionResult<TodoItemTools>> PostTodoItem(TodoItemTools item)
{
    _context.TodoItemsTools.Add(item);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetTodoItem), new { id = item.IdTools }, item);
}
    }
   }