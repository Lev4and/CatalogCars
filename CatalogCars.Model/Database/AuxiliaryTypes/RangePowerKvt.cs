namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangePowerKvt : Range<int>
    {
        public RangePowerKvt(int to, int from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
