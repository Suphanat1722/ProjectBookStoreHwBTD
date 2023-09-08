using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ProjectBookStoreHw
{
    class CustomerData
    {
        public static void InitializeCustomerDatabase()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=Customerdatabase.db"))
            {
                db.Open();
                string tableCommand =
                "CREATE TABLE IF NOT " +
                "EXISTS Customers(" +
                    "Customer_Id INTEGER PRIMARY KEY, " +
                    "Customer_Name TEXT, " +
                    "Address TEXT, " +
                    "Email TEXT)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddData()
        {

        }
    }
}
