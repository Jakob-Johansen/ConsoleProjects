using System;

namespace CreateABook
{
    class Program
    {
        // In this program you can Create, Delete and show all books, using a database.
        static void Main(string[] args)
        {
            Commands commands = new();
            commands.Start();
        }
    }
}
