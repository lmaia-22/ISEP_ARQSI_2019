using Microsoft.EntityFrameworkCore;

namespace TodoProjeto.Models
{
    public class TodoContextProduct : DbContext
    {
        public TodoContextProduct(DbContextOptions<TodoContextProduct> options)
            : base(options)
        {
        }

        public DbSet<TodoItemProduct> TodoItemsProduct { get; set; }
    }
}