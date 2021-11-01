using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace EmployeeBirthdays
{
    class Program
    {
        static string Pluralization(int n, string form1, string form2, string form3)
        {
            if (n % 100 > 10 && n % 100 < 15) { return form3; }
            else if (n % 10 == 1) { return form1; }
            else if (n % 10 > 1 && n % 10 < 5) { return form2; }
            else
            {
                return form3;
            }
        }
        static void PrintEmployee(Employee employee)
        {
            int age = Math.Abs(DateTime.Now.Year - employee.getBirthday().Year);
            string year = Pluralization(age, "рік", "роки", "років");
            Console.WriteLine($"({employee.getBirthday().Day}) - {employee.getName()} ({age} {year})");
        }

        static void PrintEmployessOfChoosenMonths(List<Employee> employees, int shift)
        {
            foreach (Employee employee in employees)
            {
                if (DateTime.Now.Month + shift == employee.getBirthday().Month)
                {
                    PrintEmployee(employee);
                }
            }
        }
        static void PrintMonth(int shift)
        {
            DateTime today = DateTime.Now;
            int k = Math.Abs(today.Month + shift) / 12;

            Console.WriteLine(new DateTime(today.Year + k, Math.Abs(today.Month + shift) % 12, today.Day).ToString("MMMM yyyy", new CultureInfo("uk")));
        }

        static void PrintEmployees(List<Employee> employees, int k)
        {
            DateTime today = DateTime.Now;
            List<Employee> newList = employees.OrderBy(e => e.getBirthday().Day).ToList();
            PrintMonth(0);
            PrintEmployessOfChoosenMonths(newList, 0);
            if (k > 0)
            {
                PrintMonth(1);
                PrintEmployessOfChoosenMonths(newList, 1);
            }
            if (k == 2)
            {
                PrintMonth(2);
                PrintEmployessOfChoosenMonths(newList, 2);
            }
        }

        static void PrintEmployees_2(Dictionary<int, List<Employee>> employees, int k)
        {
            DateTime today = DateTime.Now;
            for (int i = 0; i <= Math.Abs(k); i++)
            {
                foreach (KeyValuePair<int, List<Employee>> keyValue in employees)
                {
                    if (k > 0)
                    {
                        if (keyValue.Key == Math.Abs(today.Month + i) % 12)
                        {
                            PrintMonth(i);
                            foreach (Employee employee in keyValue.Value)
                            {
                                PrintEmployee(employee);
                            }
                        }
                    }
                    else
                    {
                        if (keyValue.Key == Math.Abs(today.Month - i) % 12)
                        {
                            PrintMonth(-i);
                            foreach (Employee employee in keyValue.Value)
                            {
                                PrintEmployee(employee);
                            }
                        }
                    }
                }
            }
        }

        static Dictionary<int, List<Employee>> getDictOfEmployees(List<Employee> employees)
        {
            List<Employee> newList = employees.OrderBy(e => e.getBirthday().Day).ToList();
            Dictionary<int, List<Employee>> dict = new Dictionary<int, List<Employee>>();
            foreach (Employee employee in newList)
            {
                if (dict.ContainsKey(employee.getBirthday().Month))
                {
                    dict[employee.getBirthday().Month].Add(employee);
                }
                else
                {
                    List<Employee> list = new List<Employee>();
                    list.Add(employee);
                    dict[employee.getBirthday().Month] = list;
                }
            }
            return dict;
        }

        static void Main(string[] args)
        {
            var connString = "Host=127.0.0.1;Username=todolist_app;Password=todolist;Database=employee_birthdays";
            string request = "Select name, birthday from employees";

            List<Employee> employees = DBManager.Read(connString, request);

            //PrintEmployees(employees, 2); //Not using dictionary
            Console.WriteLine();
            PrintEmployees_2(getDictOfEmployees(employees), 5); //Using Dictionary
        }
    }
}
