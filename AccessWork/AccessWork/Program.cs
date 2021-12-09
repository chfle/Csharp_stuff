using System;
using System.Data.OleDb;
using System.Linq.Expressions;

namespace AccessWork
{
    class Program
    {
        static void Main(string[] args)
        {
            OleDbConnection connection = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            OleDbDataReader reader;

            // connection
            connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                          @"Data Source=C:\Users\ChristianLehnert\Downloads\chsharp_stuff\AccessWork\AccessWork\Firma21.accdb";

            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM person";

            try
            {
                connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["name"]}, {reader["vorname"]}, {reader["personalnummer"]}, " +
                                      $"{reader["gehalt"]}, {reader["geburtstag"]}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // C:\Users\ChristianLehnert\Downloads
        }
    }
}