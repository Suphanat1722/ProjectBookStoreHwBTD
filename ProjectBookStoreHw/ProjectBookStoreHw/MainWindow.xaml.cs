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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectBookStoreHw
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BookData.InitializeBookDatabase();

            //แสดงข้อมูลหนังสือบน List View
            List<Book> books = BookData.GetData();
            booksListView.ItemsSource = books;

        }

        private void ButtonAddBook_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitleBook.Text != "" && txtDescriptionBook.Text != "" && txtPriceBook.Text != "")
            {
                BookData.AddData(txtTitleBook.Text, txtDescriptionBook.Text, decimal.Parse(txtPriceBook.Text));

                //แสดงข้อมูลหลังการคลิกปุ่ม
                List<Book> books = BookData.GetData();
                booksListView.ItemsSource = books; 

                //เมื่อกด Add จะ clear ข้อมูลใน textBox
                txtTitleBook.Text = "";
                txtDescriptionBook.Text = "";
                txtPriceBook.Text = "";
            }
            else
            {
                MessageBox.Show(" Enter Title and Description and Price ");
            }
            
        }

        private void buttonDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (booksListView.SelectedItem is Book selectedBook)
            {
                BookData.DeleteBook(selectedBook.ISBN);

                //แสดงข้อมูลหลังการคลิกปุ่ม
                List<Book> books = BookData.GetData();
                booksListView.ItemsSource = books;
            }
        }
    }
}
