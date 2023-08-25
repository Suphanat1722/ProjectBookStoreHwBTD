using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookStoreHw
{
    class BookData
    {
        public static void InitializeBookDatabase()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookDataBase.db"))
            {
                db.Open();
                string tableCommand =
                "CREATE TABLE IF NOT " +
                "EXISTS Books(" +
                    "ISBN INTEGER PRIMARY KEY, " +
                    "Title TEXT," +
                    "Description TEXT," +
                    "Price DECIMAL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddData(string inputTitle,string inputDescription,Decimal inputPrice)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookDataBase.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Books (Title, Description, Price) VALUES (@Title,@Description,@Price);";
                insertCommand.Parameters.AddWithValue("@Title", inputTitle);
                insertCommand.Parameters.AddWithValue("@Description", inputDescription);
                insertCommand.Parameters.AddWithValue("@Price",inputPrice);


                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public static List<Book> GetData()
        {
            List<Book> entries = new List<Book>();
            using (SqliteConnection db = new SqliteConnection($"Filename=BookDataBase.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT ISBN, Title, Description, Price FROM Books", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Book book = new Book();

                    if (!query.IsDBNull(0))
                        book.ISBN = query.GetInt32(0);

                    if (!query.IsDBNull(1))
                        book.Title = query.GetString(1);

                    if (!query.IsDBNull(2))
                        book.Description = query.GetString(2);

                    if (!query.IsDBNull(3))
                        book.Price = query.GetDecimal(3);

                    entries.Add(book);
                }
                db.Close();
            }
            return entries;
        }


        public static void DeleteBook(int bookISBN)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookDataBase.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;

                deleteCommand.CommandText = "DELETE FROM Books WHERE ISBN = @ISBN;";
                deleteCommand.Parameters.AddWithValue("@ISBN", bookISBN);

                deleteCommand.ExecuteNonQuery();

                db.Close();
            }
        }
    }
}
