using CatalogCars.Model.Database.AuxiliaryTypes;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.BodyType
{
    public class ByDescendingNameBodyTypesSorter : IBodyTypesSorter
    {
        public SortingOption SortingOption => throw new NotImplementedException();

        public IQueryable<Entities.BodyType> Sort(IQueryable<Entities.BodyType> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
