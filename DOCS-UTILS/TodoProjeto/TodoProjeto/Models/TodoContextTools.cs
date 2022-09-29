using Microsoft.EntityFrameworkCore;

namespace TodoProjeto.Models
{
    public class TodoContextTools : DbContext
    {
        public TodoContextTools(DbContextOptions<TodoContextTools> options)
            : base(options)
        {
        }

        public DbSet<TodoItemTools> TodoItemsTools { get; set; }
    }
}