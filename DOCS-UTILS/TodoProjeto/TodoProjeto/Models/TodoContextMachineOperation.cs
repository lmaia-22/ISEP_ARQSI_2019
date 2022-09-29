using Microsoft.EntityFrameworkCore;

namespace TodoProjeto.Models
{
    public class TodoContextMachineOperation : DbContext
    {
        public TodoContextMachineOperation(DbContextOptions<TodoContextMachineOperation> options)
            : base(options)
        {
        }

        public DbSet<TodoItemMachineOperation> TodoItemsMachineOperation { get; set; }
    }
}