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

            SqlCommand sqlCommand = new(queryString, connection);
            sqlCommand.Parameters.AddWithValue("@Title", book.Title);
            sqlCommand.Parameters.AddWithValue("@Author", book.Author);
            sqlCommand.Parameters.AddWithValue("@Category", book.Category);
            sqlCommand.Parameters.AddWithValue("@Published", book.Published);

            try
            {
                sqlCommand.Connection.Open();
            }
            catch (Exception ex)
            {

                Console.WriteLine("\n" + ex.Message + "\n");
                return;
            }

            sqlCommand.Connection.Close();
        }
    }
}
