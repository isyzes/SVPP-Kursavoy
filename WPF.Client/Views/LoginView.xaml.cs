using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Client.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace WPF.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            bool isValid =
                (username == "admin" && password == "admin") ||
                (username == "user" && password == "user");

            if (isValid)
            {
                DialogResult = true;
            }
            else
            {
                errorMessage.Text = "Неверный логин или пароль!";
            }
        }
    }
}
