using BLL.Models;
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

namespace WPF.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для ServiceEditWindow.xaml
    /// </summary>
    public partial class ServiceEditWindow : Window
    {
        private Service _carentService;
        private bool _editMod;
        public Service CarentService
        {
            get => _carentService;
            set
            {
                _carentService = value;
                // Если нужно уведомление об изменении
            }
        }
        public ServiceEditWindow(MainViewModel viewModel, bool editMod)
        {
            InitializeComponent();
            DataContext = viewModel;
            _editMod = editMod;
            if (editMod)
            {
                _carentService = viewModel.GetSelectedService();
            } else
            {
                _carentService = new Service();
            }
        }

        public Service GetCarentService() { return CarentService; }

        public bool IsEditMod() { return _editMod; }


    }
}
