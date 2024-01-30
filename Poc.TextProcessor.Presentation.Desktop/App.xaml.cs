using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.TextProcessor.Business.Logic;
using Poc.TextProcessor.Business.Logic.Abstractions;
using Poc.TextProcessor.CrossCutting.Configurations;
using Poc.TextProcessor.ResourceAccess.Database.Providers.EntityFramework.Configuration;
using Poc.TextProcessor.ResourceAccess.Mappers;
using Poc.TextProcessor.ResourceAccess.Repositories;
using Poc.TextProcessor.ResourceAccess.Repositories.Abstractions;
using Poc.TextProcessor.Services;
using Poc.TextProcessor.Services.Abstractions;
using System.IO;
using System.Text;
using System.Windows;

namespace Poc.TextProcessor.Presentation.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider? _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _serviceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(AppConfigurations.AppSettingsFileName, optional: false, reloadOnChange: true)
            .Build();

            // Main Window
            services.AddTransient(typeof(MainWindow));

            //Text Service
            services.AddTransient<ITextService, TextService>();
            services.AddTransient<ITextLogic, TextLogic>();
            services.AddTransient<ITextRepository, TextRepository>();
            services.AddTransient<ITextMapper, TextMapper>();

            //Text Sort Service
            services.AddTransient<ITextSortService, TextSortService>();
            services.AddTransient<ITextSortLogic, TextSortLogic>();
            services.AddTransient<ITextSortRepository, TextSortRepository>();
            services.AddTransient<ITextSortMapper, TextSortMapper>();

            // Configure database services
            services.ConfigureDatabaseServices(configuration);
        }
    }
}