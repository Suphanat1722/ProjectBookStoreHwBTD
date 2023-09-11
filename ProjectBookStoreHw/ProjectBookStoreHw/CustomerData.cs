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
            using (SqliteConnection db = new SqliteConnection($"Filename=CustomerDataBase.db"))
            {
                db.Open();
                string tableCommand =
                "CREATE TABLE IF NOT " +
                "EXISTS Customers(" +
                    "Customer_Id INTEGER PRIMARY KEY, " +
                    "Customer_Name varchar(255)," +
                    "Address varchar(255)," +
                    "Email varchar(255))";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteNonQuery();
            }
        }

        public static void AddData(int inputId,string inputName, string inputAddress, string inputEmail)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=CustomerDataBase.db"))
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

        public static List<Customer> GetData()
        {
            List<Customer> entries = new List<Customer>();
            using (SqliteConnection db = new SqliteConnection($"Filename=CustomerDataBase.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT Customer_Id, Customer_Name, Address, Email FROM Customers", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Customer customer = new Customer();

                    if (!query.IsDBNull(0))
                        customer.Customer_Id = query.GetInt32(0);

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

        public static List<Customer> SearchCustomers(string keyword)
        {
            List<Customer> result = new List<Customer>();
            using (SqliteConnection db = new SqliteConnection($"Filename=CustomerDataBase.db"))
            {
                db.Open();

                SqliteCommand searchCommand = new SqliteCommand();
                searchCommand.Connection = db;

                searchCommand.CommandText = "SELECT Customer_Id, Customer_Name, Address, Email FROM Customers WHERE Customer_Id LIKE @Keyword OR Customer_Name LIKE @Keyword;";
                searchCommand.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                SqliteDataReader query = searchCommand.ExecuteReader();
                while (query.Read())
                {
                    Customer customer = new Customer();

                    if (!query.IsDBNull(0))
                        customer.Customer_Id = query.GetInt32(0);

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

        public static void UpdateCustomer(int customerId, string inputName, string inputAddress, string inputEmail)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=CustomerDataBase.db"))
            {
                db.Open();

                SqliteCommand updateCommand = new SqliteCommand();
                updateCommand.Connection = db;

                updateCommand.CommandText = "UPDATE Customers SET Customer_Name = @Customer_Name, Address = @Address, Email = @Email WHERE Customer_Id = @Customer_Id;";
                updateCommand.Parameters.AddWithValue("@Customer_Id", customerId);
                updateCommand.Parameters.AddWithValue("@Customer_Name", inputName);
                updateCommand.Parameters.AddWithValue("@Address", inputAddress);
                updateCommand.Parameters.AddWithValue("@Email", inputEmail);

                updateCommand.ExecuteNonQuery();

                db.Close();
            }
        }

        public static void DeleteCustomer(int customer_Id)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=CustomerDataBase.db"))
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
