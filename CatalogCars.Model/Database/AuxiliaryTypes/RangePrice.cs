namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangePrice : Range<double>
    {
        public RangePrice(double to, double from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
