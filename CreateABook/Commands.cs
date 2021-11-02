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
        // List with all commands.
        private readonly List<Command> command = new()
        {
            new Command() { InputCommand = "!help", Description = "Shows a list with all commands." },
            new Command() { InputCommand = "!Create", Description = "Starting create book mode."},
            new Command() { InputCommand = "!ShowAll", Description = "Shows all books."}
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

        // The method that runs when the program starts.
        public void Start()
        {
            while (true)
            {
                ShowCommands();
                Console.Write("Command: ");
                Console.ReadLine();
                Console.WriteLine();
            }
        }
    }
}
