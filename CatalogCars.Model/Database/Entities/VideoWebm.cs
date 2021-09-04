using System;

namespace CatalogCars.Model.Database.Entities
{
    public class VideoWebm : Video
    {
        public Guid Id { get; set; }

        public Guid ExternalPanoramaId { get; set; }

        public virtual ExternalPanorama ExternalPanorama { get; set; }
    }
}
