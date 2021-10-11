namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeDisplacement : Range<int>
    {
        public RangeDisplacement(int to, int from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
