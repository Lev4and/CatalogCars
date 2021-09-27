﻿using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Mark
{
    public class ByAscendingNameMarksSorter : IMarksSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingName;

        public IQueryable<Entities.Mark> Sort(IQueryable<Entities.Mark> collection)
        {
            return collection.OrderBy(item => item.Name);
        }
    }
}
