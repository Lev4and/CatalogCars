namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeYearFrom
    {
        public int? To { get; set; }

        public int? From { get; set; }

        public RangeYearFrom(int? to, int? from)
        {
            To = to;
            From = from;
        }
    }
}
