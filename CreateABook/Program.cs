﻿using System;

namespace CreateABook
{
    class Program
    {
        // I dette program kan du oprette bøger, redigere bøger og få dem vist i Konsol.
        static void Main(string[] args)
        {
            // Mangler Delete og måske Update.

            // Console.ReadKey(true).Key == ConsoleKey.Escape

            Commands commands = new();
            commands.Start();

        }
    }
}
