using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IRolesRepository
    {
        ApplicatonRole GetRoleByName(string name, bool track = false);

        IQueryable<ApplicatonRole> GetRoles(bool track = false);
    }
}
