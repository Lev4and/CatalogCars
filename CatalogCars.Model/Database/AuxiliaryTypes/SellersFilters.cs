using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class SellersFilters : IFilters
    {
        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchString { get; set; }

        public SortingOption SortingOption { get; set; }

        public List<Guid> RegionsIds { get; set; }

        public SellersFilters()
        {
            Reset();
        }

        public void Reset()
        {
            NumberPage = 1;
            ItemsPerPage = 25;
            SearchString = "";
            SortingOption = SortingOption.ByAscendingName;
            RegionsIds = new List<Guid>();
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
