using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateABook
{

    public class Command
    {
        public string InputCommand { get; set; }
        public string Description { get; set; }
    }

    public class Commands
    {
        private readonly List<Command> command = new()
        {
            new Command() { InputCommand = "!help", Description = "Shows a list with all commands." },
            new Command() { InputCommand = "!Create", Description = "Starting create book mode."},
            new Command() { InputCommand = "!ShowAll", Description = "Shows all books."}
        };

        public void Start()
        {
            foreach (var item in command)
            {
                Console.WriteLine(" " + item.InputCommand + " - " + item.Description);
            }
        }
    }
}
