using CatalogCars.Model.Database.Repositories.Default.Abstract;

namespace CatalogCars.Model.Database
{
    public class AuthorizationDataManager
    {
        public IRolesRepository Roles { get; set; }

        public IUsersRepository Users { get; set; }

        public AuthorizationDataManager(IRolesRepository roles, IUsersRepository users)
        {
            Roles = roles;
            Users = users;
        }
    }
}
