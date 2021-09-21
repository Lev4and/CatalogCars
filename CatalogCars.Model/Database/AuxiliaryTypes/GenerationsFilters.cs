using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class GenerationsFilters : IFilters
    {
        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchString { get; set; }

        public Guid? PriceSegmentId { get; set; }

        public SortingOption SortingOption { get; set; }

        public RangeYearFrom RangeYearFrom { get; set; }

        public List<Guid> MarksIds { get; set; }

        public List<Guid> ModelsIds { get; set; }

        public GenerationsFilters()
        {
            Reset();
        }

        public void Reset()
        {
            NumberPage = 1;
            ItemsPerPage = 25;
            SearchString = "";
            PriceSegmentId = null;
            SortingOption = SortingOption.ByAscendingName;
            RangeYearFrom = new RangeYearFrom(2100, 1900);
            MarksIds = new List<Guid>();
            ModelsIds = new List<Guid>();
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
