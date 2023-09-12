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

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ กดเพื่อเพิ่มข้อมูลหนังสือ-------------------------------------------------------------------------------------
        private void ButtonAddBook_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitleBook.Text != "" && txtDescriptionBook.Text != "" && txtPriceBook.Text != "")
            {
                BookData.AddData(txtIsbn.Text,txtTitleBook.Text, txtDescriptionBook.Text, decimal.Parse(txtPriceBook.Text));

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

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ลบข้อมูลหนังสือ-------------------------------------------------------------------------------------------
        private void buttonDeleteBook_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(booksListView.SelectedItem.ToString());
            /*if (booksListView.SelectedItem is Book selectedBook)
            {
                BookData.DeleteBook(selectedBook.ISBN);

                //แสดงข้อมูลหลังการคลิกปุ่ม
                List<Book> booksForShow = BookData.GetData();
                booksListView.ItemsSource = booksForShow;
            }*/
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ค้นหาข้อมูลหนังสือ-----------------------------------------------------------------------------------------
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
                MessageBox.Show("ไม่มีข้อมูลที่คุณค้นหา");
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ เปลี่ยนข้อมูลหนังสือ------------------------------------------------------------------------------------------
        private void ButtonUpdateBook_Click(object sender, RoutedEventArgs e)
        {
            string newIsbn = txtIsbn.Text;
            string newTitle = txtTitleBook.Text;
            string newDescription = txtDescriptionBook.Text;
            decimal newPrice = decimal.Parse(txtPriceBook.Text);

            if (newIsbn != "" && newTitle != "" && newDescription != "" && newPrice.ToString() != "")
            {
                BookData.UpdateBook(newIsbn, newTitle, newDescription, newPrice);

                List<Book> booksForShow = BookData.GetData();
                booksListView.ItemsSource = booksForShow;
            }
            else
            {
                MessageBox.Show("กรอกข้อมูลไม่ครบ");
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ แสดงข้อมูลหนังสือเมื่อคลิ้กใน ListView -----------------------------------------------------------------------
        private void booksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (booksListView.SelectedItem is Book selectedBook)
            {
                // แสดงข้อมูลลูกค้าที่เลือกใน TextBox
                txtIsbn.Text = selectedBook.ISBN;
                txtTitleBook.Text = selectedBook.Title;
                txtDescriptionBook.Text = selectedBook.Description;
                txtPriceBook.Text = selectedBook.Price.ToString();
            }
        }
    }
}
