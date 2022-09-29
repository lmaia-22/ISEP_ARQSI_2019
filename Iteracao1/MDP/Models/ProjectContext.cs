using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectIteration1.Models
{
    public class ProjectContext : DbContext 
    {
        public ProjectContext(DbContextOptions<ProjectContext> options = null)
            : base(options)
        {
        }
        public DbSet<TypeMachine> TypeMachine {get; set;}
        public DbSet<Operation> Operation {get; set;}
        public DbSet<ProductionLine> ProductionLine {get; set;}
        public DbSet<Machine> Machine {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<List<long>>();
        }
    }
}