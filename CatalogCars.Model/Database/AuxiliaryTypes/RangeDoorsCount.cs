namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeDoorsCount : Range<int>
    {
        public RangeDoorsCount(int to, int from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
