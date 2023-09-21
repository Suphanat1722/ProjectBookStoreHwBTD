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
        LoginWindow loginWindow = new LoginWindow();

        public MainWindow()
        {
            InitializeComponent();

            loginWindow.ShowDialog();
        }

        private void ButtonToBook_Click(object sender, RoutedEventArgs e)
        {
            if (loginWindow.isLoggedIn == true)
            {
                BookWindow bookWindow = new BookWindow();
                bookWindow.Show();
            }
            else
            {
                loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            }
        }

        private void ButtonToCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (loginWindow.isLoggedIn == true)
            {
                CustomerWindow customerWindow = new CustomerWindow();
                customerWindow.Show();
            }
            else
            {
                loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            }
        }

        private void ButtonToTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (loginWindow.isLoggedIn == true)
            {
                TransactionWindow transactionWindow = new TransactionWindow();
                transactionWindow.Show();
            }
            else
            {
                loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            }
        }
    }
}
