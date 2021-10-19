using System;

namespace Task_Struct
{
    class Program
    {
        struct Task {
            public string title;
            public string desc;
            public bool done;
            public DateTime dueDate;
            public int indentifier;
        }
        static void PrintTask(Task task) {
            string status = "";

            if(task.done) {
                status = "[X]";
            }
            else {
                status = "[ ]";
            }

            string date = "";

            if(task.dueDate != new DateTime())
                date = $"({task.dueDate.ToString("MMM dd")})";

            Console.WriteLine($"{task.indentifier}. {status} {task.title} {date}\n{task.desc}");
        }
        static void Main(string[] args)
        {
            Task task;
            task.title = "Implement task output";
            task.done = true;
            task.dueDate = new DateTime(2021, 08, 25);
            task.desc = "Use fields: title, desc, done, dueData";
            task.indentifier = 1;
            PrintTask(task);

            Task task2;
            task2.indentifier = 2;
            task2.title = "some title";
            task2.done = false;
            task2.desc = "";
            task2.dueDate = new DateTime();
            PrintTask(task2);
        }
    }
}
