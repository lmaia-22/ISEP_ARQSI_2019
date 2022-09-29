using Microsoft.EntityFrameworkCore;

namespace TodoProjeto.Models
{
    public class TodoContextProductionLine : DbContext
    {
        public TodoContextProductionLine(DbContextOptions<TodoContextProductionLine> options)
            : base(options)
        {
        }

        public DbSet<TodoItemProductionLine> TodoItemsProductionLine { get; set; }
    }
}