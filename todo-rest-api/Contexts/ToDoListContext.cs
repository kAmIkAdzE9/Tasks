using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace todo_rest_api
{
    public class ToDoListContext : DbContext
    {
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Task> Tasks {get; set;}

        public ToDoListContext(DbContextOptions options): base(options) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine);
        }
    }
}