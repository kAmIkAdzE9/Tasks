using System;

namespace Task_Struct
{
    class Program
    {
        struct Task {
            public string title;
            public string desc;
            public string done;
            public DateTime dueDate;
            public int indentifier;
        }
        static void PrintTask(Task task) {
            string date = "";
            if(task.dueDate != new DateTime())
                date = $"({task.dueDate.ToString("MMM dd")})";
            Console.WriteLine($"{task.indentifier}. {task.done} {task.title} {date}\n{task.desc}");
        }
        static void Main(string[] args)
        {
            Task task;
            task.title = "Implement task output";
            task.done = "[X]";
            task.dueDate = new DateTime(2021, 08, 25);
            task.desc = "Use fields: title, desc, done, dueData";
            task.indentifier = 1;
            PrintTask(task);

            Task task2;
            task2.indentifier = 2;
            task2.title = "some title";
            task2.done = "[]";
            task2.desc = "";
            task2.dueDate = new DateTime();
            PrintTask(task2);
        }
    }
}
