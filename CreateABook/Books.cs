using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateABook
{
    // Book class
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Published { get; set; }
    }

    public class Books
    {
        DbStuff db = new();

        public void CreateBook()
        {
            string userInput;
            string commandName = "Title: ";
            bool loopCheck = true;

            Book createBook = new();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You are creating a new book.\n");
            Console.ResetColor();

            while (loopCheck)
            {
                Console.Write(commandName);
                userInput = Console.ReadLine().Trim();

                if (userInput.Length != 0)
                {
                    if (createBook.Title == null)
                    {
                        createBook.Title = userInput;
                        commandName = "Author: ";
                    }
                    else if (createBook.Author == null)
                    {
                        createBook.Author = userInput;
                        commandName = "Category: ";
                    }
                    else if (createBook.Category == null)
                    {
                        createBook.Category = userInput;
                        commandName = "Published: ";
                    }
                    else if (createBook.Published == null)
                    {
                        createBook.Published = userInput;
                        loopCheck = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nError\n");
                        Console.ResetColor();
                        break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nField cant be empty\n");
                    Console.ResetColor();
                }
            }

            db.InsertBook(createBook);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe book has been created!\n");
            Console.ResetColor();
        }

        public void ShowAll()
        {
            var allBooks = db.GetAllBooks();

            if (allBooks.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" There is no books to show.\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-All Books-\n");

                Console.ForegroundColor = ConsoleColor.White;
                foreach (var item in allBooks)
                {
                    Console.WriteLine(
                        "Id: " + item.Id +
                        "\nTitle: " + item.Title +
                        "\nAuthor: " + item.Author +
                        "\nCategory: " + item.Category +
                        "\nPublished: " + item.Published +
                        "\n"
                        );
                }
                Console.ResetColor();
            }
        }

        public void DeleteBook(int Id)
        {
            var thisBook = db.GetBook(Id);
            string userCommand;
            bool loopCheck = true;

            if (thisBook == null || thisBook.Id == 0)   
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The book with ID: " + Id + ", doesn't exist.\n");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-THE BOOK YOU WANT TO DELETE-");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                "\n ID: " + thisBook.Id +
                "\n Title: " + thisBook.Title +
                "\n Author: " + thisBook.Author +
                "\n Category: " + thisBook.Category +
                "\n Published: " + thisBook.Published +
                "\n"
                );
            Console.ResetColor();

            while (loopCheck)
            {
                Console.Write("Are you sure you want to delete this book (Y/N): ");
                userCommand = Console.ReadLine().Trim().ToLower();

                switch (userCommand)
                {
                    case "y":
                        db.DeleteBook(Id);
                        loopCheck = false;
                    break;
                    case "n":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The book was NOT deleted.\n");
                        Console.ResetColor();
                        loopCheck = false;
                    break;
                }
            }
        }
    }
}
