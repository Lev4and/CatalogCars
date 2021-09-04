﻿using System;

namespace CatalogCars.Model.Database.Entities
{
    public class PictureWebp : Picture
    {
        public Guid Id { get; set; }

        public Guid ExternalPanoramaId { get; set; }

        public virtual ExternalPanorama ExternalPanorama { get; set; }
    }
}
