using System;

namespace CatalogCars.Model.Database.Entities
{
    public class ExternalPanorama
    {
        public Guid Id { get; set; }

        public Guid StateId { get; set; }

        public string Preview { get; set; }

        public double QualityR4x3 { get; set; }

        public double QualityR16x9 { get; set; }

        public virtual State State { get; set; }

        public virtual VideoH264 VideoH264 { get; set; }

        public virtual VideoWebm VideoWebm { get; set; }

        public virtual PicturePng PicturePng { get; set; }

        public virtual PictureJpeg PictureJpeg { get; set; }

        public virtual PictureWebp PictureWebp { get; set; }

        public virtual VideoMp4R16x9 VideoMp4R16x9 { get; set; }

        public virtual VideoWebmR16x9 VideoWebmR16x9 { get; set; }

        public virtual PicturePngR16x9 PicturePngR16x9 { get; set; }

        public virtual PictureJpegR16x9 PictureJpegR16x9 { get; set; }

        public virtual PictureWebpR16x9 PictureWebpR16x9 { get; set; }
    }
}
