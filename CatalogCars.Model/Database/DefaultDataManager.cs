using CatalogCars.Model.Database.Repositories.Default.Abstract;

namespace CatalogCars.Model.Database
{
    public class DefaultDataManager
    {
        public ICategoriesRepository Categories { get; set; }

        public ICurrenciesRepository Currencies { get; set; }

        public IGenerationsRepository Generations { get; set; }

        public ILocationsRepository Locations { get; set; }

        public IMarksRepository Marks { get; set; }

        public IModelsRepository Models { get; set; }

        public IPriceSegmentsRepository PriceSegments { get; set; }

        public IRegionsRepository Regions { get; set; }

        public IRolesRepository Roles { get; set; }

        public ISectionsRepository Sections { get; set; }

        public ISellerTypesRepository SellerTypes { get; set; }

        public IStatusesRepository Statuses { get; set; }

        public ISteeringWheelsRepository SteeringWheels { get; set; }

        public IUsersRepository Users { get; set; }

        public DefaultDataManager(ICategoriesRepository categories, ICurrenciesRepository currencies, 
            IGenerationsRepository generations, 
            ILocationsRepository locations, IMarksRepository marks, 
            IModelsRepository models, IPriceSegmentsRepository priceSegments, IRegionsRepository regions,
            IRolesRepository roles, IStatusesRepository statuses, ISectionsRepository sections, ISellerTypesRepository sellerTypes,
            ISteeringWheelsRepository steeringWheels, IUsersRepository users)
        {
            Categories = categories;
            Currencies = currencies;
            Generations = generations;
            Locations = locations;
            Marks = marks;
            Models = models;
            PriceSegments = priceSegments;
            Regions = regions;
            Roles = roles;
            Sections = sections;
            SellerTypes = sellerTypes;
            Statuses = statuses;
            SteeringWheels = steeringWheels;
            Users = users;
        }
    }
}
