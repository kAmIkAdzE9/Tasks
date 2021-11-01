using System;
using Npgsql;
using System.Collections.Generic;

namespace todolist_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            //todolist
            var connString = "Host=127.0.0.1;Username=todolist_app;Password=todolist;Database=todolist";
            List<string> requests = new List<string>();

            requests.Add("select title, description, due_date, done from tasks");
            requests.Add("update tasks set done=false where title='Task 1'");
            requests.Add("select title, description, due_date, done from tasks");

            Console.WriteLine(DBManager.MakeRequests(connString, requests));

            //employee birthdays
            connString = "Host=127.0.0.1;Username=todolist_app;Password=todolist;Database=employee_birthdays";
            requests = new List<string>();

            requests.Add("select name, birthday from employees");
            requests.Add("update employees set birthday='2001-11-23' where name='Olga'");
            requests.Add("insert into employees(name, birthday) values ('Vasyl', '1997-02-08')");
            requests.Add("select name, birthday from employees");
            requests.Add("delete from employees where name='Vasyl'");
            requests.Add("select name, birthday from employees");

            Console.WriteLine(DBManager.MakeRequests(connString, requests));
        }
    }
}
