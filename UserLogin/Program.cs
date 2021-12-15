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
                    do
                    {
                        // Register user
                        Console.WriteLine("------ Register ------");

                        // read username
                        Console.WriteLine("Enter a username ");
                        var username = Console.ReadLine();

                        Console.WriteLine("Enter a passwd");
                        var password = Console.ReadLine();

                        // check if user already exists
                        cmd.CommandText = $"select * from Users where username=\"{username}\";";

                        try
                        {
                            OleDbDataReader r = cmd.ExecuteReader();

                            int count = 0;

                            while (r.Read())
                            {
                                count++;
                            }

                            if (count != 0)
                            {
                                r.Close();
                                Console.WriteLine("Cannot add user! Please enter another username");
                                continue;
                            }

                            // add user
                            try
                            {
                                // close before creating a new command
                                r.Close();
                                cmd.CommandText = $"INSERT INTO Users (username,passwd) VALUES ('{username}','{PasswdValid.HashString(password)}');";

                                cmd.ExecuteNonQuery();
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Failed to add user");
                                Console.WriteLine("Error: " + ex.Message);
                                continue;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Failed to search users");
                            continue;
                        }
                    } while (true);

                    break;
                } else if (command == "l")
                {
                    do
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

                        try
                        {
                            readerDb = cmd.ExecuteReader();

                            // read
                            int val = 0;

                            string userN = "";
                            string passwd = "";

                            while (readerDb.Read())
                            {
                                val++;

                                userN = readerDb["username"].ToString();
                                passwd = readerDb["passwd"].ToString();
                            }

                            // check if we found a user
                            if (val != 0)
                            {

                                try
                                {
                                    if (PasswdValid.isPassword(password, passwd))
                                    {
                                        Console.Write($"Hello, {userN}");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{errorMessage}\n");
                                        readerDb.Close();
                                        continue;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error while hashing");
                                }
                            }
                            else
                            {
                                Console.Write($"{errorMessage}\n");
                                // close reader
                                readerDb.Close();
                                continue;
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to login... DB error");
                            Console.WriteLine("Error: " + ex.Message);
                        }
                    } while (true);

                    break;
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
