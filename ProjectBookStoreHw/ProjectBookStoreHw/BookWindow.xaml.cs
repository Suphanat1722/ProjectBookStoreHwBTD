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
            List<Book> booksForShow = BookData.GetBooksData();
            booksListView.ItemsSource = booksForShow;

        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ กดเพื่อเพิ่มข้อมูลหนังสือ-------------------------------------------------------------------------------------
        private void ButtonAddBook_Click(object sender, RoutedEventArgs e)
        {
            string inputIsbn = txtIsbn.Text;
            string inputTitle = txtTitleBook.Text;
            string inputDescription = txtDescriptionBook.Text;
            string inputPrice = txtPriceBook.Text;

            //เช็คว่าใน TextBox ไม่ว่าง
            if (!string.IsNullOrEmpty(inputIsbn)&&
                !string.IsNullOrEmpty(inputTitle)&&
                !string.IsNullOrEmpty(inputDescription)&&
                !string.IsNullOrEmpty(inputPrice)) 
            {
                BookData.AddData(inputIsbn, inputTitle, inputDescription,decimal.Parse(inputPrice));

                //แสดงข้อมูลหลังการคลิกปุ่ม
                List<Book> booksForShow = BookData.GetBooksData();
                booksListView.ItemsSource = booksForShow;

                MessageBox.Show("เพิ่มข้อมูลเรียบร้อย");

                //เมื่อกด Add จะ clear ข้อมูลใน textBox
                txtTitleBook.Text = "";
                txtDescriptionBook.Text = "";
                txtPriceBook.Text = "";
            }
            else
            {
                MessageBox.Show(" กรุณากรอกข้อมูลให้ครบ ");
            }

        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ลบข้อมูลหนังสือ-------------------------------------------------------------------------------------------
        private void buttonDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (booksListView.SelectedItem is Book selectedBook)//เช็คว่าใน booksListView.SelectedItem เป็นข้อมูลเดียวกับ Book ไหม ถ้ามี selectedBook จะเป็น true 
            {
                BookData.DeleteBook(selectedBook.ISBN);

                //แสดงข้อมูลหลังการคลิกปุ่ม
                List<Book> booksForShow = BookData.GetBooksData();
                booksListView.ItemsSource = booksForShow;

                MessageBox.Show("ลบรายการหนังสือเรียบร้อย");
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ ค้นหาข้อมูลหนังสือ-----------------------------------------------------------------------------------------
        private void ButtonSearchBook_Click(object sender, RoutedEventArgs e)
        {
            string keyword_Isbn = txtIsbn.Text;
            string keyword_Name = txtTitleBook.Text;

            if (!string.IsNullOrEmpty(keyword_Isbn))
            {
                List<Book> searchResults = BookData.SearchBook(keyword_Isbn);
                booksListView.ItemsSource = searchResults;
            }else if (!string.IsNullOrEmpty(keyword_Name))
            {
                List<Book> searchResults = BookData.SearchBook(keyword_Name);
                booksListView.ItemsSource = searchResults;
            }
            else
            {
                MessageBox.Show("กรุณากรอก ID หรือ ชื่อหนังชื่อ ให้ถูกต้อง");
            }
        }

        // -----------------------------------------------------------------------------------------------------------
        // สำหรับ เปลี่ยนข้อมูลหนังสือ------------------------------------------------------------------------------------------
        private void ButtonUpdateBook_Click(object sender, RoutedEventArgs e)
        {
            string newTitle = txtTitleBook.Text;
            string newDescription = txtDescriptionBook.Text;
            string newPrice = txtPriceBook.Text;

            //เช็คว่าใน TextBox ต้องไม่ว่าง
            if (!string.IsNullOrEmpty(newTitle) &&
                !string.IsNullOrEmpty(newDescription) &&
                !string.IsNullOrEmpty(newPrice))
            {
                BookData.UpdateBook(newTitle, newDescription, decimal.Parse(newPrice));

                //แสดงข้อมูลหลังการคลิกปุ่ม
                List<Book> booksForShow = BookData.GetBooksData();
                booksListView.ItemsSource = booksForShow;

                MessageBox.Show("เปลี่ยนข้อมูลเรียบร้อย");
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
            if (booksListView.SelectedItem is Book selectedBook)//เช็คว่าใน booksListView.SelectedItem เป็นข้อมูลเดียวกับ Book ไหม ถ้ามี selectedBook จะเป็น true 
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
