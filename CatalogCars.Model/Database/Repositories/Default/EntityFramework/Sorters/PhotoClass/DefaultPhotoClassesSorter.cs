using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PhotoClass
{
    public class DefaultPhotoClassesSorter : IPhotoClassesSorter
    {
        public SortingOption SortingOption => SortingOption.Default;

        public IQueryable<Entities.PhotoClass> Sort(IQueryable<Entities.PhotoClass> collection)
        {
            return collection.OrderBy(item => item.Id);
        }
    }
}
