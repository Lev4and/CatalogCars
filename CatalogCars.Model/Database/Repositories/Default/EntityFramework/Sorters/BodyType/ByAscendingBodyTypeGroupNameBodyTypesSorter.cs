using CatalogCars.Model.Database.AuxiliaryTypes;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.BodyType
{
    public class ByAscendingBodyTypeGroupNameBodyTypesSorter : IBodyTypesSorter
    {
        public SortingOption SortingOption => SortingOption.ByAscendingBodyTypeGroupName;

        public IQueryable<Entities.BodyType> Sort(IQueryable<Entities.BodyType> collection)
        {
            return collection.OrderBy(item => item.BodyTypeGroup.RuName);
        }
    }
}
