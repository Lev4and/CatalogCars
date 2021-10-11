using CatalogCars.Model.Database.Repositories.Default.Abstract;

namespace CatalogCars.Model.Database
{
    public class DefaultDataManager
    {
        public IAnnouncementAdditionalInformationRepository AnnouncementAdditionalInformation { get; set; }

        public IAnnouncementsRepository Announcements { get; set; }

        public IAvailabilitiesRepository Availabilities { get; set; }

        public IBodyTypeGroupsRepository BodyTypeGroups { get; set; }

        public IBodyTypesRepository BodyTypes { get; set; }

        public ICategoriesRepository Categories { get; set; }

        public IColorsRepository Colors { get; set; }

        public IColorTypesRepository ColorTypes { get; set; }

        public IConfigurationsRepository Configurations { get; set; }

        public ICoordinatesRepository Coordinates { get; set; }

        public ICurrenciesRepository Currencies { get; set; }

        public IEngineTypesRepository EngineTypes { get; set; }

        public IGearTypesRepository GearTypes { get; set; }

        public IGenerationsRepository Generations { get; set; }

        public ILocationsRepository Locations { get; set; }

        public IMarksRepository Marks { get; set; }

        public IModelsRepository Models { get; set; }

        public IOptionsRepository Options { get; set; }

        public IPhonesRepository Phones { get; set; }

        public IPhotoClassesRepository PhotoClasses { get; set; }

        public IPriceSegmentsRepository PriceSegments { get; set; }

        public IPricesRepository Prices { get; set; }

        public IPtsTypesRepository PtsTypes { get; set; }

        public IRegionsRepository Regions { get; set; }

        public IRolesRepository Roles { get; set; }

        public ISalonsRepository Salons { get; set; }

        public ISectionsRepository Sections { get; set; }

        public ISellersRepository Sellers { get; set; }

        public ISellerTypesRepository SellerTypes { get; set; }

        public IStatesRepository States { get; set; }

        public IStatusesRepository Statuses { get; set; }

        public ISteeringWheelsRepository SteeringWheels { get; set; }

        public ITagsRepository Tags { get; set; }

        public ITechnicalParametersRepository TechnicalParameters { get; set; }

        public ITransmissionsRepository Transmissions { get; set; }

        public IUsersRepository Users { get; set; }

        public IVendorsRepository Vendors { get; set; }

        public IVinResolutionsRepository VinResolutions { get; set; }

        public DefaultDataManager(IAnnouncementAdditionalInformationRepository announcementAdditionalInformation, 
            IAnnouncementsRepository announcements, IAvailabilitiesRepository availabilities, 
            IBodyTypeGroupsRepository bodyTypeGroups, IBodyTypesRepository bodyTypes, ICategoriesRepository categories, 
            IColorsRepository colors, IColorTypesRepository colorTypes, IConfigurationsRepository configurations, 
            ICoordinatesRepository coordinates, 
            ICurrenciesRepository currencies, IEngineTypesRepository engineTypes, IGearTypesRepository gearTypes, 
            IGenerationsRepository generations, ILocationsRepository locations, IMarksRepository marks, 
            IModelsRepository models, IOptionsRepository options, IPhonesRepository phones, IPhotoClassesRepository photoClasses, 
            IPriceSegmentsRepository priceSegments, IPricesRepository prices, IPtsTypesRepository ptsTypes, IRegionsRepository regions,
            IRolesRepository roles, ISalonsRepository salons, IStatusesRepository statuses, ISectionsRepository sections, 
            ISellersRepository sellers, ISellerTypesRepository sellerTypes, IStatesRepository states,
            ISteeringWheelsRepository steeringWheels, ITagsRepository tags, ITechnicalParametersRepository technicalParameters, 
            ITransmissionsRepository transmissions, IUsersRepository users,
            IVendorsRepository vendors, IVinResolutionsRepository vinResolutions)
        {
            AnnouncementAdditionalInformation = announcementAdditionalInformation;
            Announcements = announcements;
            Availabilities = availabilities;
            BodyTypeGroups = bodyTypeGroups;
            BodyTypes = bodyTypes;
            Categories = categories;
            Colors = colors;
            ColorTypes = colorTypes;
            Configurations = configurations;
            Coordinates = coordinates;
            Currencies = currencies;
            EngineTypes = engineTypes;
            GearTypes = gearTypes;
            Generations = generations;
            Locations = locations;
            Marks = marks;
            Models = models;
            Options = options;
            Phones = phones;
            PhotoClasses = photoClasses;
            PriceSegments = priceSegments;
            Prices = prices;
            PtsTypes = ptsTypes;
            Regions = regions;
            Roles = roles;
            Salons = salons;
            Sections = sections;
            Sellers = sellers;
            SellerTypes = sellerTypes;
            States = states;
            Statuses = statuses;
            SteeringWheels = steeringWheels;
            Tags = tags;
            TechnicalParameters = technicalParameters;
            Transmissions = transmissions;
            Users = users;
            Vendors = vendors;
            VinResolutions = vinResolutions;
        }
    }
}
