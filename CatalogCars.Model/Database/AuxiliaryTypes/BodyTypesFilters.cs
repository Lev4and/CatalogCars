using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class BodyTypesFilters : IFilters
    {
        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchString { get; set; }

        public SortingOption SortingOption { get; set; }

        public List<Guid> BodyTypeGroupsIds { get; set; }

        public BodyTypesFilters()
        {
            Reset();
        }

        public void Reset()
        {
            NumberPage = 1;
            ItemsPerPage = 25;
            SearchString = "";
            SortingOption = SortingOption.ByAscendingName;
            BodyTypeGroupsIds = new List<Guid>();
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
