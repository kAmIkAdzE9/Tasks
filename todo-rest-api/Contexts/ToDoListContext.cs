using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace todo_rest_api
{
    public class ToDoListContext : DbContext
    {
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Task> Tasks {get; set;}

        public ToDoListContext(DbContextOptions options) {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine)
                .UseSnakeCaseNamingConvention()
                .UseNpgsql("Host=127.0.0.1;Username=todolist_app;Password=todolist;Database=tasklist");
        }
    }
}