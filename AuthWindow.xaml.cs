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
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void btnSignInClick(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password1 = txtPassword1.Password.Trim();


            if (login.Length < 5)
            {
                txtLogin.ToolTip = "Login need to be longer than 5 symbols!";
                txtLogin.Background = Brushes.Red;
            }
            else if (password1.Length < 5)
            {
                txtPassword1.ToolTip = "Password need to be longer than 5 symbols!";
                txtPassword1.Background = Brushes.Red;
            }

            else
            {
                txtLogin.ToolTip = "";
                txtLogin.Background = Brushes.Transparent;
                txtPassword1.ToolTip = "";
                txtPassword1.Background = Brushes.Transparent;

                User authUser = null;

                using(AplicationContext db = new AplicationContext())
                {
                    authUser = db.Users.Where(b => b.login == login && b.password == password1).FirstOrDefault();
                }

                if (authUser != null)
                {
                    MessageBox.Show("Sign In was succesfull!");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("There is no such user!");



            }
        }

        private void ButtonRegClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
