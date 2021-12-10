using System;
using System.Data.OleDb;

// C:\Users\ChristianLehnert\Downloads\chsharp_stuff\ItemDB\ItemDB\Database51.accdb

namespace ItemDB
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
                                          @"Data Source=C:\Users\ChristianLehnert\Downloads\chsharp_stuff\ItemDB\ItemDB\Database51.accdb";

            bool go = true;
            bool valid = true;

            cmd.Connection = connection;
            
            do
            {
                Console.WriteLine("======= Menu ======");
                Console.WriteLine("Commands:");
                Console.WriteLine("d - delete one or more items");
                Console.WriteLine("a - add a new item");
                Console.WriteLine("f - show full table");
                Console.WriteLine("s - search item");
                Console.WriteLine("q - quit");

                // get command
                Console.Write("Enter:");
                string command = Console.ReadLine();
                
                // check connection 
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong! Error:");
                    Console.WriteLine(ex.Message);
                    return;
                }

                switch (command)
                {
                    case "d":
                        // delete
                        Console.WriteLine("Enter a delete Condition:");

                        try
                        {
                            cmd.CommandText = $"DELETE FROM Item WHERE {Console.ReadLine()}";
                            cmd.ExecuteNonQuery();
                        }
                        catch(Exception ex)
                        {
                           Console.WriteLine("Deletion failed");
                           Console.WriteLine(ex.Message);
                        }
                        break;
                    case "a":
                        // Add user
                        Console.WriteLine("Enter a Item name:");
                        string itemName = Console.ReadLine();
                        long price = 0;
                        long stock = 0;
                        
                        // get stock and price value
                        do
                        {
                            try
                            {
                                
                                Console.WriteLine("Enter a price");
                                price = Int64.Parse(Console.ReadLine());
                                
                                Console.WriteLine("Enter your current stock value");
                                stock = Int64.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Wrong Format please enter integer");
                            }
                        } while (true);
                      
                        // add values to our db
                        try
                        {
                            cmd.CommandText =
                                $"INSERT INTO Item (itemname,price,stock) VALUES('{itemName}', {price}, {stock});";
                            
                            // works only on windows
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Adding your Item has failed");
                            Console.WriteLine("Error:");
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case "s":
                        // search item
                        Console.WriteLine("Enter a valid sql search without entering where, only logics");
                        cmd.CommandText = $"select * from Item where {Console.ReadLine()};";

                        try
                        {
                            reader = cmd.ExecuteReader();
                            int count = 0;
                            Console.WriteLine("========= Result: ========");
                            Console.WriteLine("Table:");
                            while (reader.Read())
                            {
                                count++;
                                Console.WriteLine(
                                    $"| {reader["ID"]} | {reader["itemname"]} | {reader["price"]} | {reader["stock"]} |");
                            }

                            Console.WriteLine($"Count: {count}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Search failed!");
                            Console.WriteLine("Error:");
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "q":
                        go = false;
                        break;
                    case "f":
                        // get full table
                        cmd.CommandText = "SELECT * FROM ITEM";

                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Console.WriteLine($"| {reader["ID"]} | {reader["itemname"]} | {reader["price"]} | {reader["stock"]} |");
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter a valid command");
                        break;
                }
            } while (go);
            
            connection.Close();
        }
    }
}