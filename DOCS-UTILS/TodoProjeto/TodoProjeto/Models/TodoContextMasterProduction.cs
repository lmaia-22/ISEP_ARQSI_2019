using Microsoft.EntityFrameworkCore;

namespace TodoProjeto.Models
{
    public class TodoContextMasterProduction : DbContext
    {
        public TodoContextMasterProduction(DbContextOptions<TodoContextMasterProduction> options)
            : base(options)
        {
        }

        public DbSet<TodoItemMasterProduction> TodoItemsMasterProduction { get; set; }
    }
}