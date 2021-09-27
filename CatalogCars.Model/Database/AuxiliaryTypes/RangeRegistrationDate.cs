using System;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class RangeRegistrationDate
    {
        public DateTime To { get; set; }

        public DateTime From { get; set; }

        public RangeRegistrationDate(DateTime to, DateTime from)
        {
            To = to;
            From = from;
        }
    }
}
