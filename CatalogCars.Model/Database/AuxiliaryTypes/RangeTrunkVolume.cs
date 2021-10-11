namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeTrunkVolume : Range<double?>
    {
        public RangeTrunkVolume(double? to, double? from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
