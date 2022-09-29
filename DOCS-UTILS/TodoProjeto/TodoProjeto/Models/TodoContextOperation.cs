using Microsoft.EntityFrameworkCore;

namespace TodoProjeto.Models
{
    public class TodoContextOperation : DbContext
    {
        public TodoContextOperation(DbContextOptions<TodoContextOperation> options)
            : base(options)
        {
        }

        public DbSet<TodoItemOperation> TodoItemsOperation { get; set; }
    }
}