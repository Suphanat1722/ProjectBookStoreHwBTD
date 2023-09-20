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
    public partial class BillWindow : Window
    {
        public BillWindow()
        {
            InitializeComponent();

            txtDate.Text = DateTime.Now.ToString("d/M/yyyy");

            //ดึงเลข ISBN ที่สั่งซื้ออล่าสุด
            List<Transaction> getIsbn = TransactionData.GetLastIsbn();
            string isbn = getIsbn[0].ISBN;

            //ดึงชื่อหนังสื้อด้วย ISBN
            List<Book> bookTitle = BookData.GetTitle(isbn);
            string title = bookTitle[0].Title;

            List<Book> bookPrice = BookData.GetPrice(isbn);
            decimal price = bookPrice[0].Price;

            List<Transaction> bookQuatity = TransactionData.GetLastIsbn();
            int quatity = bookQuatity[0].Quatity;

            decimal total = price * quatity;

            txtTitle.Text = title;
            txtPrice.Text = price.ToString();
            TxtTotal.Text = total.ToString("N2");
            txtTotalOrder.Text = total.ToString("N2");
        }

        private void buttonPrint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
