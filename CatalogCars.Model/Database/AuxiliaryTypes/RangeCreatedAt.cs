using System;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeCreatedAt : Range<DateTime>
    {
        public RangeCreatedAt(DateTime to, DateTime from) : base(to, from)
        {

        }

        public override bool CheckСhanges()
        {
            return From != Min || To != Max;
        }
    }
}
