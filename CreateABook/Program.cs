using System;

namespace CreateABook
{
    class Program
    {
        // I dette program kan du oprette bøger, redigere bøger og få dem vist i Konsol.
        static void Main(string[] args)
        {
            // Skal kunne fortryde under create mode og måske redigere en bog.

            // Console.ReadKey(true).Key == ConsoleKey.Escape

            Commands commands = new();
            commands.Start();

        }
    }
}
