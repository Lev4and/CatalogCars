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

        public Dictionary<SortingOption, string> SortingOptions { get; set; }

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
            SortingOptions = new Dictionary<SortingOption, string>()
            {
                { SortingOption.Default, "Сортировка по умолчанию" },
                { SortingOption.ByAscendingName, "Сортировка по названию: от А до Я" },
                { SortingOption.ByDescendingName, "Сортировка по названию: от Я до А" },
                { SortingOption.ByAscendingAutoClass, "Сортировка по классу кузова: от А до Я" },
                { SortingOption.ByDescendingAutoClass, "Сортировка по классу кузова: от Я до А" },
                { SortingOption.ByAscendingBodyTypeGroupName, "Сортировка по названию типа кузова: от А до Я" },
                { SortingOption.ByDescendingBodyTypeGroupName, "Сортировка по названию типа кузова: от Я до А" }
            };
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
