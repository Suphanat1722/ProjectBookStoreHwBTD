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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            EmployeeData.InitializeEmployeeDatabase();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            string inputEmail = txtEmail.Text;
            string inputPassword = txtPassword.Text;

            if (!string.IsNullOrEmpty(inputEmail) &&
                !string.IsNullOrEmpty(inputPassword))
            {
                if (inputPassword == txtComfirm_Pass.Text)
                {
                    EmployeeData.AddData(inputEmail, inputPassword);

                    MessageBox.Show("เพิ่มข้อมูลเรียบร้อย");

                    txtEmail.Clear();
                    txtPassword.Clear();

                    this.Close();
                }
                else
                {
                    MessageBox.Show(" รหัสไม่ถูกต้อง ");
                }

            }
            else
            {
                MessageBox.Show(" กรุณากรอกข้อมูลให้ครบ ");
            }
        }
    }
}
