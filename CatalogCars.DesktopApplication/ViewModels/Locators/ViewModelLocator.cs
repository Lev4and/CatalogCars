using CatalogCars.DesktopApplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogCars.DesktopApplication.ViewModels.Locators
{
    public class ViewModelLocator
    {
        private static ServiceProvider _provider;

        public GenerationsViewModel GenerationsViewModel => _provider.GetRequiredService<GenerationsViewModel>();

        public ImportCarsViewModel ImportCarsViewModel => _provider.GetRequiredService<ImportCarsViewModel>();

        public MainWindowViewModel MainWindowViewModel => _provider.GetRequiredService<MainWindowViewModel>();

        public MarksViewModel MarksViewModel => _provider.GetRequiredService<MarksViewModel>();

        public MenuViewModel MenuViewModel => _provider.GetRequiredService<MenuViewModel>();

        public ModelsViewModel ModelsViewModel => _provider.GetRequiredService<ModelsViewModel>();

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddTransient<GenerationsViewModel>();
            services.AddTransient<ImportCarsViewModel>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MarksViewModel>();
            services.AddTransient<MenuViewModel>();
            services.AddTransient<ModelsViewModel>();

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
