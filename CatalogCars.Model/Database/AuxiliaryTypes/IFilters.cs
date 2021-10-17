using System.Collections.Generic;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public interface IFilters
    {
        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchString { get; set; }

        public SortingOption SortingOption { get; set; }

        public List<int> Limits { get; set; }

        public Dictionary<SortingOption, string> SortingOptions { get; set; }
    }
}
