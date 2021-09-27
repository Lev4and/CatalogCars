﻿namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class PhotoClassesFilters : IFilters
    {
        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchString { get; set; }

        public SortingOption SortingOption { get; set; }

        public PhotoClassesFilters()
        {
            Reset();
        }

        public void Reset()
        {
            NumberPage = 1;
            ItemsPerPage = 25;
            SearchString = "";
            SortingOption = SortingOption.ByAscendingName;
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
