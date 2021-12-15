using System;
using System.Data.OleDb;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Database connection
            OleDbConnection connection = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();

            OleDbDataReader reader;

            // connection
            connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                          @"Data Source=C:\Users\ChristianLehnert\Downloads\chsharp_stuff\UserLogin\userdb.accdb";


            // create command connection
            cmd.Connection = connection;

            // open connection
            try
            {
                connection.Open();
            } catch(Exception ex)
            {
                Console.WriteLine("Something went wrong while opening...");
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadKey();
                return;
            }

            // Login Form CLI based
            do
            {
                Console.WriteLine("------ Login Form ------");
                Console.WriteLine("l - Login");
                Console.WriteLine("r - register");
                Console.Write("Enter your command: ");

                // get command and convert to lowercase
                string command = Console.ReadLine().ToLower();

                if (command == "r")
                {
                    // Register user
                } else if (command == "l")
                {
                    // login user
                    Console.WriteLine("------ Login ------");
                    
                    Console.WriteLine("Enter your username: ");
                    var username = Console.ReadLine();

                    Console.WriteLine("Enter your password: ");
                    var password = Console.ReadLine();

                    // check if username exists
                    OleDbDataReader readerDb;
                    string errorMessage = "Something went wrong! Please check your password or username";

                    cmd.CommandText = $"select * from Users where username=\"{username}\";";

                    readerDb = cmd.ExecuteReader();

                    // read
                    int val = 0;

                    while (readerDb.Read())
                    {
                        val++;
                    }

                    // check if we found a user
                    if (val != 0)
                    {
                        string userN = readerDb["username"].ToString();
                        string passwd = readerDb["password"].ToString();

                    } else
                    {
                        Console.Write($"{errorMessage}\n");
                        // close reader
                        readerDb.Close();
                        continue;
                    }
                } else
                {
                    Console.WriteLine("Wrong command");
                    break;
                }


            } while (true);

            connection.Close();
        }
    }
}
