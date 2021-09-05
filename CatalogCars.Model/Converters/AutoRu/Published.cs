using Newtonsoft.Json;

namespace CatalogCars.Model.Converters.AutoRu
{
    public class Published
    {
        [JsonProperty("published")]
        public bool? IsPublished { get; set; }

        [JsonProperty("quality_r4x3")]
        public double? QualityR4x3 { get; set; }

        [JsonProperty("quality_r16x9")]
        public double? QualityR16x9 { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("preview")]
        public string Preview { get; set; }

        [JsonProperty("video_h264")]
        public virtual Video VideoH264 { get; set; }

        [JsonProperty("video_webm")]
        public virtual Video VideoWebm { get; set; }

        [JsonProperty("picture_png")]
        public virtual Picture PicturePng { get; set; }

        [JsonProperty("picture_jpeg")]
        public virtual Picture PictureJpeg { get; set; }

        [JsonProperty("picture_webp")]
        public virtual Picture PictureWebp { get; set; }

        [JsonProperty("video_mp4_r16x9")]
        public virtual Video VideoMp4R16x9 { get; set; }

        [JsonProperty("video_webm_r16x9")]
        public virtual Video VideoWebmR16x9 { get; set; }

        [JsonProperty("picture_png_r16x9")]
        public virtual Picture PicturePngR16x9 { get; set; }

        [JsonProperty("picture_jpeg_r16x9")]
        public virtual Picture PictureJpegR16x9 { get; set; }

        [JsonProperty("picture_webp_r16x9")]
        public virtual Picture PictureWebpR16x9 { get; set; }
    }
}
