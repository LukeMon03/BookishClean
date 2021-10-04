using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Bookish.Net
{
    public class BookRepository
    {
        public string connectionString = @"Server=localhost;Database=bookish_dataBase;Trusted_Connection=True;";
        public IEnumerable<Book> GetAllBooks()
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            // sort in to aplha
            return Connection.Query<Book>("SELECT * FROM Books").OrderBy(book => book.BookName);
        }
        public IEnumerable<Copy> GetAllUserCopies(int UserID)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            return Connection.Query<Copy>($"SELECT * FROM Copies WHERE UserID = {UserID}");
        }
        public IEnumerable<Book> SearchForBooks(string SearchText)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            
            return Connection.Query<Book>($"SELECT * FROM Books WHERE BookName LIKE '%{SearchText}%' OR Author LIKE '%{SearchText}%'");
        }
        
        //AHH do this
        public IEnumerable<Copy> AllCopies(int BookID)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            // find out how many copies
            // number of copies without a userID
            // copies with a user ID, get date due to return and username
            return Connection.Query<Copy>($"SELECT * FROM Copies WHERE BookID = {BookID}");
        }



        public int AddBook(string BookName, string ISBN, string Author)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            // add barcode
            return Connection.QuerySingle<int>($"INSERT INTO Books(BookName, Author, ISBN) VALUES('{BookName}', '{Author}', '{ISBN}'); SELECT SCOPE_IDENTITY()");
            
        }
        
    }
}


