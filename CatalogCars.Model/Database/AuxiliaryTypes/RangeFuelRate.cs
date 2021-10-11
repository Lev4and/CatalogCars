namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeFuelRate : Range<double?>
    {
        public RangeFuelRate(double? to, double? from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
