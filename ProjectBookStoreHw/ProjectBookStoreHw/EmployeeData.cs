using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace ProjectBookStoreHw
{
    class EmployeeData
    {
        // -----------------------------------------------------------------------------------------------------------
        // สร้าง Databese ชื่อว่า Employee------------------------------------------------------------------------------------
        public static void InitializeEmployeeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();
                string tableCommand =
                "CREATE TABLE IF NOT " +
                "EXISTS Employee(" +
                    "Email varchar(255) PRIMARY KEY, " +
                    "Password varchar(255));"; 
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteNonQuery();
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ เพิ่มข้อมูลพนักงาน------------------------------------------------------------------------------------------
        public static void AddData(string inputEmail, string inputPassword)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand(
                    "INSERT INTO Employee (" +
                        "Email," +
                        "Password) " + 
                    "VALUES (" +
                        "@Email," +
                        "@Password);", db); 
                insertCommand.Parameters.AddWithValue("@Email", inputEmail);
                insertCommand.Parameters.AddWithValue("@Password", inputPassword);

                insertCommand.ExecuteNonQuery();

                db.Close();
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ดึงข้อมูลพนักงาน-------------------------------------------------------------------------------------------
        public static List<Employee> GetData()
        {
            List<Employee> entries = new List<Employee>();
            using (SqliteConnection db = new SqliteConnection($"Filename=BookStoreDatabase.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand(
                    "SELECT " +
                        "Email, " +
                        "Password " +
                    "FROM Employee", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    Employee employee = new Employee();

                    if (!query.IsDBNull(0))
                        employee.Email = query.GetString(0);

                    if (!query.IsDBNull(1))
                        employee.Password = query.GetString(1);

                    entries.Add(employee);
                }
                db.Close();
            }
            return entries;
        }
    }
}
