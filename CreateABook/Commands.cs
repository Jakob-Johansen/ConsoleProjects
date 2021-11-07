using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateABook
{
    // Command class
    public class Command
    {
        public string InputCommand { get; set; }
        public string Description { get; set; }
    }

    public class Commands
    {
        Books books = new();

        // List with all commands.
        private readonly List<Command> command = new()
        {
            new Command() { InputCommand = "help", Description = "Shows a list with all commands." },
            new Command() { InputCommand = "create", Description = "Starting create book mode."},
            new Command() { InputCommand = "showall", Description = "Shows all books."},
            new Command() { InputCommand = "delete", Description = "Delete a book, use delete (ID)." },
            new Command() { InputCommand = "clear", Description = "Clears the console"}
        };

        // A method that print out all the commands.
        public void ShowCommands()
        {
            Console.WriteLine("List of all commands:");
            foreach (var item in command)
            {
                Console.WriteLine(" " + item.InputCommand + " - " + item.Description);
            }
            Console.WriteLine("");
        }

        // A method that runs when the program starts.
        public void Start()
        {
            string userCommand;

            //ShowCommands();

            while (true)
            {
                Console.Write("Command: ");
                userCommand = Console.ReadLine().Trim().ToLower();
                Console.WriteLine();

                switch (userCommand)
                {
                    case "help":
                        ShowCommands();
                    break;
                    case "create":
                        books.CreateBook();
                    break;
                    case "showall":
                        books.ShowAll();
                    break;
                    case "clear":
                        Console.Clear();
                    break;
                    default:

                        // Creates an array that contains the user input and splits the user input.  
                        string[] userCommandSplit = userCommand.Split(' ');

                        // Checks if the array contains 2 strings and then checks if the first string in the array is == "delete" string.
                        if (userCommandSplit.Length == 2 && userCommandSplit[0] == "delete")
                        {
                            // Creates a bool that is true if second string in the array can parse to an int
                            // and then creates an int with the parsed string.
                            bool intCheck = int.TryParse(userCommandSplit[1], out int bookId);

                            // if true
                            if (intCheck)
                            {
                                books.DeleteBook(bookId);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("The ID need to be a number.\n");
                                Console.ResetColor();
                            }
                            break;
                        }

                        Console.WriteLine("This command does not exists. Type help to see all commands.\n");
                    break;
                }
            }
        }
    }
}
