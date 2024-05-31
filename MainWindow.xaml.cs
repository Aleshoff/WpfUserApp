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
using System.Windows.Media.Animation;

namespace WpfUserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new AplicationContext();

            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 450;
            doubleAnimation.Duration = TimeSpan.FromSeconds(3);
            btnReg.BeginAnimation(Button.WidthProperty, doubleAnimation);
        }

        private void btnSignUpClick(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password1 = txtPassword1.Password.Trim();
            string password2 = txtPassword2.Password.Trim();
            string email = txtEmail.Text.Trim().ToLower();

            if(login.Length < 5)
            {
                txtLogin.ToolTip = "Login need to be longer than 5 symbols!";
                txtLogin.Background = Brushes.Red;
            } 
            else if (password1.Length < 5)
            {
                txtPassword1.ToolTip = "Password need to be longer than 5 symbols!";
                txtPassword1.Background = Brushes.Red;
            }
            else if (password1 != password2)
            {
                txtPassword2.ToolTip = "You introduced two different passwords!";
                txtPassword2.Background = Brushes.Red;
            }
            else if (email.Length < 5 ||  !email.Contains("@") || !email.Contains("."))
            {
                txtEmail.ToolTip = "Email need to be longer than 5 symbols and contains symbols @ and .!";
                txtEmail.Background = Brushes.Red;
            }
            else
            {
                txtLogin.ToolTip = "";
                txtLogin.Background = Brushes.Transparent;
                txtPassword1.ToolTip = "";
                txtPassword1.Background = Brushes.Transparent;
                txtPassword2.ToolTip = "";
                txtPassword2.Background = Brushes.Transparent;
                txtEmail.ToolTip = "";
                txtEmail.Background = Brushes.Transparent;

                MessageBox.Show("Datas was succesfully registered!");

                User user = new User(login, password1, email);
                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Hide();
            }
        }

        private void ButtonSignInClick(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }
    }
}
