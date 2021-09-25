namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class CurrenciesFilters : IFilters
    {
        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchString { get; set; }

        public SortingOption SortingOption { get; set; }

        public CurrenciesFilters()
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
