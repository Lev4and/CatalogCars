namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeYear : Range<int?>
    {
        public RangeYear(int? to, int? from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
