using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Model.Database.Entities
{
    public class Price
    {
        public Guid Id { get; set; }

        public Guid AnnouncementId { get; set; }

        public Guid CurrencyId { get; set; }

        public bool WithNds { get; set; }

        public double Value { get; set; }

        public virtual Announcement Announcement { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
