using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Model
{
    public class ByDescendingNameModelsSorter : IModelsSorter
    {
        public SortingOption SortingOption => SortingOption.ByDescendingName;

        public IQueryable<Entities.Model> Sort(IQueryable<Entities.Model> models)
        {
            return models.OrderByDescending(model => model.Name);
        }
    }
}
