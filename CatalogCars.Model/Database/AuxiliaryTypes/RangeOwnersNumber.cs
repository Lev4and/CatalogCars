namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeOwnersNumber : Range<int?>
    {
        public RangeOwnersNumber(int? to, int? from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
