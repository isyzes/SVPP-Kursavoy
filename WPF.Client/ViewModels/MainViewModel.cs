using BLL.Models;
using BLL.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WPF.Client.Views;

namespace WPF.Client.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IProviderService _providerService;
        private readonly IServiceService _serviceService;

        private ObservableCollection<Provider> _providers;
        private Provider _selectedProvider;
        private Provider _newProvider;

        private ObservableCollection<Service> _services;
        private Service _selectedService;
        private Service _newService;


        private ServiceEditWindow serviceEditWindow;
        private EditProviderView editProviderView;


        // Команды
        public ICommand AddServiceCommand { get; }
        public ICommand EditServiceCommand { get; }
        public ICommand DeleteServiceCommand { get; }
        public ICommand SaveServiceCommand { get; }
        public ICommand SearchServiceCommand { get; }
        public ICommand AddProviderCommand { get; }
        public ICommand EditProviderCommand { get; }
        public ICommand DeleteProviderCommand { get; }
        public ICommand SaveProviderCommand { get; }


        public MainViewModel(IProviderService providerService, IServiceService serviceService)
        {
            _providerService = providerService;
            _serviceService = serviceService;

            LoadProviders();

            // Инициализация команд
            AddServiceCommand = new RelayCommand(AddService);
            EditServiceCommand = new RelayCommand(EditService, CanEditService);
            DeleteServiceCommand = new RelayCommand(DeleteService, CanDeleteService);
            SaveServiceCommand = new RelayCommand(SaveService, CanSaveService);
            SearchServiceCommand = new RelayCommand(SearchService);
            AddProviderCommand = new RelayCommand(AddProvider);
            EditProviderCommand = new RelayCommand(EditProvider, CanEditProvider);
            DeleteProviderCommand = new RelayCommand(DeleteProvider, CanEditProvider);
            SaveProviderCommand = new RelayCommand(SaveProvider, CanSaveProvider);
        }

        public Service GetSelectedService()
        {
            return _selectedService;
        }

        public Provider GetProviderService() 
        {
            return _selectedProvider;
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.PropertyName == nameof(SelectedService))
            {
                ((RelayCommand)EditServiceCommand).NotifyCanExecuteChanged();
                ((RelayCommand)DeleteServiceCommand).NotifyCanExecuteChanged();
            }
        }

        public ObservableCollection<Provider> Providers
        {
            get => _providers;
            set => SetProperty(ref _providers, value);
        }

        public Provider SelectedProvider
        {
            get => _selectedProvider;
            set
            {
                SetProperty(ref _selectedProvider, value);
                LoadServicesForProvider();
            }
        }

        public ObservableCollection<Service> Services
        {
            get => _services;
            set => SetProperty(ref _services, value);
        }

        public Service SelectedService
        {
            get => _selectedService;
            set => SetProperty(ref _selectedService, value);
        }

        public Provider NewProvider
        {
            get => _newProvider;
            set => SetProperty(ref _newProvider, value);
        }
        public Service NewService
        {
            get => _newService;
            set => SetProperty(ref _newService, value);
        }

        public List<Provider> GetAllProviders() 
        {
            return _providerService.GetAllProviders();
        }

        public List<Service> GetServicesBySelectedProvider()
        {
            return _serviceService.GetServicesByProvider(_selectedProvider.Id);
        }
        private async void LoadProviders()
        {
            var providers = await _providerService.GetAllProvidersAsync();
            Providers = new ObservableCollection<Provider>(providers);

            if (Providers.Count > 0)
                SelectedProvider = Providers[0];
        }

        // Ключевой метод для Master-Slave
        private async void LoadServicesForProvider()
        {
            if (SelectedProvider != null)
            {
                var services = await _serviceService.GetServicesByProviderAsync(SelectedProvider.Id);
                Services = new ObservableCollection<Service>(services);
            }
        }

        private void SearchService()
        {

        }

        private void AddProvider()
        {
            editProviderView = new EditProviderView(this, false);

            _newProvider = new Provider();

            if (editProviderView.ShowDialog() == true)
            {
                
            }
        }

        
        private void AddService()
        {
            var newService = new Service
            {
                ProviderId = SelectedProvider.Id,
                ProviderName = SelectedProvider.Name
            };
            _newService = newService;
            serviceEditWindow = new ServiceEditWindow(this, false);
           
            if (serviceEditWindow.ShowDialog() == true)
            {

            }
        }

        private bool CanEditService() => SelectedService != null;

        private bool CanEditProvider() => SelectedProvider != null;

        private void EditProvider() 

        { 
            editProviderView = new EditProviderView(this, true);

            if (editProviderView.ShowDialog() == true)
            {

            }
        }

        private void EditService()
        {
            serviceEditWindow = new ServiceEditWindow(this, true);

            if (serviceEditWindow.ShowDialog() == true)
            {
              
            }
        }

        private bool CanDeleteService() => SelectedService != null;

        private bool CanSaveService() => NewService != null || SelectedService != null;

        private bool CanSaveProvider()
        {
            return SelectedProvider != null || NewProvider != null;
        }

        private void DeleteProvider() 
        {
            if(SelectedProvider != null)
            {
                _providerService.DeleteProviderAsync(SelectedProvider.Id);
                Providers.Remove(SelectedProvider);
            }
        }

        private void DeleteService()
        {
            if (SelectedService != null)
            {
                _serviceService.DeleteServiceAsync(SelectedService.Id);
                Services.Remove(SelectedService);
            }
        }

        private async void SaveProvider()
        {
            try
            {
                if (editProviderView.IsEditMod())
                {
                    _selectedProvider = editProviderView.GetCarentProvider();
                    _providerService.UpdateProviderAsync(_selectedProvider);
                }
                else
                {
                    _newProvider = editProviderView.GetCarentProvider();

                    await _providerService.AddProviderAsync(_newProvider);
                    _providers.Add(_newProvider);
                }

                editProviderView.Close();
                editProviderView = null;
            }
            catch (Exception ex)
            {
                serviceEditWindow.Close();
                serviceEditWindow = null;
            }
        }

        private async void SaveService()
        {
            try
            {
                if (serviceEditWindow.IsEditMod()) 
                {
                    _selectedService = serviceEditWindow.GetCarentService();
                    _serviceService.UpdateServiceAsync(_selectedService);

                } else
                {
                    _newService = serviceEditWindow.GetCarentService();
                    _newService.ProviderId = _selectedProvider.Id;
                    await _serviceService.AddServiceAsync(_newService);
                    _services.Add(_newService);
                }

                serviceEditWindow.Close();
                serviceEditWindow = null;
            }
            catch (Exception ex)
            {
                serviceEditWindow.Close();
                serviceEditWindow = null;
            }
        }
    }
}