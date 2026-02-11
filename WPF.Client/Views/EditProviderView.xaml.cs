using BLL.Models;
using System.Windows;
using WPF.Client.ViewModels;

namespace WPF.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для EditProviderView.xaml
    /// </summary>
    public partial class EditProviderView : Window
    {
        private Provider _providerService;
        private bool _editMod;

        public Provider CarentProvider
        {
            get => _providerService;
            set
            {
                _providerService = value;
                // Если нужно уведомление об изменении
            }
        }

        public EditProviderView(MainViewModel viewModel, bool editMod)
        {
            InitializeComponent();
            DataContext = viewModel;
            _editMod = editMod;
            if (editMod)
            {
                _providerService = viewModel.GetProviderService();
            }
            else
            {
                _providerService = new Provider();
            }
        }
        public Provider GetCarentProvider() { return CarentProvider; }

        public bool IsEditMod() { return _editMod; }

    }  
}
