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
        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ สร้าง Databese ชื่อว่า Customers--------------------------------------------------------------------------
        public static void InitializeCustomerDatabase()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();
                string tableCommand =
                "CREATE TABLE IF NOT " +
                "EXISTS Customers(" +
                    "Customer_Id varchar(255) PRIMARY KEY, " +
                    "Customer_Name varchar(255)," +
                    "Address varchar(255)," +
                    "Email varchar(255))";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteNonQuery();
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ เพิ่มข้อมูลลูกค้า-------------------------------------------------------------------------------------------
        public static void AddData(string inputId,string inputName, string inputAddress, string inputEmail)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Customers (Customer_Id,Customer_Name, Address, Email) VALUES (@Customer_Id,@Customer_Name,@Address,@Email);";
                insertCommand.Parameters.AddWithValue("@Customer_Id", inputId);
                insertCommand.Parameters.AddWithValue("@Customer_Name", inputName);
                insertCommand.Parameters.AddWithValue("@Address", inputAddress);
                insertCommand.Parameters.AddWithValue("@Email", inputEmail);


                insertCommand.ExecuteNonQuery();

                db.Close();
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ดึงข้อมูลลูกค้า--------------------------------------------------------------------------------------------
        public static List<Customer> GetDataCustomers()
        {
            List<Customer> entries = new List<Customer>();
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT Customer_Id, Customer_Name, Address, Email FROM Customers", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Customer customer = new Customer();

                    if (!query.IsDBNull(0))
                        customer.Customer_Id = query.GetString(0);

                    if (!query.IsDBNull(1))
                        customer.Customer_Name = query.GetString(1);

                    if (!query.IsDBNull(2))
                        customer.Address = query.GetString(2);

                    if (!query.IsDBNull(3))
                        customer.Email = query.GetString(3);

                    entries.Add(customer);
                }
                db.Close();
            }
            return entries;
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ค้นหารายการลูกค้า----------------------------------------------------------------------------------------
        public static List<Customer> SearchCustomer(string keyword)
        {
            List<Customer> result = new List<Customer>();
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand searchCommand = new SqliteCommand();
                searchCommand.Connection = db;

                searchCommand.CommandText = "SELECT Customer_Id, Customer_Name, Address, Email " +
                                            "FROM Customers " +
                                            "WHERE Customer_Id LIKE @Keyword " +
                                            "OR Customer_Name LIKE @Keyword;";

                searchCommand.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                SqliteDataReader query = searchCommand.ExecuteReader();
                while (query.Read())
                {
                    Customer customer = new Customer();

                    if (!query.IsDBNull(0))
                        customer.Customer_Id = query.GetString(0);

                    if (!query.IsDBNull(1))
                        customer.Customer_Name = query.GetString(1);

                    if (!query.IsDBNull(2))
                        customer.Address = query.GetString(2);

                    if (!query.IsDBNull(3))
                        customer.Email = query.GetString(3);

                    result.Add(customer);
                }
                db.Close();
            }
            return result;
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ แก้ไขข้อมูลลูกค้า------------------------------------------------------------------------------------------
        public static void UpdateCustomer(string inputCus_Id,string newName, string newAddress, string newEmail)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand updateCommand = new SqliteCommand();
                updateCommand.Connection = db;

                updateCommand.CommandText = "UPDATE Customers SET " +
                            "Customer_Name = @Customer_Name," +
                            "Address = @Address," +
                            "Email = @Email " +
                            "WHERE Customer_Id = @Customer_Id;";

                updateCommand.Parameters.AddWithValue("@Customer_Id", inputCus_Id);
                updateCommand.Parameters.AddWithValue("@Customer_Name", newName);
                updateCommand.Parameters.AddWithValue("@Address", newAddress);
                updateCommand.Parameters.AddWithValue("@Email", newEmail);

                updateCommand.ExecuteNonQuery();

                db.Close();
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ลบรายการลุกค้า------------------------------------------------------------------------------------------
        public static void DeleteCustomer(string customer_Id)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand deleteCommand = new SqliteCommand();
                deleteCommand.Connection = db;

                deleteCommand.CommandText = "DELETE FROM Customers WHERE Customer_Id = @Customer_Id;";
                deleteCommand.Parameters.AddWithValue("@Customer_Id", customer_Id);

                deleteCommand.ExecuteNonQuery();

                db.Close();
            }
        }
    }
}
