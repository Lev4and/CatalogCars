using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ITagsRepository
    {
        int GetCountTags(TagsFilters filters);

        IQueryable<string> GetNamesTags(string searchString);

        IQueryable<Tag> GetTags(TagsFilters filters);
    }
}
