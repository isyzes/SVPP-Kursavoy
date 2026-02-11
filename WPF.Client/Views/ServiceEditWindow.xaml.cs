using BLL.Models;
using System.Windows;
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
