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
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Published { get; set; }
    }

    public class Books
    {
        private List<Book> book = new();

        public void CreateBook()
        {
            //string userInput;
            //string commandName = "Title: ";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Under Construction.\n");
            Console.ResetColor();

            //Book _book = new();

            //while (true)
            //{

            //    //book.Add(new Book
            //    //{
            //    //    Title = "",
            //    //    Author = "",
            //    //    Category = "",
            //    //    Published = "",
            //    //});

            //    Console.Write(commandName);
            //    userInput = Console.ReadLine();


            //    if (userInput.Length != 0)
            //    {
            //        _book.Title = userInput;

            //        Console.WriteLine(_book.Title);
            //    }

            //}
        }

        public void ShowAll()
        {
            if (book.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" There is no books to show.\n");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("-All Books-\n");

                foreach (var item in book)
                {
                    Console.WriteLine("Title: " + item.Title + "\nAuthor: " + item.Author + "\nCategory: " + item.Category + "\nPublished: " + item.Published + "\n");
                }
            }
        }
    }
}
