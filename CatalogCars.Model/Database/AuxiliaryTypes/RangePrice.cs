namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangePrice
    {
        public double To { get; private set; }

        public double From { get; private set; }

        public RangePrice(double to, double from)
        {
            To = to;
            From = from;
        }
    }
}
