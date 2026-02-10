using BLL.Models;
using BLL.Services;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using WPF.Client.ViewModels;
using WPF.Client.Views;

namespace WPF.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private IServiceProvider _serviceProvider;

        public App()
        {

        }

        private void ConfigureServices(IServiceCollection services)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Data Source=USER-PC\\SQLEXPRESS;Initial Catalog=HouseholdServicesDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True");
            }, ServiceLifetime.Scoped);

          
            // Регистрация ViewModel
            services.AddTransient<MainViewModel>();

            // Регистрация сервисов
            services.AddTransient<IProviderService, ProviderService>();
            services.AddTransient<IServiceService, ServiceService>();

            // Регистрация окон
            services.AddSingleton<MainWindow>();
            services.AddSingleton<LoginView>();
            services.AddSingleton<EditProviderView>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            InitializeDatabase();

            //var loginView = _serviceProvider.GetRequiredService<LoginView>();
            var loginView = new LoginView();
            var loginResult = loginView.ShowDialog();
            if (loginResult == true)
            {
                var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
                mainWindow.Show();
            }
            else
            {
                Shutdown();
            }    
        }

        private void InitializeDatabase()
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            //DatabaseInitializer.Initialize(dbContext);
        }
    }
}
