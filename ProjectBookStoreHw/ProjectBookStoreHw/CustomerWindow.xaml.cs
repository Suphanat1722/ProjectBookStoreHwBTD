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
    public partial class CustomerWindow : Window
    {
        public CustomerWindow()
        {
            InitializeComponent();
            CustomerData.InitializeCustomerDatabase();

            //แสดงข้อมูลหนังสือบน List View
            List<Customer> customerForShow = CustomerData.GetDataCustomers();
            customersListView.ItemsSource = customerForShow;

        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ กดเพื่อเพิ่มข้อมูลลูกค้า--------------------------------------------------------------------------------------
        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            string inputCus_Id = txtCustomer_Id.Text;
            string inputCus_Name = txtCustomer_Name.Text;
            string inputAddress = txtAddress.Text;
            string inputEmail = txtEmail.Text;

            //เช็คว่าใน textBox ต้องไม่ว่าง
            if (!string.IsNullOrEmpty(inputCus_Id)&&
                !string.IsNullOrEmpty(inputCus_Name)&&
                !string.IsNullOrEmpty(inputAddress)&&
                !string.IsNullOrEmpty(inputEmail))
            {
                CustomerData.AddData(inputCus_Id, inputCus_Name, inputAddress, inputEmail);

                //แสดงข้อมูลหลังการคลิกปุ่ม
                List<Customer> customersForShow = CustomerData.GetDataCustomers();
                customersListView.ItemsSource = customersForShow;

                //เมื่อกด Add จะ clear ข้อมูลใน textBox
                txtCustomer_Id.Text = "";
                txtCustomer_Name.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ ");
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ กดเพื่อค้นหาข้อมูลลูกค้า-------------------------------------------------------------------------------------
        private void ButtonSearchCustomers_Click(object sender, RoutedEventArgs e)
        {
            string keyword_Id = txtCustomer_Id.Text;
            string keyword_Name = txtCustomer_Name.Text;

            if (!string.IsNullOrEmpty(keyword_Id))
            {
                List<Customer> searchResults = CustomerData.SearchCustomer(keyword_Id);
                customersListView.ItemsSource = searchResults;
            }
            else if (!string.IsNullOrEmpty(keyword_Name))
            {
                List<Customer> searchResults = CustomerData.SearchCustomer(keyword_Name);
                customersListView.ItemsSource = searchResults;
            }
            else
            {
                // ถ้าไม่มีคำค้นหาในช่องค้นหา
                MessageBox.Show("กรุณากรอก ID หรือชื่อลูกค้า");
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ กดเพื่อแก้ไขข้อมูลลูกค้า--------------------------------------------------------------------------------------
        private void ButtonUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            string inputCus_Id = txtCustomer_Id.Text;
            string newName = txtCustomer_Name.Text;
            string newAddress = txtAddress.Text;
            string newEmail = txtEmail.Text;

            if (!string.IsNullOrEmpty(inputCus_Id) &&
                !string.IsNullOrEmpty(newName) &&
                !string.IsNullOrEmpty(newAddress) &&
                !string.IsNullOrEmpty(newEmail))
            {                
                CustomerData.UpdateCustomer(inputCus_Id,newName, newAddress, newEmail);

                MessageBox.Show("แก้ไขข้อมูลสำเร็จ");

                // แสดงข้อมูลลูกค้าหลังการอัปเดต
                List<Customer> customersForShow = CustomerData.GetDataCustomers();
                customersListView.ItemsSource = customersForShow;

                // เคลียร์ข้อมูลใน TextBox
                txtCustomer_Id.Text = "";
                txtCustomer_Name.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
            }
            else
            {
                MessageBox.Show("กรุณ่กรอกข้อมูลให้ครบ");
            }

        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ กดเพื่อลบรายการลูกค้า--------------------------------------------------------------------------------------
        private void buttonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (customersListView.SelectedItem is Customer selectedCustomer)
            {
                CustomerData.DeleteCustomer(selectedCustomer.Customer_Id);

                MessageBox.Show("ลบรายการสำเร็จ");

                //แสดงข้อมูลหลังการคลิกปุ่ม
                List<Customer> customersForShow = CustomerData.GetDataCustomers();
                customersListView.ItemsSource = customersForShow;
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ กด ListView เพื่อแสดงข้อมูลลูกค้าใน Text Box-----------------------------------------------------------------
        private void customersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (customersListView.SelectedItem is Customer selectedCustomer)
            {
                // แสดงข้อมูลลูกค้าที่เลือกใน TextBox
                txtCustomer_Id.Text = selectedCustomer.Customer_Id.ToString();
                txtCustomer_Name.Text = selectedCustomer.Customer_Name;
                txtAddress.Text = selectedCustomer.Address;
                txtEmail.Text = selectedCustomer.Email;
            }
        }
    }
}
