using CatalogCars.Model.Database.AnonymousTypes;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Mark;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFMarksRepository : IMarksRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IMarksSorter> _sorters;

        public EFMarksRepository(CatalogCarsDbContext context, IEnumerable<IMarksSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountMarks(MarksFilters filters)
        {
            return _context.Marks
                .Where(mark => mark.Name.ToLower().Contains(filters.SearchString))
                .Count();
        }

        public IQueryable<string> GetNamesMarks(string searchString)
        {
            return _context.Marks
                .Where(mark => mark.Name.ToLower().Contains(searchString))
                .Select(mark => mark.Name)
                .OrderBy(mark => mark)
                .Take(5)
                .AsNoTracking();
        }

        public IQueryable<Mark> GetMarks(MarksFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Mark> marks = _context.Marks
                .Include(mark => mark.Logo)
                .Where(mark => EF.Functions.Like(mark.Name, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                marks = sorter.Sort(marks);
            }

            return marks
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public Mark GetMark(Guid markId)
        {
            return _context.Marks
                .Include(mark => mark.Logo)
                .Include(mark => mark.Models)
                .AsNoTracking()
                .FirstOrDefault(mark => mark.Id == markId);
        }

        public IQueryable<PopularityMark> GetPopularityMark(Guid markId)
        {
            return _context.AnnouncementAdditionalInformation
                .Include(announcementAdditionalInformation => announcementAdditionalInformation.Announcement)
                    .ThenInclude(announcement => announcement.Vehicle)
                        .ThenInclude(vehicle => vehicle.Generation)
                            .ThenInclude(generation => generation.Model)
                .Where(announcementAdditionalInformation =>
                    announcementAdditionalInformation.Announcement.Vehicle.Generation.Model.MarkId == markId && 
                        announcementAdditionalInformation.CreatedAt >= DateTime.Now.AddMonths(-1))
                .GroupBy(announcementAdditionalInformation => announcementAdditionalInformation.CreatedAt.Date)
                .Select(group => new PopularityMark
                {
                    Count = group.Count(),
                    DateTime = group.Key
                })
                .OrderBy(popularityMark => popularityMark.DateTime)
                .AsNoTracking();
        }

        public IQueryable<Mark> GetMarks()
        {
            return _context.Marks
                .OrderBy(mark => mark.Name)
                .AsNoTracking();
        }

        public bool ContainsMark(string name)
        {
            return _context.Marks.FirstOrDefault(mark => mark.Name == name) != null;
        }

        public bool SaveMark(Mark mark)
        {
            if(mark.Id == default)
            {
                if (!ContainsMark(mark.Name))
                {
                    _context.Entry(mark).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetMark(mark.Id);

                if(currentVersion.Name != mark.Name)
                {
                    if (!ContainsMark(mark.Name))
                    {
                        _context.Entry(mark).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(mark).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public void DeleteMark(Guid id)
        {
            _context.Marks.Remove(GetMark(id));
            _context.SaveChanges();
        }

        public IQueryable<PopularMark> GetPopularMarks()
        {
            return _context.VehicleInformation
                .Include(vehicleInformation => vehicleInformation.Generation)
                    .ThenInclude(generation => generation.Model)
                        .ThenInclude(model => model.Mark)
                            .ThenInclude(mark => mark.Logo)
                .GroupBy(vehicleInformation => new 
                {
                    vehicleInformation.Generation.Model.Mark.Id,
                    vehicleInformation.Generation.Model.Mark.Name,
                    vehicleInformation.Generation.Model.Mark.Logo.BigLogo 
                })
                .Select(group => new PopularMark
                {
                    Id = group.Key.Id,
                    Name = group.Key.Name,
                    Logo = group.Key.BigLogo,
                    Count = group.Count()
                })
                .OrderByDescending(popularMark => popularMark.Count)
                .AsNoTracking();
        }
    }
}
