using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PhotoClass
{
    public class ByDescendingNamePhotoClassesSorter : IPhotoClassesSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.PhotoClass> Sort(IQueryable<Entities.PhotoClass> collection)
        {
            return collection.OrderByDescending(item => item.RuName);
        }
    }
}
