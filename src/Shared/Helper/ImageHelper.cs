using System;

namespace VerusDate.Shared.Helper
{
    public static class ImageHelper
    {
        public enum PhotoType
        {
            PhotoFace,
            PhotoGallery,
            PhotoValidation
        }

        public static string GetNoUserPhoto => "/img/nouser.jpg";

        public static string GetPhotoContainer(PhotoType type)
        {
            return type switch
            {
                PhotoType.PhotoFace => "photo-face",
                PhotoType.PhotoGallery => "photo-gallery",
                PhotoType.PhotoValidation => "photo-validation",
                _ => throw new InvalidOperationException(nameof(PhotoType)),
            };
        }

        public static bool ValidImage(byte[] buffer)
        {
            return true;
        }
    }
}