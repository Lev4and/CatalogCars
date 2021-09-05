﻿using CatalogCars.Model.Database.Entities;
using System;

namespace CatalogCars.Model.Database.Repositories.HighPerformance.Abstract
{
    public interface IPhotoClassesRepository
    {
        bool Contains(string name);

        bool Save(ref PhotoClass entity);

        Guid GetPhotoClassId(string name);
    }
}
