using CatalogCars.Model.Database.Repositories.Default.Abstract;

namespace CatalogCars.Model.Database
{
    public class DefaultDataManager
    {
        public IRolesRepository Roles { get; set; }

        public IUsersRepository Users { get; set; }

        public DefaultDataManager(IRolesRepository roles, IUsersRepository users)
        {
            Roles = roles;
            Users = users;
        }
    }
}
