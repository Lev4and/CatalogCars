using CatalogCars.Model.Database.Repositories.Default.Abstract;

namespace CatalogCars.Model.Database
{
    public class DefaultDataManager
    {
        public IMarksRepository Marks { get; set; }

        public IModelsRepository Models { get; set; }

        public IRolesRepository Roles { get; set; }

        public IUsersRepository Users { get; set; }

        public DefaultDataManager(IMarksRepository marks, IModelsRepository models, IRolesRepository roles, 
            IUsersRepository users)
        {
            Marks = marks;
            Models = models;
            Roles = roles;
            Users = users;
        }
    }
}
