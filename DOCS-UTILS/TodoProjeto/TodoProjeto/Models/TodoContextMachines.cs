using Microsoft.EntityFrameworkCore;

namespace TodoProjeto.Models
{
    public class TodoContextMachines : DbContext
    {
        public TodoContextMachines(DbContextOptions<TodoContextMachines> options)
            : base(options)
        {
        }

        public DbSet<TodoItemMachines> TodoItemsMachines { get; set; }
    }
}