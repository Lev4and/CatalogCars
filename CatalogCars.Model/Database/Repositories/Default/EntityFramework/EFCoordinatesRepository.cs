using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Coordinate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFCoordinatesRepository : ICoordinatesRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<ICoordinatesSorter> _sorters;

        public EFCoordinatesRepository(CatalogCarsDbContext context, IEnumerable<ICoordinatesSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsCoordinate(Guid locationId, double latitude, double longitude)
        {
            return _context.Coordinates.FirstOrDefault(coordinate => coordinate.LocationId == locationId &&
                coordinate.Latitude == latitude && coordinate.Longitude == longitude) != null;
        }

        public void DeleteCoordinate(Guid id)
        {
            _context.Coordinates.Remove(GetCoordinate(id));
            _context.SaveChanges();
        }

        public Coordinate GetCoordinate(Guid id)
        {
            return _context.Coordinates
                .Include(coordinate => coordinate.Location)
                    .ThenInclude(location => location.Region)
                .FirstOrDefault(coordinate => coordinate.Id == id);
        }

        public IQueryable<Coordinate> GetCoordinates(CoordinatesFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Coordinate> coordinates = _context.Coordinates
                .Include(coordinate => coordinate.Location)
                    .ThenInclude(location => location.Region)
                .Where(coordinate => EF.Functions.Like((coordinate.Location.Region.Name != null ?
                    (coordinate.Location.Address != null ? coordinate.Location.Region.Name + " - " :
                        coordinate.Location.Region.Name + "") : "") + (coordinate.Location.Address != null ?
                            coordinate.Location.Address + " " : " ") + "(" + coordinate.Latitude + " " + coordinate.Longitude +
                                ")", $"%{filters.SearchString}%") &&
                    (filters.RegionsIds.Count > 0 ? filters.RegionsIds.Contains((Guid)coordinate.Location.RegionId) : true));

            if(sorter != null)
            {
                coordinates = sorter.Sort(coordinates);
            }

            return coordinates
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public int GetCountCoordinates(CoordinatesFilters filters)
        {
            return _context.Coordinates
                .Include(coordinate => coordinate.Location)
                    .ThenInclude(location => location.Region)
                .Where(coordinate => EF.Functions.Like((coordinate.Location.Region.Name != null ?
                    (coordinate.Location.Address != null ? coordinate.Location.Region.Name + " - " :
                        coordinate.Location.Region.Name + "") : "") + (coordinate.Location.Address != null ?
                            coordinate.Location.Address + " " : " ") + "(" + coordinate.Latitude + " " + coordinate.Longitude +
                                ")", $"%{filters.SearchString}%") &&
                    (filters.RegionsIds.Count > 0 ? filters.RegionsIds.Contains((Guid)coordinate.Location.RegionId) : true))
                .Count();
        }

        public IQueryable<string> GetNamesCoordinates(string searchString)
        {
            return _context.Coordinates
                .Include(coordinate => coordinate.Location)
                    .ThenInclude(location => location.Region)
                .Where(coordinate => EF.Functions.Like((coordinate.Location.Region.Name != null ? 
                    (coordinate.Location.Address != null ? coordinate.Location.Region.Name + " - " : 
                        coordinate.Location.Region.Name + "") : "") + (coordinate.Location.Address != null ? 
                            coordinate.Location.Address + " " : "") + "(" + coordinate.Latitude + " " + coordinate.Longitude + 
                                ")", $"%{searchString}%"))
                .OrderBy(coordinate => coordinate.Location.Region.Name)
                    .ThenBy(coordinate => coordinate.Location.Address)
                        .ThenBy(coordinate => coordinate.Latitude)
                            .ThenBy(coordinate => coordinate.Longitude)
                .Select(coordinate => (coordinate.Location.Region.Name != null ? (coordinate.Location.Address != null ? 
                    coordinate.Location.Region.Name + " - " : coordinate.Location.Region.Name + "") : "") + 
                        (coordinate.Location.Address != null ? coordinate.Location.Address + " " : " ") + "(" + 
                            coordinate.Latitude + " " + coordinate.Longitude + ")")
                .Take(5)
                .AsNoTracking();
        }

        public bool SaveCoordinate(Coordinate coordinate)
        {
            if(coordinate.Id == default)
            {
                if(!ContainsCoordinate(coordinate.LocationId, coordinate.Latitude, coordinate.Longitude))
                {
                    _context.Entry(coordinate).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetCoordinate(coordinate.Id);

                if(currentVersion.LocationId != coordinate.LocationId || currentVersion.Latitude != coordinate.Latitude || 
                    currentVersion.Longitude != coordinate.Longitude)
                {
                    if (!ContainsCoordinate(coordinate.LocationId, coordinate.Latitude, coordinate.Longitude))
                    {
                        _context.Entry(coordinate).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(coordinate).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
