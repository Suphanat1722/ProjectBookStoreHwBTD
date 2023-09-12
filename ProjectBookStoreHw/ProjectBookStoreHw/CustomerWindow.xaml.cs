﻿using System;
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
            List<Customer> customerForShow = CustomerData.GetData();
            customersListView.ItemsSource = customerForShow;
        }

        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (txtCustomer_Id.Text != "" && txtCustomer_Name.Text != "" && txtAddress.Text != "" && txtEmail.Text != "")
            {
                CustomerData.AddData(txtCustomer_Id.Text , txtCustomer_Name.Text, txtAddress.Text, txtEmail.Text);

                //แสดงข้อมูลหลังการคลิกปุ่ม
                List<Customer> customersForShow = CustomerData.GetData();
                customersListView.ItemsSource = customersForShow;

                //เมื่อกด Add จะ clear ข้อมูลใน textBox
                txtCustomer_Id.Text = "";
                txtCustomer_Name.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
            }
            else
            {
                MessageBox.Show(" Enter ID and Name and Address and Email ");
            }
        }

        private void ButtonSearchCustomers_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtCustomer_Id.Text;

            if (!string.IsNullOrEmpty(keyword))
            {
                List<Customer> searchResults = CustomerData.SearchCustomers(keyword);
                customersListView.ItemsSource = searchResults;
            }
            else
            {
                // ถ้าไม่มีคำค้นหาในช่องค้นหา
                MessageBox.Show("Enter a keyword to search for Customer.");
            }
        }

        private void ButtonUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (customersListView.SelectedItem is Customer selectedCustomer)
            {
                int customerId = int.Parse(selectedCustomer.Customer_Id);  // รับค่า CustomerId จากลูกค้าที่เลือก

                string newName = txtCustomer_Name.Text;
                string newAddress = txtAddress.Text;
                string newEmail = txtEmail.Text;

                CustomerData.UpdateCustomer(customerId.ToString(), newName, newAddress, newEmail);

                // แสดงข้อมูลลูกค้าหลังการอัปเดต
                List<Customer> customersForShow = CustomerData.GetData();
                customersListView.ItemsSource = customersForShow;

                // เคลียร์ข้อมูลใน TextBox
                txtCustomer_Id.Text = "";
                txtCustomer_Name.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
            }
        }

        private void buttonDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (customersListView.SelectedItem is Customer selectedCustomer)
            {
                CustomerData.DeleteCustomer(selectedCustomer.Customer_Id);

                //แสดงข้อมูลหลังการคลิกปุ่ม
                List<Customer> customersForShow = CustomerData.GetData();
                customersListView.ItemsSource = customersForShow;
            }
        }

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
