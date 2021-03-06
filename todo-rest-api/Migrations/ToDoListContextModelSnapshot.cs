// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using todo_rest_api;

namespace todo_rest_api.Migrations
{
    [DbContext(typeof(ToDoListContext))]
    partial class ToDoListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("todo_rest_api.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("Done")
                        .HasColumnType("boolean")
                        .HasColumnName("done");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("due_date");

                    b.Property<int>("TaskListId")
                        .HasColumnType("integer")
                        .HasColumnName("task_list_id");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_tasks");

                    b.HasIndex("TaskListId")
                        .HasDatabaseName("ix_tasks_task_list_id");

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("todo_rest_api.TaskList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_task_lists");

                    b.ToTable("task_lists");
                });

            modelBuilder.Entity("todo_rest_api.Task", b =>
                {
                    b.HasOne("todo_rest_api.TaskList", "TaskList")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskListId")
                        .HasConstraintName("fk_tasks_task_lists_task_list_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskList");
                });

            modelBuilder.Entity("todo_rest_api.TaskList", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
