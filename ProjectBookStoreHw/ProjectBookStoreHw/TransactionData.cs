using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ProjectBookStoreHw
{
    class TransactionData
    {
        // -----------------------------------------------------------------------------------------------------------
        // สร้าง Databese ชื่อว่า Transactions-----------------------------------------------------------------------------
        public static void InitializeTransactionDatabase()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();
                string tableCommand =
                "CREATE TABLE IF NOT " +
                "EXISTS Transactions(" +
                    "No INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "ISBN varchar(255)," + 
                    "Customer_Id varchar(255)," +
                    "Quatity INTEGER," + 
                    "Total_Price DECIMAL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteNonQuery();
            }
        }


        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ เพิ่มข้อมูลการซื้อหนังสือ-------------------------------------------------------------------------------------
        public static void AddTransactionData(string inputIsbn, string inputCus_Id, int inputQuantity, decimal inputTotal)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand("" +
                    "INSERT INTO Transactions " +
                        "(ISBN," +
                        "Customer_Id," +
                        "Quatity," +
                        "Total_Price) " +
                    "VALUES " +
                        "(@ISBN," +
                        "@Customer_Id," +
                        "@Quatity," +
                        "@Total_Price);", db);
                insertCommand.Parameters.AddWithValue("@ISBN", inputIsbn);
                insertCommand.Parameters.AddWithValue("@Customer_Id", inputCus_Id);
                insertCommand.Parameters.AddWithValue("@Quatity", inputQuantity);
                insertCommand.Parameters.AddWithValue("@Total_Price", inputTotal);

                insertCommand.ExecuteNonQuery();

                db.Close();
            }
        }


        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ดึงข้อมูลหนังสือ-------------------------------------------------------------------------------------------

        public static List<Transaction> GetTransactionData()
        {
            List<Transaction> entries = new List<Transaction>();
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand(
                    "SELECT " +
                        "No," +
                        "ISBN, " +
                        "Customer_Id, " +
                        "Quatity, " +
                        "Total_Price " +
                    "FROM Transactions", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Transaction transaction = new Transaction();

                    if (!query.IsDBNull(0))
                        transaction.No = query.GetInt32(0);

                    if (!query.IsDBNull(1))
                        transaction.ISBN = query.GetString(1);

                    if (!query.IsDBNull(2))
                        transaction.Customer_Id = query.GetString(2);

                    if (!query.IsDBNull(3))
                        transaction.Quatity = query.GetInt32(3);

                    if (!query.IsDBNull(4))
                        transaction.Total_Price = query.GetDecimal(4);

                    entries.Add(transaction);
                }
                db.Close();
            }
            return entries;
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ดึงข้อมูลหนังสือ-------------------------------------------------------------------------------------------

        public static List<Transaction> GetTotal_Price(string inputIsbn)
        {
            List<Transaction> entries = new List<Transaction>();
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand(
                    "SELECT Total_Price " +
                    "FROM Transactions " +
                    "WHERE ISBN = @ISBN", db);
                selectCommand.Parameters.AddWithValue("@ISBN", inputIsbn);

                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Transaction transaction = new Transaction();

                    if (!query.IsDBNull(0))
                        transaction.Total_Price = query.GetDecimal(0);

                    entries.Add(transaction);
                }
                db.Close();
            }
            return entries;
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับลบเพื่อเทสระบบ-------------------------------------------------------------------------------------
        public static void DeleteTransaction(int inputNo)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;

                deleteCommand.CommandText = "DELETE FROM Transactions WHERE No = @No";
                deleteCommand.Parameters.AddWithValue("@No", inputNo);

                deleteCommand.ExecuteNonQuery();
                db.Close();
            }
        }      
    }
}
