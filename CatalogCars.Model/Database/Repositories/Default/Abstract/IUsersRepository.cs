using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IUsersRepository
    {
        bool ContainsUserByName(string name);

        bool ContainsUserByEmail(string email);

        bool ContainsUserByIdAndName(Guid id, string name);

        bool ContainsUserByIdAndEmail(Guid id, string email);

        bool SaveUser(ApplicationUser entity, ApplicatonRole role, string currentPassword, string newPassword);

        ApplicationUser GetUserById(Guid id, bool track = false);

        IQueryable<ApplicationUser> GetManagers(bool track = false);

        void DeleteManagerById(Guid id);
    }
}
