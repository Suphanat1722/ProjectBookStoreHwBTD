using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectBookStoreHw
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            EmployeeData.InitializeEmployeeDatabase();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }

        public bool isLoggedIn = false;

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            List<Employee> employees = EmployeeData.GetData();

            // ตรวจสอบว่า Email ที่ป้อนอยู่ในฐานข้อมูลหรือไม่
            bool emailExists = false;
            foreach (var employee in employees)
            {
                if (employee.Email == email)
                {
                    emailExists = true;
                    break;
                }
            }

            if (emailExists)
            {
                bool passwordCorrect = false;
                foreach (var employee in employees)
                {
                    if (employee.Email == email && employee.Password == password)
                    {
                        passwordCorrect = true;
                        break;
                    }
                }

                if (passwordCorrect)
                {
                    isLoggedIn = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("รหัสผ่านไม่ถูกต้อง");
                }
            }
            else
            {
                MessageBox.Show("ไม่พบ Email ในระบบ");
            }
        }
    }
}
