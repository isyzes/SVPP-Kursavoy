using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using BLL.Models;

namespace WPF.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private readonly CurrentUser _currentUser;
        public LoginView(CurrentUser currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
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
                _currentUser.Login = username;
                _currentUser.Role = username;
                DialogResult = true;
            }
            else
            {
                errorMessage.Text = "Неверный логин или пароль!";
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
