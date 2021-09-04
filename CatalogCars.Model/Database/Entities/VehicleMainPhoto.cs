using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.Model.Database.Entities
{
    public class VehicleMainPhoto
    {
        public Guid Id { get; set; }

        public Guid ConfigurationId { get; set; }

        public string Original { get; set; }

        public string Cattouch { get; set; }

        public string Wizardv3mr { get; set; }

        public virtual Configuration Configuration { get; set; }
    }
}
