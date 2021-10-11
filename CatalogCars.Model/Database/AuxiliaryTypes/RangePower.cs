namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangePower : Range<int>
    {
        public RangePower(int to, int from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
