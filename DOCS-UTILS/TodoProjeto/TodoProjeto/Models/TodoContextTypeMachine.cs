using Microsoft.EntityFrameworkCore;

namespace TodoProjeto.Models
{
    public class TodoContextTypeMachine : DbContext
    {
        public TodoContextTypeMachine(DbContextOptions<TodoContextTypeMachine> options)
            : base(options)
        {
        }

        public DbSet<TodoItemTypeMachine> TodoItemsTypeMachine { get; set; }
    }
}