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
        private readonly List<Book> book = new();
        DbStuff db = new();

        public void CreateBook()
        {
            string userInput;
            string commandName = "Title: ";
            bool loopCheck = true;

            Book createBook = new();

            Console.WriteLine("You are creating a new book.\n");

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
                    Console.WriteLine("Id: " + item.Id + "\nTitle: " + item.Title + "\nAuthor: " + item.Author + "\nCategory: " + item.Category + "\nPublished: " + item.Published + "\n");
                }
                Console.ResetColor();
            }
        }

        public void DeleteBook(int Id)
        {
            Console.WriteLine("The ID is: " + Id + "\n");
        }
    }
}
