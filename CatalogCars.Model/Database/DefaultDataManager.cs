using CatalogCars.Model.Database.Repositories.Default.Abstract;

namespace CatalogCars.Model.Database
{
    public class DefaultDataManager
    {
        public IGenerationsRepository Generations { get; set; }

        public ILocationsRepository Locations { get; set; }

        public IMarksRepository Marks { get; set; }

        public IModelsRepository Models { get; set; }

        public IPriceSegmentsRepository PriceSegments { get; set; }

        public IRegionsRepository Regions { get; set; }

        public IRolesRepository Roles { get; set; }

        public IStatusesRepository Statuses { get; set; }

        public IUsersRepository Users { get; set; }

        public DefaultDataManager(IGenerationsRepository generations, ILocationsRepository locations, IMarksRepository marks, 
            IModelsRepository models, IPriceSegmentsRepository priceSegments, IRegionsRepository regions,
            IRolesRepository roles, IStatusesRepository statuses, IUsersRepository users)
        {
            Generations = generations;
            Locations = locations;
            Marks = marks;
            Models = models;
            PriceSegments = priceSegments;
            Regions = regions;
            Roles = roles;
            Statuses = statuses;
            Users = users;
        }
    }
}
