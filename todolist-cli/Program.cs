using System;
using Npgsql;
using System.Collections.Generic;

namespace todolist_cli
{
    class Program
    {
        static string GetReadRequest(string table, string condition)
        {
            string output = $"Select title, description, due_date, done from {table}";
            if (condition != "")
            {
                output += $" where {condition}";
            }
            return output;
        }

        static string GetDeleteRequest(string table, string condition)
        {
            return $"Delete from {table} where {condition}";
        }

        static string GetInsertRequest(string table, string title, string description, string dueDate, string done)
        {
            return $"Insert into {table} (title, description, due_date, done) values('{title}', '{description}', '{dueDate}', '{done}')";
        }

        static string GetUpdateRequest(string table, string title, string description, string dueDate, string done, string condition)
        {
            return $"Update {table} set title='{title}', description='{description}', due_date='{dueDate}', done='{done}' where {condition}";
        }


        static void Main(string[] args)
        {
            var connString = "Host=127.0.0.1;Username=todolist_app;Password=todolist;Database=todolist";
            string table = "tasks";
            ConsoleUi(connString, table);

        }

        static void ConsoleUi(string connString, string table)
        {
            List<string> requests = new List<string>();
            string input = "";
            string request = "";
            string title, description, dueDate, done, condition;

            do
            {
                Console.WriteLine("Keywords: 'read', 'write', 'update', 'delete', 'make_requests', 'clear', 'exit'");
                input = Console.ReadLine();
                switch (input)
                {
                    case "read":
                        Console.WriteLine("Enter condition");
                        condition = Console.ReadLine();
                        
                        request = GetReadRequest(table, condition);
                        Console.WriteLine(request);
                        requests.Add(request);
                        break;

                    case "write":
                        Console.WriteLine("Enter title");
                        title = Console.ReadLine();

                        Console.WriteLine("Enter description");
                        description = Console.ReadLine();

                        Console.WriteLine("Enter dueDate");
                        dueDate = Console.ReadLine();

                        Console.WriteLine("Enter done");
                        done = Console.ReadLine();

                        request = GetInsertRequest(table, title, description, dueDate, done);
                        Console.WriteLine(request);
                        requests.Add(request); 

                        break;

                    case "update":
                        Console.WriteLine("Enter title");
                        title = Console.ReadLine();

                        Console.WriteLine("Enter description");
                        description = Console.ReadLine();

                        Console.WriteLine("Enter dueDate");
                        dueDate = Console.ReadLine();

                        Console.WriteLine("Enter done");
                        done = Console.ReadLine();

                        Console.WriteLine("Enter condition");
                        condition = Console.ReadLine();

                        request = GetUpdateRequest(table, title, description, dueDate, done, condition);
                        Console.WriteLine(request);
                        requests.Add(request);
                        
                        break;

                    case "delete":
                        Console.WriteLine("Enter condition");
                        condition = Console.ReadLine();

                        request = GetReadRequest(table, condition);
                        Console.WriteLine(request);
                        requests.Add(request);
                        
                        break;

                    case "clear":
                        requests.Clear();
                        break;

                    case "make_requests":
                        Console.WriteLine(DBManager.MakeRequests(connString, requests));
                        break;
                }
            }
            while (input != "exit");
        }
    }
}
