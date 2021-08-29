namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeMileage
    {
        public double To { get; private set; }

        public double From { get; private set; }

        public RangeMileage(double to, double from)
        {
            To = to;
            From = from;
        }
    }
}
