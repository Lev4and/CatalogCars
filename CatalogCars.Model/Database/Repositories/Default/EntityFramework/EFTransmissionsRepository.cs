using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Transmission;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFTransmissionsRepository : ITransmissionsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<ITransmissionsSorter> _sorters;

        public EFTransmissionsRepository(CatalogCarsDbContext context, IEnumerable<ITransmissionsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public bool ContainsTransmission(string name, string ruName)
        {
            return _context.Transmissions.FirstOrDefault(transmission => transmission.Name == name ||
                transmission.RuName == ruName) != null;
        }

        public void DeleteTransmission(Guid id)
        {
            _context.Transmissions.Remove(GetTransmission(id));
            _context.SaveChanges();
        }

        public int GetCountTransmissions(TransmissionsFilters filters)
        {
            return _context.Transmissions
                .Where(transmission => EF.Functions.Like(transmission.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesTransmissions(string searchString)
        {
            return _context.Transmissions
                .Where(transmission => EF.Functions.Like(transmission.RuName, $"%{searchString}%"))
                .OrderBy(transmission => transmission.RuName)
                .Select(transmission => transmission.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public Transmission GetTransmission(Guid id)
        {
            return _context.Transmissions.FirstOrDefault(transmission => transmission.Id == id);
        }

        public IQueryable<Transmission> GetTransmissions(TransmissionsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Transmission> transmissions = _context.Transmissions
                .Where(transmission => EF.Functions.Like(transmission.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                transmissions = sorter.Sort(transmissions);
            }

            return transmissions
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public IQueryable<Transmission> GetTransmissions()
        {
            return _context.Transmissions
                .AsNoTracking();
        }

        public bool SaveTransmission(Transmission transmission)
        {
            if (transmission.Id == default)
            {
                if (!ContainsTransmission(transmission.Name, transmission.RuName))
                {
                    _context.Entry(transmission).State = EntityState.Added;
                    _context.SaveChanges();

                    return true;
                }
            }
            else
            {
                var currentVersion = GetTransmission(transmission.Id);

                if (currentVersion.Name != transmission.Name || currentVersion.RuName != transmission.RuName)
                {
                    if (!ContainsTransmission(transmission.Name, transmission.RuName))
                    {
                        _context.Entry(transmission).State = EntityState.Modified;
                        _context.SaveChanges();

                        return true;
                    }
                }
                else
                {
                    _context.Entry(transmission).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
