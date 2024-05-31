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

namespace WpfUserApp
{
    /// <summary>
    /// Interaction logic for UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        public UserPageWindow()
        {
            InitializeComponent();

            AplicationContext db = new AplicationContext();
            List<User> users = db.Users.ToList();
            ListOfUsers.ItemsSource = users;
        }

        private void ButtonExitClick(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }

        private void btnDeleteClick(object sender, RoutedEventArgs e)
        {
            AplicationContext db = new AplicationContext();
            Console.WriteLine(ListOfUsers.SelectedItems.ToString());
           // db.Users.Remove(db.Users.Find(ListOfUsers.SelectedIndex));
        }
    }
}
