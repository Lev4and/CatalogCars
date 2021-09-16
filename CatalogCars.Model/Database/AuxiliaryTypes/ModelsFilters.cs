using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class ModelsFilters : IFilters
    {
        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchString { get; set; }

        public SortingOption SortingOption { get; set; }

        public List<Guid> MarksIds { get; set; }

        public ModelsFilters()
        {
            NumberPage = 1;
            ItemsPerPage = 25;
            SearchString = "";
            SortingOption = SortingOption.ByAscendingName;
            MarksIds = new List<Guid>();
        }

        public void Reset()
        {
            NumberPage = 1;
            ItemsPerPage = 25;
            SearchString = "";
            SortingOption = SortingOption.ByAscendingName;
            MarksIds = new List<Guid>();
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
