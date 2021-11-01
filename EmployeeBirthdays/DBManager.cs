using System;
using System.Collections.Generic;
using Npgsql;

namespace EmployeeBirthdays
{
    public static class DBManager
    {
        internal static List<Employee> Read(string connection, string request)
        {
            NpgsqlConnection conn;

            try
            {
                conn = new NpgsqlConnection(connection);
            }

            catch
            {
                return null;
            }


            conn.Open();

            List<Employee> employees = new List<Employee>();

            using (var cmd = new NpgsqlCommand(request, conn))
            {
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        var name = reader.GetString(0);
                        var date = reader.GetDate(1);
                        employees.Add(new Employee(name, ((DateTime)date)));
                    }
            }

            conn.Close();
            return employees;
        }
    }
}