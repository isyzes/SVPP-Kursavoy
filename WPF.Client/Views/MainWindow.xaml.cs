using BLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xaml;
using WPF.Client.ViewModels;

namespace WPF.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        public MainWindow(MainViewModel viewModel) : this() 
        {
            this.viewModel = viewModel;
            DataContext = viewModel;
        }

        private void SearchProvider(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchProviderTextBox.Text.ToLower();
            var allProviders = viewModel.GetAllProviders();

            // Применяем текстовый поиск
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var providers = allProviders.Where(s =>
                    s.Name.ToLower().Contains(searchText) ||
                    s.Address.ToLower().Contains(searchText));

                viewModel.Providers = new ObservableCollection<Provider>(providers);
            } else
            {
                viewModel.Providers = new ObservableCollection<Provider>(allProviders);
            }
        }

        private void SearchService(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchServiceTextBox.Text.ToLower();
            var allServices = viewModel.GetServicesBySelectedProvider();

            // Применяем текстовый поиск
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var services = allServices.Where(s =>
                    s.Name.ToLower().Contains(searchText) ||
                    s.Description.ToLower().Contains(searchText));

                viewModel.Services = new ObservableCollection<Service>(services);
            }
            else
            {
                viewModel.Services = new ObservableCollection<Service>(allServices);
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}
