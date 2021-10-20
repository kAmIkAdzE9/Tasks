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
            Console.WriteLine(new DateTime(today.Year, today.Month + shift, today.Day).ToString("MMMM yyyy", new CultureInfo("uk")));
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
            for (int i = 0; i <= k; i++)
            {
                foreach (KeyValuePair<int, List<Employee>> keyValue in employees)
                {
                    if (keyValue.Key == today.Month + i)
                    {
                        PrintMonth(i);
                        foreach (Employee employee in keyValue.Value)
                        {
                            PrintEmployee(employee);
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
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Igor", new DateTime(1999, 10, 17)));
            employees.Add(new Employee("Viktor", new DateTime(1998, 10, 14)));
            employees.Add(new Employee("Olga", new DateTime(2001, 11, 24)));
            employees.Add(new Employee("Olena", new DateTime(1996, 12, 02)));
            employees.Add(new Employee("Olexander", new DateTime(1991, 9, 04)));
            employees.Add(new Employee("Oleg", new DateTime(1992, 11, 29)));
            employees.Add(new Employee("Anton", new DateTime(1993, 10, 08)));

            PrintEmployees(employees, 2); //Not using dictionary
            Console.WriteLine();
            PrintEmployees_2(getDictOfEmployees(employees), 2); //Using Dictionary
        }
    }
}
