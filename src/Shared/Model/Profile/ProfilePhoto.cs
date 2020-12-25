using System;

namespace VerusDate.Shared.Model.Profile
{
    public class ProfilePhoto
    {
        public string Main { get; private set; }
        public string Validation { get; private set; }
        public string[] Gallery { get; private set; } = Array.Empty<string>();

        public void UpdateMainPhoto(string Main)
        {
            this.Main = Main;
        }

        public void UpdatePhotoGallery(string[] Gallery)
        {
            this.Gallery = Gallery;
        }

        public string GetMainPhoto()
        {
            if (string.IsNullOrEmpty(Main))
                return "/img/nouser.jpg";
            else
                return Main;
        }
    }
}