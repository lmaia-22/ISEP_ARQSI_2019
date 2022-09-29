using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProjeto.Models;

namespace TodoProjeto.Controllers
{
    [Route("api/[MasterProduction]")]
    [ApiController]
    public class TodoControllerMasterProduction : ControllerBase
    {
        private readonly TodoContextMasterProduction _context;

        public TodoControllerMasterProduction(TodoContextMasterProduction context)
        {
            _context = context;

            if (_context.TodoItemsMasterProduction.Count() == 0)
            {
                // Create a new TodoItemMachines if collection is empty,
                // which means you can't delete all TodoItemsMachines.
                _context.TodoItemsMasterProduction.Add(new TodoItemMasterProduction { IdMasterProduction  = 1 });
                _context.SaveChanges();
            }
        }
        // GET: api/Projeto
[HttpGet]
public async Task<ActionResult<IEnumerable<TodoItemMasterProduction>>> GetTodoItems()
{
    return await _context.TodoItemsMasterProduction.ToListAsync();
}

// GET: api/Projeto/5
[HttpGet("{IdMasterProduction}")]
public async Task<ActionResult<TodoItemMasterProduction>> GetTodoItem(long IdMasterProduction)
{
    var todoItemMasterProduction = await _context.TodoItemsMasterProduction.FindAsync(IdMasterProduction);

    if (todoItemMasterProduction == null)
    {
        return NotFound();
    }

    return todoItemMasterProduction;
}
// POST: api/Todo
[HttpPost]
public async Task<ActionResult<TodoItemMasterProduction>> PostTodoItem(TodoItemMasterProduction item)
{
    _context.TodoItemsMasterProduction.Add(item);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetTodoItem), new { id = item.IdMasterProduction }, item);
}
    }
   }