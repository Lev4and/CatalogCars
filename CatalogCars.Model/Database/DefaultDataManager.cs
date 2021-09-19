using CatalogCars.Model.Database.Repositories.Default.Abstract;

namespace CatalogCars.Model.Database
{
    public class DefaultDataManager
    {
        public IGenerationsRepository Generations { get; set; }

        public IMarksRepository Marks { get; set; }

        public IModelsRepository Models { get; set; }

        public IPriceSegmentsRepository PriceSegments { get; set; }

        public IRegionsRepository Regions { get; set; }

        public IRolesRepository Roles { get; set; }

        public IUsersRepository Users { get; set; }

        public DefaultDataManager(IGenerationsRepository generations, IMarksRepository marks, 
            IModelsRepository models, IPriceSegmentsRepository priceSegments, IRegionsRepository regions,
            IRolesRepository roles, IUsersRepository users)
        {
            Generations = generations;
            Marks = marks;
            Models = models;
            PriceSegments = priceSegments;
            Regions = regions;
            Roles = roles;
            Users = users;
        }
    }
}
