using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ITagsRepository
    {
        bool ContainsTag(string name, string ruName);

        bool SaveTag(Tag tag);

        int GetCountTags(TagsFilters filters);

        Tag GetTag(Guid id);

        IQueryable<string> GetNamesTags(string searchString);

        IQueryable<Tag> GetTags();

        IQueryable<Tag> GetTags(TagsFilters filters);

        void DeleteTag(Guid id);
    }
}
