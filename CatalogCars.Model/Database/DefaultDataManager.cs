using CatalogCars.Model.Database.Repositories.Default.Abstract;

namespace CatalogCars.Model.Database
{
    public class DefaultDataManager
    {
        public IAvailabilitiesRepository Availabilities { get; set; }

        public IBodyTypeGroupsRepository BodyTypeGroups { get; set; }

        public IBodyTypesRepository BodyTypes { get; set; }

        public ICategoriesRepository Categories { get; set; }

        public IColorsRepository Colors { get; set; }

        public IColorTypesRepository ColorTypes { get; set; }

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

        public IPtsTypesRepository PtsTypes { get; set; }

        public IRegionsRepository Regions { get; set; }

        public IRolesRepository Roles { get; set; }

        public ISalonsRepository Salons { get; set; }

        public ISectionsRepository Sections { get; set; }

        public ISellersRepository Sellers { get; set; }

        public ISellerTypesRepository SellerTypes { get; set; }

        public IStatusesRepository Statuses { get; set; }

        public ISteeringWheelsRepository SteeringWheels { get; set; }

        public ITagsRepository Tags { get; set; }

        public ITransmissionsRepository Transmissions { get; set; }

        public IUsersRepository Users { get; set; }

        public IVendorsRepository Vendors { get; set; }

        public IVinResolutionsRepository VinResolutions { get; set; }

        public DefaultDataManager(IAvailabilitiesRepository availabilities, IBodyTypeGroupsRepository bodyTypeGroups, 
            IBodyTypesRepository bodyTypes, ICategoriesRepository categories, IColorsRepository colors,
            IColorTypesRepository colorTypes, ICoordinatesRepository coordinates, ICurrenciesRepository currencies, 
            IEngineTypesRepository engineTypes, IGearTypesRepository gearTypes, IGenerationsRepository generations, 
            ILocationsRepository locations, IMarksRepository marks, 
            IModelsRepository models, IOptionsRepository options, IPhonesRepository phones, IPhotoClassesRepository photoClasses, 
            IPriceSegmentsRepository priceSegments, IPtsTypesRepository ptsTypes, IRegionsRepository regions,
            IRolesRepository roles, ISalonsRepository salons, IStatusesRepository statuses, ISectionsRepository sections, 
            ISellersRepository sellers, ISellerTypesRepository sellerTypes,
            ISteeringWheelsRepository steeringWheels, ITagsRepository tags, ITransmissionsRepository transmissions, 
            IUsersRepository users,
            IVendorsRepository vendors, IVinResolutionsRepository vinResolutions)
        {
            Availabilities = availabilities;
            BodyTypeGroups = bodyTypeGroups;
            BodyTypes = bodyTypes;
            Categories = categories;
            Colors = colors;
            ColorTypes = colorTypes;
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
            PtsTypes = ptsTypes;
            Regions = regions;
            Roles = roles;
            Salons = salons;
            Sections = sections;
            Sellers = sellers;
            SellerTypes = sellerTypes;
            Statuses = statuses;
            SteeringWheels = steeringWheels;
            Tags = tags;
            Transmissions = transmissions;
            Users = users;
            Vendors = vendors;
            VinResolutions = vinResolutions;
        }
    }
}
