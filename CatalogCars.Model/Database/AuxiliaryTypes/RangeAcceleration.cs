namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeAcceleration : Range<double>
    {
        public RangeAcceleration(double to, double from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
