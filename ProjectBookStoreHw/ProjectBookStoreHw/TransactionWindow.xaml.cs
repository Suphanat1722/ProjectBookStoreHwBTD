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
            List<Transaction> transactionForShow = TransactionData.GetData();
            testListView.ItemsSource = transactionForShow;
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ เพิ่มข้อมูลการซื้อหนังสือ-------------------------------------------------------------------------------------
        private void txtISBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(txtISBN.Text, out int isbn))
            {
                List<Book> books = BookData.GetBooksByISBN(isbn);
                transactionListView.ItemsSource = books;
            }
            else
            {
                // หากผู้ใช้ป้อนข้อมูลไม่ถูกต้องหรือว่างเปล่า คุณสามารถเคลียร์รายการหนังสือ
                transactionListView.ItemsSource = null;
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ เพิ่มข้อมูลการซื้อหนังสือ-------------------------------------------------------------------------------------
        private void buttonApply_Click_1(object sender, RoutedEventArgs e)
        {
            List<Book> selectedBooks = BookData.GetPrice(int.Parse(txtISBN.Text));

            // ตรวจสอบว่ามีหนังสือที่ถูกเลือกหรือไม่
            if (selectedBooks.Count > 0)
            {
                // เลือกหนังสือแรก (หรือหนังสือที่คุณต้องการ) เพื่อนำมาคำนวณ
                Book selectedBook = selectedBooks[0];

                // ทำการคำนวณราคาจากจำนวนหนังสือที่ซื้อ
                decimal totalPrice = Decimal.Parse(txtNumOfBooks.Text) * selectedBook.Price;

                // เรียก TransactionData.AddData ด้วยราคาที่คำนวณได้
                TransactionData.AddData(int.Parse(txtNumOfBooks.Text), totalPrice);

                // แสดงข้อมูลหลังการคลิกปุ่ม
                List<Transaction> transactionsForShow = TransactionData.GetData();
                testListView.ItemsSource = transactionsForShow;
            }

            else
            {
                MessageBox.Show(" Enter ");
            }
        }


        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ เพิ่มข้อมูลการซื้อหนังสือ-------------------------------------------------------------------------------------
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (testListView.SelectedItem is Transaction selectedBook)
            {
                TransactionData.DeleteTransaction(selectedBook.ISBN);

                List<Transaction> transactionForShow = TransactionData.GetData();
                testListView.ItemsSource = transactionForShow;
            }
        }
    }
}
