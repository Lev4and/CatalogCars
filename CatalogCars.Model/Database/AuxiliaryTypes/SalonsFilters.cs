using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class SalonsFilters : IFilters
    {
        public bool? IsOficial { get; set; }

        public bool? ActualStock { get; set; }

        public bool? LoyaltyProgram { get; set; }

        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchString { get; set; }

        public SortingOption SortingOption { get; set; }

        public RangeRegistrationDate RangeRegistrationDate { get; set; }

        public List<Guid> RegionsIds { get; set; }

        public SalonsFilters()
        {
            Reset();
        }

        public void Reset()
        {
            IsOficial = null;
            ActualStock = null;
            LoyaltyProgram = null;
            NumberPage = 1;
            ItemsPerPage = 25;
            SearchString = "";
            SortingOption = SortingOption.ByAscendingName;
            RangeRegistrationDate = new RangeRegistrationDate(DateTime.MinValue, DateTime.MaxValue);
            RegionsIds = new List<Guid>();
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
