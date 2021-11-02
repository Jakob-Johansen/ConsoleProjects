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
        List<Book> book = new();

        public void CreateBook()
        {

        }

        public void ShowAll()
        {
            if (book.Count == 0)
            {
                Console.WriteLine("Der er ikke nogen boeger at vise.");
            }
        }
    }
}
