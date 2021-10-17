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
        
        public List<int> Limits { get; set; }

        public List<Guid> MarksIds { get; set; }

        public List<Guid> ModelsIds { get; set; }

        public Dictionary<SortingOption, string> SortingOptions { get; set; }

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
            Limits = new List<int>()
            {
                5, 10, 15, 20, 25, 50, 100
            };
            MarksIds = new List<Guid>();
            ModelsIds = new List<Guid>();
            SortingOptions = new Dictionary<SortingOption, string>()
            {
                { SortingOption.Default, "Сортировка по умолчанию" },
                { SortingOption.ByAscendingName, "Сортировка по названию: от А до Я" },
                { SortingOption.ByDescendingName, "Сортировка по названию: от Я до А" },
                { SortingOption.ByAscendingMarkName, "Сортировка по названию марки: от А до Я" },
                { SortingOption.ByDescendingMarkName, "Сортировка по названию марки: от Я до А" },
                { SortingOption.ByAscendingModelName, "Сортировка по названию модели: от А до Я" },
                { SortingOption.ByDescendingModelName, "Сортировка по названию модели: от Я до А" },
                { SortingOption.ByAscendingYearFrom, "Сортировка по возрастанию года релиза" },
                { SortingOption.ByDescendingYearFrom, "Сортировка по убыванию года релиза" }
            };
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
