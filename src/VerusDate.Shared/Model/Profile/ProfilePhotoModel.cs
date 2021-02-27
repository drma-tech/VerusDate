using System;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfilePhotoModel
    {
        public string Main { get; set; }
        public string Validation { get; set; }
        public string[] Gallery { get; set; } = Array.Empty<string>();

        public double Confidence { get; set; }
        public double? Age { get; set; }
        public BiologicalSex? Gender { get; set; }

        public void UpdateMainPhoto(string Main)
        {
            this.Main = Main;
        }

        public void UpdatePhotoGallery(string[] Gallery)
        {
            this.Gallery = Gallery;
        }
    }
}