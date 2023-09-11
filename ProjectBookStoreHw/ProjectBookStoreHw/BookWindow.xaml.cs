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
    public partial class BookWindow : Window
    {
        public BookWindow()
        {
            InitializeComponent();
            BookData.InitializeBookDatabase();

            //แสดงข้อมูลหนังสือบน List View
            List<Book> booksForShow = BookData.GetData();
            booksListView.ItemsSource = booksForShow;

        }

        private void ButtonAddBook_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitleBook.Text != "" && txtDescriptionBook.Text != "" && txtPriceBook.Text != "")
            {
                BookData.AddData(txtTitleBook.Text, txtDescriptionBook.Text, decimal.Parse(txtPriceBook.Text));

                //แสดงข้อมูลหลังการคลิกปุ่ม
                List<Book> booksForShow = BookData.GetData();
                booksListView.ItemsSource = booksForShow;

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
                List<Book> booksForShow = BookData.GetData();
                booksListView.ItemsSource = booksForShow;
            }
        }

        private void ButtonSearchBook_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtTitleBook.Text;

            if (!string.IsNullOrEmpty(keyword))
            {
                List<Book> searchResults = BookData.SearchBooks(keyword);
                booksListView.ItemsSource = searchResults;
            }
            else
            {
                // ถ้าไม่มีคำค้นหาในช่องค้นหา
                MessageBox.Show("Enter a keyword to search for books.");
            }
        }

        private void ButtonUpdateBook_Click(object sender, RoutedEventArgs e)
        {
            if (booksListView.SelectedItem is Book selectedBook)
            {
                string newTitle = txtTitleBook.Text;
                string newDescription = txtDescriptionBook.Text;
                decimal newPrice;

                if (decimal.TryParse(txtPriceBook.Text, out newPrice))
                {
                    BookData.UpdateBook(selectedBook.ISBN, newTitle, newDescription, newPrice);

                    // แสดงข้อมูลหลังการอัปเดต
                    List<Book> booksForShow = BookData.GetData();
                    booksListView.ItemsSource = booksForShow;

                    // เคลียร์ข้อมูลใน TextBox
                    txtTitleBook.Text = "";
                    txtDescriptionBook.Text = "";
                    txtPriceBook.Text = "";
                }
                else
                {
                    MessageBox.Show("Enter a valid price.");
                }
            }
        }

        private void booksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (booksListView.SelectedItem is Book selectedBook)
            {
                // แสดงข้อมูลลูกค้าที่เลือกใน TextBox
                txtTitleBook.Text = selectedBook.Title;
                txtDescriptionBook.Text = selectedBook.Description;
                txtPriceBook.Text = selectedBook.Price.ToString();
            }
        }
    }
}
