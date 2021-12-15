using System;
using System.Data.OleDb;

namespace UserLogin
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
                                          @"Data Source=C:\Users\ChristianLehnert\Downloads\chsharp_stuff\UserLogin\UserLogin\UserLogin.accdb";



        }
    }
}
