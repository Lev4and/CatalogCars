﻿using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class LocationsFilters : IFilters
    {
        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchString { get; set; }

        public SortingOption SortingOption { get; set; }

        public List<Guid> RegionsIds { get; set; }

        public Dictionary<SortingOption, string> SortingOptions { get; set; }

        public LocationsFilters()
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
            SortingOptions = new Dictionary<SortingOption, string>()
            {
                { SortingOption.Default, "Сортировка по умолчанию" },
                { SortingOption.ByAscendingName, "Сортировка по названию: от А до Я" },
                { SortingOption.ByDescendingName, "Сортировка по названию: от Я до А" },
                { SortingOption.ByAscendingRegionName, "Сортировка по региону: от А до Я" },
                { SortingOption.ByDescendingRegionName, "Сортировка по региону: от Я до А" }
            };
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
