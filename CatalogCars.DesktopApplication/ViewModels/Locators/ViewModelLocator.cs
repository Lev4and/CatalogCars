using CatalogCars.DesktopApplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogCars.DesktopApplication.ViewModels.Locators
{
    public class ViewModelLocator
    {
        private static ServiceProvider _provider;

        public ImportCarsViewModel ImportCarsViewModel => _provider.GetRequiredService<ImportCarsViewModel>();

        public MainWindowViewModel MainWindowViewModel => _provider.GetRequiredService<MainWindowViewModel>();

        public MarksViewModel MarksViewModel => _provider.GetRequiredService<MarksViewModel>();

        public MenuViewModel MenuViewModel => _provider.GetRequiredService<MenuViewModel>();

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddTransient<ImportCarsViewModel>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MarksViewModel>();
            services.AddTransient<MenuViewModel>();

            services.AddSingleton<PageService>();
            services.AddSingleton<WindowService>();
            services.AddTransient<MenuPageService>();

            _provider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                _provider.GetRequiredService(item.ServiceType);
            }
        }
    }
}
