using CatalogCars.DesktopApplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogCars.DesktopApplication.ViewModels.Locators
{
    public class ViewModelLocator
    {
        private static ServiceProvider _provider;

        public AnnouncementsViewModel AnnouncementsViewModel => _provider.GetRequiredService<AnnouncementsViewModel>();

        public AvailabilitiesViewModel AvailabilitiesViewModel => _provider.GetRequiredService<AvailabilitiesViewModel>();

        public BodyTypeGroupsViewModel BodyTypeGroupsViewModel => _provider.GetRequiredService<BodyTypeGroupsViewModel>();

        public BodyTypesViewModel BodyTypesViewModel => _provider.GetRequiredService<BodyTypesViewModel>();

        public CategoriesViewModel CategoriesViewModel => _provider.GetRequiredService<CategoriesViewModel>();

        public ColorsViewModel ColorsViewModel => _provider.GetRequiredService<ColorsViewModel>();

        public ColorTypesViewModel ColorTypesViewModel => _provider.GetRequiredService<ColorTypesViewModel>();

        public CoordinatesViewModel CoordinatesViewModel => _provider.GetRequiredService<CoordinatesViewModel>();

        public CurrenciesViewModel CurrenciesViewModel => _provider.GetRequiredService<CurrenciesViewModel>();

        public EngineTypesViewModel EngineTypesViewModel => _provider.GetRequiredService<EngineTypesViewModel>();

        public GearTypesViewModel GearTypesViewModel => _provider.GetRequiredService<GearTypesViewModel>();

        public GenerationsViewModel GenerationsViewModel => _provider.GetRequiredService<GenerationsViewModel>();

        public ImportCarsViewModel ImportCarsViewModel => _provider.GetRequiredService<ImportCarsViewModel>();

        public LocationsViewModel LocationsViewModel => _provider.GetRequiredService<LocationsViewModel>();

        public MainWindowViewModel MainWindowViewModel => _provider.GetRequiredService<MainWindowViewModel>();

        public MarkInfoViewModel MarkInfoViewModel => _provider.GetRequiredService<MarkInfoViewModel>();

        public MarksViewModel MarksViewModel => _provider.GetRequiredService<MarksViewModel>();

        public MenuViewModel MenuViewModel => _provider.GetRequiredService<MenuViewModel>();

        public ModelsViewModel ModelsViewModel => _provider.GetRequiredService<ModelsViewModel>();

        public OptionsViewModel OptionsViewModel => _provider.GetRequiredService<OptionsViewModel>();

        public PhonesViewModel PhonesViewModel => _provider.GetRequiredService<PhonesViewModel>();

        public PhotoClassesViewModel PhotoClassesViewModel => _provider.GetRequiredService<PhotoClassesViewModel>();

        public PriceSegmentsViewModel PriceSegmentsViewModel => _provider.GetRequiredService<PriceSegmentsViewModel>();

        public PtsTypesViewModel PtsTypesViewModel => _provider.GetRequiredService<PtsTypesViewModel>();

        public RegionsViewModel RegionsViewModel => _provider.GetRequiredService<RegionsViewModel>();

        public SalonsViewModel SalonsViewModel => _provider.GetRequiredService<SalonsViewModel>();

        public SectionsViewModel SectionsViewModel => _provider.GetRequiredService<SectionsViewModel>();

        public SellersViewModel SellersViewModel => _provider.GetRequiredService<SellersViewModel>();

        public SellerTypesViewModel SellerTypesViewModel => _provider.GetRequiredService<SellerTypesViewModel>();

        public StatusesViewModel StatusesViewModel => _provider.GetRequiredService<StatusesViewModel>();

        public SteeringWheelsViewModel SteeringWheelsViewModel => _provider.GetRequiredService<SteeringWheelsViewModel>();

        public TagsViewModel TagsViewModel => _provider.GetRequiredService<TagsViewModel>();

        public TransmissionsViewModel TransmissionsViewModel => _provider.GetRequiredService<TransmissionsViewModel>();

        public VendorsViewModel VendorsViewModel => _provider.GetRequiredService<VendorsViewModel>();

        public VinResolutionsViewModel VinResolutionsViewModel => _provider.GetRequiredService<VinResolutionsViewModel>();

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddTransient<AnnouncementsViewModel>();
            services.AddTransient<AvailabilitiesViewModel>();
            services.AddTransient<BodyTypeGroupsViewModel>();
            services.AddTransient<BodyTypesViewModel>();
            services.AddTransient<CategoriesViewModel>();
            services.AddTransient<ColorsViewModel>();
            services.AddTransient<ColorTypesViewModel>();
            services.AddTransient<CoordinatesViewModel>();
            services.AddTransient<CurrenciesViewModel>();
            services.AddTransient<EngineTypesViewModel>();
            services.AddTransient<GearTypesViewModel>();
            services.AddTransient<GenerationsViewModel>();
            services.AddTransient<ImportCarsViewModel>();
            services.AddTransient<LocationsViewModel>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MarkInfoViewModel>();
            services.AddTransient<MarksViewModel>();
            services.AddTransient<MenuViewModel>();
            services.AddTransient<ModelsViewModel>();
            services.AddTransient<OptionsViewModel>();
            services.AddTransient<PhonesViewModel>();
            services.AddTransient<PhotoClassesViewModel>();
            services.AddTransient<PriceSegmentsViewModel>();
            services.AddTransient<PtsTypesViewModel>();
            services.AddTransient<RegionsViewModel>();
            services.AddTransient<SalonsViewModel>();
            services.AddTransient<SectionsViewModel>();
            services.AddTransient<SellersViewModel>();
            services.AddTransient<SellerTypesViewModel>();
            services.AddTransient<StatusesViewModel>();
            services.AddTransient<SteeringWheelsViewModel>();
            services.AddTransient<TagsViewModel>();
            services.AddTransient<TransmissionsViewModel>();
            services.AddTransient<VendorsViewModel>();
            services.AddTransient<VinResolutionsViewModel>();

            services.AddSingleton<PageService>();
            services.AddSingleton<WindowService>();
            services.AddSingleton<MenuPageService>();

            _provider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                _provider.GetRequiredService(item.ServiceType);
            }
        }
    }
}
