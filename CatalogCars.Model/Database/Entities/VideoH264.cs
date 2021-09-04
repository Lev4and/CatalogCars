using System;

namespace CatalogCars.Model.Database.Entities
{
    public class VideoH264 : Video
    {
        public Guid Id { get; set; }

        public Guid ExternalPanoramaId { get; set; }

        public virtual ExternalPanorama ExternalPanorama { get; set; }
    }
}
