using System;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfilePhotoModel
    {
        public string Main { get; set; }
        public string[] Gallery { get; set; } = Array.Empty<string>();

        public string Validation { get; set; }
        public Guid? FaceId { get; set; }
        public DateTime DtMainUpload { get; set; }

        public double Confidence { get; set; }
        public double? Age { get; set; }
        public BiologicalSex? Gender { get; set; }

        public void UpdateMainPhoto(string Main)
        {
            this.Main = Main;

            this.Validation = null;
            this.FaceId = null;
            this.DtMainUpload = DateTime.UtcNow;

            this.Confidence = 0;
            this.Age = null;
            this.Gender = null;
        }

        public void UpdatePhotoGallery(string[] Gallery)
        {
            this.Gallery = Gallery;
        }
    }
}