﻿using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.PriceSegment;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFPriceSegmentsRepository : IPriceSegmentsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IPriceSegmentsSorter> _sorters;

        public EFPriceSegmentsRepository(CatalogCarsDbContext context, IEnumerable<IPriceSegmentsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public int GetCountPriceSegments(PriceSegmentsFilters filters)
        {
            return _context.PriceSegments
                .Where(priceSegment => EF.Functions.Like(priceSegment.RuName, $"%{filters.SearchString}%"))
                .Count();
        }

        public IQueryable<string> GetNamesPriceSegments(string searchString)
        {
            return _context.PriceSegments
                .Where(priceSegment => EF.Functions.Like(priceSegment.RuName, $"%{searchString}%"))
                .OrderBy(priceSegment => priceSegment.RuName)
                .Select(priceSegment => priceSegment.RuName)
                .Take(5)
                .AsNoTracking();
        }

        public IQueryable<PriceSegment> GetPriceSegments()
        {
            return _context.PriceSegments
                .OrderBy(priceSegment => priceSegment.Name)
                .AsNoTracking();
        }

        public IQueryable<PriceSegment> GetPriceSegments(PriceSegmentsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<PriceSegment> priceSegments = _context.PriceSegments
                .Where(priceSegment => EF.Functions.Like(priceSegment.RuName, $"%{filters.SearchString}%"));

            if(sorter != null)
            {
                priceSegments = sorter.Sort(priceSegments);
            }

            return priceSegments
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }
    }
}
