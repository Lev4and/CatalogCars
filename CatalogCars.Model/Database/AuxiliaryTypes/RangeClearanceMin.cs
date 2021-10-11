namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeClearanceMin : Range<int>
    {
        public RangeClearanceMin(int to, int from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
