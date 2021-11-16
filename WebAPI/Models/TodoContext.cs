using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions options) : base(options) { }
        DbSet<Todo> Todos
        {
            get;
            set;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("Todo");
        }

        public DbSet<Todo> Todo { get; set; }
    }
}
