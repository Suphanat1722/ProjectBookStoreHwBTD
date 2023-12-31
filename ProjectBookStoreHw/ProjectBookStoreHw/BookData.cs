﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBookStoreHw
{
    class BookData
    {
        // -----------------------------------------------------------------------------------------------------------
        // สร้าง Databese ชื่อว่า Books------------------------------------------------------------------------------------
        public static void InitializeBookDatabase()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();
                string tableCommand =
                "CREATE TABLE IF NOT " +
                "EXISTS Books(" +
                    "ISBN varchar(255) PRIMARY KEY, " +
                    "Title varchar(255)," +
                    "Description varchar(255)," +
                    "Price DECIMAL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteNonQuery();
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ เพิ่มข้อมูลหนังสือ------------------------------------------------------------------------------------------
        public static void AddData(string inputIsbn,string inputTitle,string inputDescription,Decimal inputPrice)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand(
                    "INSERT INTO Books (" +
                        "ISBN," +
                        "Title, " +
                        "Description, " +
                        "Price) " +
                    "VALUES (" +
                        "@ISBN," +
                        "@Title," +
                        "@Description," +
                        "@Price);", db);
                insertCommand.Parameters.AddWithValue("@ISBN", inputIsbn);
                insertCommand.Parameters.AddWithValue("@Title", inputTitle);
                insertCommand.Parameters.AddWithValue("@Description", inputDescription);
                insertCommand.Parameters.AddWithValue("@Price",inputPrice);

                insertCommand.ExecuteNonQuery();
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ดึงข้อมูลหนังสือ-------------------------------------------------------------------------------------------
        public static List<Book> GetBooksData()
        {
            List<Book> entries = new List<Book>();
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand(
                    "SELECT " +
                        "ISBN, " +
                        "Title, " +
                        "Description, " +
                        "Price " +
                    "FROM Books", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Book book = new Book();

                    if (!query.IsDBNull(0))
                        book.ISBN = query.GetString(0);

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

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ค้นหาข้อมูลหนังสือ-----------------------------------------------------------------------------------------
        public static List<Book> SearchBook(string InputKeyword)
        {
            List<Book> entries = new List<Book>();
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand searchCommand = new SqliteCommand(
                    "SELECT " +
                        "ISBN, " +
                        "Title, " +
                        "Description, " +
                        "Price " +
                    "FROM Books " +
                    "WHERE ISBN LIKE @Keyword " +
                    "OR Title LIKE @Keyword;", db);
                searchCommand.Parameters.AddWithValue("@Keyword",InputKeyword);

                SqliteDataReader query = searchCommand.ExecuteReader();
                while (query.Read())
                {
                    Book book = new Book();

                    if (!query.IsDBNull(0))
                        book.ISBN = query.GetString(0);

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

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ แก้ไขข้อมูลหนังสือ-----------------------------------------------------------------------------------------
        public static void UpdateBook(string inputIsbn,string newTitle, string newDescription, decimal newPrice)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand updateCommand = new SqliteCommand(
                    "UPDATE Books SET " +
                        "Title = @Title, " +
                        "Description = @Description, " +
                        "Price = @Price " +
                    "WHERE ISBN = @ISBN;", db);
                updateCommand.Parameters.AddWithValue("@ISBN", inputIsbn);
                updateCommand.Parameters.AddWithValue("@Title", newTitle);
                updateCommand.Parameters.AddWithValue("@Description", newDescription);
                updateCommand.Parameters.AddWithValue("@Price", newPrice);

                updateCommand.ExecuteNonQuery();

                db.Close();
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ลบข้อมูลหนังสือ-------------------------------------------------------------------------------------------
        public static void DeleteBook(string bookISBN)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand(
                    "DELETE FROM Books " +
                    "WHERE ISBN = @ISBN;", db);
                deleteCommand.Parameters.AddWithValue("@ISBN", bookISBN);

                deleteCommand.ExecuteNonQuery();

                db.Close();
            }
        }


        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ดึงข้อมูลหนังสือด้วย ISBN-----------------------------------------------------------------------------------
        public static List<Book> GetBookByISBN(string inputIsbn)
        {
            List<Book> entries = new List<Book>();
            using (SqliteConnection db = new SqliteConnection($"Filename = BookStoreDatabase.db"))
            {
                db.Open();
                
                SqliteCommand selectCommand = new SqliteCommand(
                    "SELECT  " +
                        "ISBN, " +
                        "Title, " +
                        "Description, " +
                        "Price " +
                    "FROM Books " +
                    "WHERE ISBN = @ISBN", db);
                selectCommand.Parameters.AddWithValue("@ISBN", inputIsbn);

                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Book book = new Book();

                    if (!query.IsDBNull(0))
                        book.ISBN = query.GetString(0);

                    if (!query.IsDBNull(1))
                        book.Title = query.GetString(1);

                    if (!query.IsDBNull(2))
                        book.Description = query.GetString(2);

                    if (!query.IsDBNull(3))
                        book.Price = query.GetDecimal(3);

                    entries.Add(book);
                    
                }
                db.Close();
                return entries;
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ดึงราคาหนังสือด้วยเลข ISBN---------------------------------------------------------------------------------
        public static List<Book> GetPrice(string InputIsbn)
        {
            List<Book> entries = new List<Book>();
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();
                // ใช้พารามิเตอร์ @isbn ใน SQL และกำหนดค่าตรงกับพารามิเตอร์
                SqliteCommand selectCommand = new SqliteCommand("" +
                    "SELECT Price " +
                    "FROM Books " +
                    "WHERE ISBN = @ISBN", db);
                selectCommand.Parameters.AddWithValue("@ISBN", InputIsbn);

                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Book book = new Book();
                    book.Price = query.GetDecimal(0);
                    entries.Add(book);
                }
                db.Close();
            }
            return entries;
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ดึงชื่อหนังสือด้วยเลข ISBN---------------------------------------------------------------------------------
        public static List<Book> GetTitle(string InputIsbn)
        {
            List<Book> entries = new List<Book>();
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();
                // ใช้พารามิเตอร์ @isbn ใน SQL และกำหนดค่าตรงกับพารามิเตอร์
                SqliteCommand selectCommand = new SqliteCommand("" +
                    "SELECT Title " +
                    "FROM Books " +
                    "WHERE ISBN = @ISBN", db);
                selectCommand.Parameters.AddWithValue("@ISBN", InputIsbn);

                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Book book = new Book();
                    book.Title = query.GetString(0);
                    entries.Add(book);
                }
                db.Close();
            }
            return entries;
        }
    }
}
