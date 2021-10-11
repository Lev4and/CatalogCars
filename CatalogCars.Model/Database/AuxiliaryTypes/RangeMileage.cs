namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeMileage : Range<double>
    {
        public RangeMileage(double to, double from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
