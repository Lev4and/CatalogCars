using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFRolesRepository : IRolesRepository
    {
        private readonly CatalogCarsDbContext _context;

        public EFRolesRepository(CatalogCarsDbContext context)
        {
            _context = context;
        }

        public ApplicatonRole GetRoleByName(string name, bool track = false)
        {
            IQueryable<ApplicatonRole> roles = _context.Roles;

            if (!track)
            {
                roles = roles.AsNoTracking();
            }

            return roles.SingleOrDefault(role => role.Name == name);
        }

        public IQueryable<ApplicatonRole> GetRoles(bool track = false)
        {
            IQueryable<ApplicatonRole> roles = _context.Roles;

            if (!track)
            {
                roles = roles.AsNoTracking();
            }

            return roles;
        }
    }
}
