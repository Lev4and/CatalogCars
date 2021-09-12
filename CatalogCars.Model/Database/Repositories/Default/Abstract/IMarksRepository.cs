using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IMarksRepository
    {
        int GetCountMarks(MarksFilters filters);

        IQueryable<string> GetNamesMarks(string searchString);

        IQueryable<Mark> GetMarks(MarksFilters filters);
    }
}
