using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Location;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFLocationsRepository : ILocationsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<ILocationsSorter> _sorters;

        public EFLocationsRepository(CatalogCarsDbContext context, IEnumerable<ILocationsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsLocation(double latitude, double longitude)
        {
            return _context.Locations
                .Include(location => location.Coordinate)
                .FirstOrDefault(location => location.Coordinate.Latitude == latitude &&
                    location.Coordinate.Longitude == longitude) != null;
        }

        public void DeleteLocation(Guid id)
        {
            _context.Locations.Remove(GetLocation(id));
            _context.SaveChanges();
        }

        public int GetCountLocations(LocationsFilters filters)
        {
            return _context.Locations
                .Include(location => location.Region)
                .Where(location => EF.Functions.Like((location.Region.Name != null ? (location.Address != null ?
                    location.Region.Name + ", " : location.Region.Name) : "") + (location.Address != null ?
                        location.Address : ""), $"%{filters.SearchString}%") && 
                            (filters.RegionsIds.Count > 0 ? filters.RegionsIds.Contains((Guid)location.RegionId) : true))
                .Count();
        }

        public Location GetLocation(Guid id)
        {
            return _context.Locations
                .Include(location => location.Region)
                .Include(location => location.Coordinate)
                .FirstOrDefault(location => location.Id == id);
        }

        public IQueryable<Location> GetLocations(LocationsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Location> locations = _context.Locations
                .Include(location => location.Region)
                .Include(location => location.Coordinate)
                .Where(location => EF.Functions.Like((location.Region.Name != null ? (location.Address != null ? 
                    location.Region.Name + ", " : location.Region.Name) : "") + (location.Address != null ? 
                        location.Address : ""), $"%{filters.SearchString}%") &&
                            (filters.RegionsIds.Count > 0 ? filters.RegionsIds.Contains((Guid)location.RegionId) : true));

            if(sorter != null)
            {
                locations = sorter.Sort(locations);
            }

            return locations
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<string> GetNamesLocations(string searchString)
        {
            return _context.Locations
                .Include(location => location.Region)
                .Where(location =>
                    EF.Functions.Like((location.Region.Name != null ? (location.Address != null ? location.Region.Name + ", " : 
                        location.Region.Name) : "") + (location.Address != null ? location.Address : ""), $"%{searchString}%"))
                .OrderBy(location => location.Region.Name)
                    .ThenBy(location => location.Address)
                .Select(location => (location.Region.Name != null ? (location.Address != null ? location.Region.Name + ", " :
                    location.Region.Name) : "") + (location.Address != null ? location.Address : ""))
                .Take(5)
                .AsNoTracking();
        }

        public bool SaveLocation(Location location)
        {
            if(location.Id == default)
            {
                if(!ContainsLocation(location.Coordinate.Latitude, location.Coordinate.Longitude))
                {
                    _context.Entry(location).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetLocation(location.Id);

                if(currentVersion.Coordinate.Latitude == location.Coordinate.Latitude ||
                    currentVersion.Coordinate.Longitude == location.Coordinate.Longitude)
                {
                    if (!ContainsLocation(location.Coordinate.Latitude, location.Coordinate.Longitude))
                    {
                        _context.Entry(location).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(location).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return true;
        }
    }
}
