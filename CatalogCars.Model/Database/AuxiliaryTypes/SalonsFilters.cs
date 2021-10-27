using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class SalonsFilters : IFilters
    {
        public bool? IsOfficial { get; set; }

        public bool? ActualStock { get; set; }

        public bool? LoyaltyProgram { get; set; }

        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchString { get; set; }

        public SortingOption SortingOption { get; set; }

        public RangeRegistrationDate RangeRegistrationDate { get; set; }
        
        public List<int> Limits { get; set; }

        public List<Guid> RegionsIds { get; set; }

        public Dictionary<bool?, string> IsOfficialValues { get; set; }

        public Dictionary<bool?, string> ActualStockValues { get; set; }

        public Dictionary<bool?, string> LoyaltyProgramValues { get; set; }

        public Dictionary<SortingOption, string> SortingOptions { get; set; }

        public SalonsFilters()
        {
            Reset(DateTime.MaxValue, DateTime.MinValue);
        }

        public SalonsFilters(DateTime toRegistrationDate, DateTime fromRegistrationDate)
        {
            Reset(toRegistrationDate, fromRegistrationDate);
        }

        public void Reset(DateTime toRegistrationDate, DateTime fromRegistrationDate)
        {
            IsOfficial = null;
            ActualStock = null;
            LoyaltyProgram = null;
            NumberPage = 1;
            ItemsPerPage = 25;
            SearchString = "";
            SortingOption = SortingOption.ByAscendingName;
            RangeRegistrationDate = new RangeRegistrationDate(toRegistrationDate, fromRegistrationDate);
            Limits = new List<int>()
            {
                5, 10, 15, 20, 25, 50, 100
            };
            RegionsIds = new List<Guid>();
            IsOfficialValues = new Dictionary<bool?, string>()
            {
                { true, "Является официальным" },
                { false, "Не является официальным" }
            };
            ActualStockValues = new Dictionary<bool?, string>()
            {
                { true, "Есть" },
                { false, "Нету" }
            };
            LoyaltyProgramValues = new Dictionary<bool?, string>()
            {
                { true, "Есть" },
                { false, "Нету" }
            };
            SortingOptions = new Dictionary<SortingOption, string>()
            {
                { SortingOption.Default, "Сортировка по умолчанию" },
                { SortingOption.ByAscendingName, "Сортировка по названию: от А до Я" },
                { SortingOption.ByDescendingName, "Сортировка по названию: от Я до А" },
                { SortingOption.ByAscendingRegionName, "Сортировка по региону: от А до Я" },
                { SortingOption.ByDescendingRegionName, "Сортировка по региону: от Я до А" },
                { SortingOption.ByAscendingLocationAddress, "Сортировка по адресу: от А до Я" },
                { SortingOption.ByDescendingLocationAddress, "Сортировка по адресу: от Я до А" },
                { SortingOption.ByAscendingRegistrationDate, "Сортировка по возрастанию даты регистрации" },
                { SortingOption.ByDescendingRegistrationDate, "Сортировка по убыванию даты регистрации" }
            };
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
