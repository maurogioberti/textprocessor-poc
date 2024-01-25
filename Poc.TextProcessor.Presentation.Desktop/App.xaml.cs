using Microsoft.Extensions.DependencyInjection;
using Poc.TextProcessor.Business.Logic;
using Poc.TextProcessor.Business.Logic.Abstractions;
using Poc.TextProcessor.ResourceAccess.Mappers;
using Poc.TextProcessor.ResourceAccess.Repositories;
using Poc.TextProcessor.ResourceAccess.Repositories.Abstractions;
using Poc.TextProcessor.Services;
using Poc.TextProcessor.Services.Abstractions;
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
            // Main Window
            services.AddTransient(typeof(MainWindow));

            //TextService
            services.AddTransient<ITextService, TextService>();
            services.AddTransient<ITextLogic, TextLogic>();
            services.AddTransient<ITextRepository, TextRepository>();
            services.AddTransient<ITextMapper, TextMapper>();

            //TextSortService
            services.AddTransient<ITextSortService, TextSortService>();
            services.AddTransient<ITextSortLogic, TextSortLogic>();
            services.AddTransient<ITextSortRepository, TextSortRepository>();
            services.AddTransient<ITextSortMapper, TextSortMapper>();
        }
    }
}