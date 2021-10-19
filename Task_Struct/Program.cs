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
        }
        static void PrintTask(Task task) {
            Console.WriteLine($"");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
