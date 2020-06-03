using Microsoft.Extensions.DependencyInjection;
using InnovativeProduct.ApplicationServices.GetProductListUseCase;
using InnovativeProduct.ApplicationServices.Ports.Cache;
using InnovativeProduct.ApplicationServices.Repositories;
using InnovativeProduct.DesktopClient.InfrastructureServices.ViewModels;
using InnovativeProduct.DomainObjects;
using InnovativeProduct.DomainObjects.Ports;
using InnovativeProduct.InfrastructureServices.Cache;
using InnovativeProduct.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InnovativeProduct.DesktopClient 
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<Product>, DomainObjectsMemoryCache<Product>>();
            services.AddSingleton<NetworkProductRepository>(
                x => new NetworkProductRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<Product>>())
            );
            services.AddSingleton<CachedReadOnlyProductRepository>(
                x => new CachedReadOnlyProductRepository(
                    x.GetRequiredService<NetworkProductRepository>(),
                    x.GetRequiredService<IDomainObjectsCache<Product>>()
                )
            );
            services.AddSingleton<IReadOnlyProductRepository>(x => x.GetRequiredService<CachedReadOnlyProductRepository>());
            services.AddSingleton<IGetProductListUseCase, GetProductListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
