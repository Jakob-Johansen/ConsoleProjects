using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateABook
{
    public class DbStuff
    {
        private readonly string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CreateABook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void InsertBook(Book book)
        {
            if (book == null)
            {
                return;
            }

            string queryString = "INSERT INTO dbo.Book (Title, Author, Category, Published) VALUES (@Title, @Author, @Category, @Published)";

            using SqlConnection connection = new(connString);
            using SqlCommand sqlCommand = new(queryString, connection);

            sqlCommand.Parameters.AddWithValue("@Title", book.Title);
            sqlCommand.Parameters.AddWithValue("@Author", book.Author);
            sqlCommand.Parameters.AddWithValue("@Category", book.Category);
            sqlCommand.Parameters.AddWithValue("@Published", book.Published);

            try
            {
                connection.Open();
                if (sqlCommand.ExecuteNonQuery() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nError inserting data into Database.\n");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + ex.Message + "\n");
                Console.ResetColor();
            }
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new();

            string queryString = "SELECT * FROM dbo.Book";

            using SqlConnection connection = new(connString);
            using SqlCommand sqlCommand = new(queryString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Book book = new();

                    book.Id = (int)reader["Id"];
                    book.Title = reader["Title"].ToString();
                    book.Author = reader["Author"].ToString();
                    book.Category = reader["Category"].ToString();
                    book.Published = reader["Published"].ToString();

                    books.Add(book);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + ex.Message + "\n");
                Console.ResetColor();
            }
            return books;
        }

        public Book GetBook(int Id)
        {
            Book book = new();

            string queryString = "SELECT * FROM dbo.Book WHERE ID=@Id";

           using SqlConnection connection = new(connString);
           using SqlCommand sqlCommand = new(queryString, connection);

            sqlCommand.Parameters.AddWithValue("@Id", Id);

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    book.Id = (int)reader["Id"];
                    book.Title = reader["Title"].ToString();
                    book.Author = reader["Author"].ToString();
                    book.Category = reader["Category"].ToString();
                    book.Published = reader["Published"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + ex.Message + "\n");
                Console.ResetColor();
            }

            return book;
        }

        public void DeleteBook(int Id)
        {
            string queryString = "DELETE FROM dbo.Book WHERE Id=@Id";

            using SqlConnection connection = new(connString);
            using SqlCommand sqlCommand = new(queryString, connection);

            sqlCommand.Parameters.AddWithValue("@Id", Id);

            try
            {
                connection.Open();
                sqlCommand.ExecuteNonQuery();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The book was deleted.\n");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + ex.Message + "\n");
                Console.ResetColor();
            }
        }
    }
}
