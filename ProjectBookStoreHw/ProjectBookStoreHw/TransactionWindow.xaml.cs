using Microsoft.Data.Sqlite;
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
    /// Interaction logic for TransactionWindow.xaml
    /// </summary>
    public partial class TransactionWindow : Window
    {
        public TransactionWindow()
        {
            InitializeComponent();
            TransactionData.InitializeTransactionDatabase();
            List<Transaction> transactionForShow = TransactionData.GetTransactionData();
            testListView.ItemsSource = transactionForShow;        
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ เพิ่มข้อมูลการซื้อหนังสือ-------------------------------------------------------------------------------------
        private void txtISBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Book> books = BookData.GetBooksByISBN(txtISBN.Text);
            transactionListView.ItemsSource = books;
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ เพิ่มข้อมูลการซื้อหนังสือ-------------------------------------------------------------------------------------
        private void buttonApply_Click_1(object sender, RoutedEventArgs e)
        {
            string inputIsbn = txtISBN.Text;
            string inputCus_Id = txtCus_Id.Text;
            string inputQuatity = txtQuatity.Text;

            // คำนวณผลรวมราคาหนังสือ
            List<Book> bookPricesList = BookData.GetPrice(inputIsbn);
            decimal bookPrices = bookPricesList[0].Price;
            decimal Total_Price = bookPrices * decimal.Parse(inputQuatity); 

            //เช็คว่า textBox ต้องไม่ว่าง 
            if (!string.IsNullOrEmpty(inputIsbn) &&
                !string.IsNullOrEmpty(inputCus_Id) &&
                !string.IsNullOrEmpty(inputQuatity))
            {
               TransactionData.AddTransactionData(inputIsbn, inputCus_Id,int.Parse(inputQuatity), Total_Price);
               MessageBox.Show("บันทึกการสั่งซื้อเรียบร้อย");
            }
            

            List<Transaction> transactionForShow = TransactionData.GetTransactionData();
            testListView.ItemsSource = transactionForShow;
        }

        // -----------------------------------------------------------------------------------------------------------
        // ปุ่มลบสำหรับเทสระบบ-------------------------------------------------------------------------------------------
        /*private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (testListView.SelectedItem is Transaction selectedTransaction)
            {
                TransactionData.DeleteTransaction(selectedTransaction.No); // เปลี่ยนให้ใช้ No แทน ISBN

                List<Transaction> transactionForShow = TransactionData.GetTransactionData();
                testListView.ItemsSource = transactionForShow;
            }
        }*/

    }
}
