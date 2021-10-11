namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeYearFrom : Range<int?>
    {
        public RangeYearFrom(int? to, int? from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
