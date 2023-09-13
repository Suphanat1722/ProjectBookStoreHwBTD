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
                    "No varchar(255) PRIMARY KEY," +
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
        public static void AddData(int inputQuantity,decimal inputTotal)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Transactions (Quatity,Total_Price) VALUES (@Quatity,@Total_Price);";
                insertCommand.Parameters.AddWithValue("@Quatity", inputQuantity);
                insertCommand.Parameters.AddWithValue("@Total_Price", inputTotal);

                insertCommand.ExecuteNonQuery();

                db.Close();
            }
        }


        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ดึงข้อมูลหนังสือ-------------------------------------------------------------------------------------------

        public static List<Transaction> GetData()
        {
            List<Transaction> entries = new List<Transaction>();
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT ISBN, Customer_Id, Quatity, Total_Price FROM Transactions", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Transaction transaction = new Transaction();

                    if (!query.IsDBNull(0))
                        transaction.ISBN = query.GetInt32(0);

                    if (!query.IsDBNull(1))
                        transaction.Customer_Id = query.GetString(1);

                    if (!query.IsDBNull(2))
                        transaction.Quatity = query.GetInt32(2);

                    if (!query.IsDBNull(3))
                        transaction.Total_Price = query.GetDecimal(3);

                    entries.Add(transaction);
                }
                db.Close();
            }
            return entries;
        }

        public static void DeleteTransaction(int isbn)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;

                deleteCommand.CommandText = "DELETE FROM Transactions WHERE ISBN = @ISBN";
                deleteCommand.Parameters.AddWithValue("@ISBN",isbn);

                deleteCommand.ExecuteNonQuery();
                db.Close();
            }
        }       
    }
}
