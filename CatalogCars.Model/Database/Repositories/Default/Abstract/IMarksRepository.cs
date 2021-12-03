using CatalogCars.Model.Database.AnonymousTypes;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using System;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IMarksRepository
    {
        bool ContainsMark(string name);

        bool SaveMark(Mark mark);

        int GetCountMarks(MarksFilters filters);

        Mark GetMark(Guid markId);

        IQueryable<string> GetNamesMarks(string searchString);

        IQueryable<Mark> GetMarks();

        IQueryable<Mark> GetMarks(MarksFilters filters);

        IQueryable<PopularMark> GetPopularMarks();

        IQueryable<PopularityMark> GetPopularityMark(Guid markId);

        void DeleteMark(Guid id);
    }
}
