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
            new Command() { InputCommand = "delete", Description = "Delete a book, use delete (Id)." },
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
                userCommand = Console.ReadLine();
                Console.WriteLine();

                switch (userCommand.Trim().ToLower())
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
                    case "delete":
                    break;
                    default:
                        Console.WriteLine("This command does not exists. Type help to see all commands.\n");
                    break;
                }
            }
        }
    }
}
