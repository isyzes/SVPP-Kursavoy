using BLL.Models;
using System.Windows;
using System.Windows.Media.Imaging;
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

        private void Clear_Logo_Click(object sender, RoutedEventArgs e)
        {
            logo.Source = new BitmapImage(new Uri("/images/noLogo.png", UriKind.RelativeOrAbsolute)); ;
        }

        private void Select_Image_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == false) return;
            CarentProvider.Logo = openFileDialog.FileName;
            logo.Source = new BitmapImage(new Uri(CarentProvider.Logo, UriKind.RelativeOrAbsolute));
        }
    }  
}
