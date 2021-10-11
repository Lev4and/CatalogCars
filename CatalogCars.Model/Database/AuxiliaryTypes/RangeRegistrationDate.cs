using System;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeRegistrationDate : Range<DateTime?>
    {
        public RangeRegistrationDate(DateTime? to, DateTime? from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
