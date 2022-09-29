using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProjeto.Models;

namespace TodoProjeto.Controllers
{
    [Route("api/[ProductionLine]")]
    [ApiController]
    public class TodoControllerProductionLine : ControllerBase
    {
        private readonly TodoContextProductionLine _context;

        public TodoControllerProductionLine(TodoContextProductionLine context)
        {
            _context = context;

            if (_context.TodoItemsProductionLine.Count() == 0)
            {
                // Create a new TodoItemMachines if collection is empty,
                // which means you can't delete all TodoItemsMachines.
                _context.TodoItemsProductionLine.Add(new TodoItemProductionLine { IdProductionLine  = 1 });
                _context.SaveChanges();
            }
        }
        // GET: api/Projeto
[HttpGet]
public async Task<ActionResult<IEnumerable<TodoItemProductionLine>>> GetTodoItems()
{
    return await _context.TodoItemsProductionLine.ToListAsync();
}

// GET: api/Projeto/5
[HttpGet("{IdProductionLine}")]
public async Task<ActionResult<TodoItemProductionLine>> GetTodoItem(long IdProductionLine)
{
    var todoItemProductionLine = await _context.TodoItemsProductionLine.FindAsync(IdProductionLine);

    if (todoItemProductionLine == null)
    {
        return NotFound();
    }

    return todoItemProductionLine;
}
// POST: api/Todo
[HttpPost]
public async Task<ActionResult<TodoItemProductionLine>> PostTodoItem(TodoItemProductionLine item)
{
    _context.TodoItemsProductionLine.Add(item);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetTodoItem), new { id = item.IdProductionLine }, item);
}
    }
   }