using Microsoft.EntityFrameworkCore;

namespace TodoProjeto.Models
{
    public class TodoContextFabricPlan : DbContext
    {
        public TodoContextFabricPlan(DbContextOptions<TodoContextFabricPlan> options)
            : base(options)
        {
        }

        public DbSet<TodoItemFabricPlan> TodoItemsFabricPlan { get; set; }
    }
}