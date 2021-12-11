using CatalogCars.Resource.Requests.HttpRequesters;

namespace CatalogCars.Resource.Requests
{
    public class HttpClientContext
    {
        public AnnouncementAdditionalInformationRequester AnnouncementAdditionalInformation => new AnnouncementAdditionalInformationRequester();

        public AnnouncementsRequester Announcements => new AnnouncementsRequester();

        public AvailabilitiesRequester Availabilities => new AvailabilitiesRequester();

        public BodyTypeGroupsRequester BodyTypeGroups => new BodyTypeGroupsRequester();

        public BodyTypesRequester BodyTypes => new BodyTypesRequester();

        public CategoriesRequester Categories => new CategoriesRequester();

        public ColorsRequester Colors => new ColorsRequester();

        public ColorTypesRequester ColorTypes => new ColorTypesRequester();

        public ConfigurationsRequester Configurations => new ConfigurationsRequester();

        public CoordinatesRequester Coordinates => new CoordinatesRequester();

        public CurrenciesRequester Currencies => new CurrenciesRequester();

        public EngineTypesRequester EngineTypes => new EngineTypesRequester();

        public GearTypesRequester GearTypes => new GearTypesRequester();

        public GenerationsRequester Generations => new GenerationsRequester();

        public ImportRequester Import => new ImportRequester();

        public LocationsRequester Locations => new LocationsRequester();

        public MarksRequester Marks => new MarksRequester();

        public ModelsRequester Models => new ModelsRequester();

        public OptionsRequester Options => new OptionsRequester();

        public PhonesRequester Phones => new PhonesRequester();

        public PhotoClassesRequester PhotoClasses => new PhotoClassesRequester();

        public PriceSegmentsRequester PriceSegments => new PriceSegmentsRequester();

        public PricesRequester Prices => new PricesRequester();

        public PtsRequester Pts => new PtsRequester();

        public PtsTypesRequester PtsTypes => new PtsTypesRequester();

        public RegionsRequester Regions => new RegionsRequester();

        public SalonsRequester Salons => new SalonsRequester();

        public SectionsRequester Sections => new SectionsRequester();

        public SellersRequester Sellers => new SellersRequester();

        public SellerTypesRequester SellerTypes => new SellerTypesRequester();

        public StatesRequester States => new StatesRequester();

        public StatusesRequester Statuses => new StatusesRequester();

        public SteeringWheelsRequester SteeringWheels => new SteeringWheelsRequester();

        public TagsRequester Tags => new TagsRequester();

        public TechnicalParametersRequester TechnicalParameters => new TechnicalParametersRequester();

        public TransmissionsRequester Transmissions => new TransmissionsRequester();

        public VendorsRequester Vendors => new VendorsRequester();

        public VinResolutionsRequester VinResolutions => new VinResolutionsRequester();
    }
}
