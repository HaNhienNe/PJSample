using iFareData.Service.impl.Initialization;
using iFareData.Service.Interfaces.Initialization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace iFareData
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        private void ConfigureServices(IServiceCollection services)
        {
            // Đăng ký interface và implementation
            services.AddSingleton<IAppInitializer, AppInitializer>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Lấy FileInitializer từ DI container
            var appInitializer = _serviceProvider.GetService<IAppInitializer>();
            appInitializer.InitializeFoldersAndFiles();
        }
    }
}
