﻿using CatalogCars.Model.Database.Repositories.Default.Abstract;

namespace CatalogCars.Model.Database
{
    public class DefaultDataManager
    {
        public IMarksRepository Marks { get; set; }

        public IRolesRepository Roles { get; set; }

        public IUsersRepository Users { get; set; }

        public DefaultDataManager(IMarksRepository marks, IRolesRepository roles, IUsersRepository users)
        {
            Marks = marks;
            Roles = roles;
            Users = users;
        }
    }
}
