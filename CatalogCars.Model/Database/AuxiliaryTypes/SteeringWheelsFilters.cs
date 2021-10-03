using System.Collections.Generic;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class SteeringWheelsFilters : IFilters
    {
        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchString { get; set; }

        public SortingOption SortingOption { get; set; }

        public Dictionary<SortingOption, string> SortingOptions { get; set; }

        public SteeringWheelsFilters()
        {
            Reset();
        }

        public void Reset()
        {
            NumberPage = 1;
            ItemsPerPage = 25;
            SearchString = "";
            SortingOption = SortingOption.ByAscendingName;
            SortingOptions = new Dictionary<SortingOption, string>()
            {
                { SortingOption.Default, "Сортировка по умолчанию" },
                { SortingOption.ByAscendingName, "Сортировка по названию: от А до Я" },
                { SortingOption.ByDescendingName, "Сортировка по названию: от Я до А" }
            };
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
