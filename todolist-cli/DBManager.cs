using System;
using System.Collections.Generic;
using Npgsql;

namespace todolist_cli
{
    public static class DBManager {
        public static string MakeRequests(string connection, List<string> requests)
        {
            string status = "All requests was done.\n";
            NpgsqlConnection conn;

            try
            {
                conn = new NpgsqlConnection(connection);
            }
            catch
            {
                return "Can not connect to DB.";
            }


            conn.Open();

            try
            {
                foreach (string request in requests)
                {
                    if(request.ToLower()[0] == 's') {
                        Console.WriteLine(Read(conn, request));
                    }
                    else 
                    {
                        Console.WriteLine(MakeRequest(conn, request));
                    }
                }
            }
            catch
            {
                status =  "Can not make requests. Probably some of the requests is wrong.";
            }

            conn.Close();
            return status;
        }

        private static string Read(NpgsqlConnection conn, string request)
        {
            string output = "";

            using (var cmd = new NpgsqlCommand(request, conn))
            {
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        for(int i = 0; i < reader.FieldCount; i++) {
                            output += reader.GetValue(i).ToString() + " ";
                        }
                        output += "\n";
                    }
            }

            return output;
        }

        private static string MakeRequest(NpgsqlConnection conn, string request)
        {
            string output = "";
            try
            {
                var cmd = new NpgsqlCommand(request, conn);
                cmd.ExecuteNonQuery();
                output = "Request was done: " + request + "\n";
            }
            catch
            {
                return "Can not make request: " + request + "\n";
            }
            return output;
        }
    }
}