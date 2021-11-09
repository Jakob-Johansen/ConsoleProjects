using System;

namespace CreateABook
{
    class Program
    {
        // In this program you can Create, Delete and show all books, using a database.
        static void Main(string[] args)
        {
            // Skal kunne stoppe og undo under create mode og måske redigere en bog.
            // Brug async til database kald.

            // Console.ReadKey(true).Key == ConsoleKey.Escape

            Commands commands = new();
            commands.Start();

        }
    }
}
