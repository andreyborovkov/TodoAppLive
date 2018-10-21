using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAppLive.Models
{
    public class Context : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TodoCategory> TodoCategories { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Home" },
                new Category() { Id = 2, Name = "Business" }
                );

            modelBuilder.Entity<Todo>().HasData(
                new Todo() { Id = 1, Description = "This is the seed data", DueDate = DateTime.Now, OwnerId = 1 }
                );
            modelBuilder.Entity<Owner>().HasData(
                new Owner() { Id = 1, Name = "Maggie"},
                new Owner() { Id = 2, Name = "Neko" },
                new Owner() { Id = 3, Name = "Jen" }
                );
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server = (localdb)\\mssqllocaldb; Database = KMTodos; Trusted_Connection = True; ";

            optionsBuilder.UseSqlServer(connectionString)
                .UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
