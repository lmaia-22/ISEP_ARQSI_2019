using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectIteration1.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product {get; set;}
        public DbSet<FabricPlan> FabricPlan {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<List<long>>();
        }
 
    }
}