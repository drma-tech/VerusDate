using System;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Model.Profile;
using static VerusDate.Shared.Helper.ImageHelper;

namespace VerusDate.Shared.ModelQuery
{
    public class ProfileSearch
    {
        private readonly string BlobPath = "https://storageverusdate.blob.core.windows.net";

        public string Id { get; set; }

        public string NickName { get; set; }
        public DateTime BirthDate { get; set; }
        public ProfilePhoto Photo { get; set; }
        public ActivityStatus ActivityStatus { get; set; }
        public double Distance { get; set; }

        public void SetIds(string IdLoggedUser)
        {
            this.Id = IdLoggedUser;
        }

        public void UpdatePhoto(ProfilePhoto obj)
        {
            Photo = obj;
        }

        public string GetMainPhoto()
        {
            if (Photo == null || string.IsNullOrEmpty(Photo.Main))
                return GetNoUserPhoto;
            else
                return $"{BlobPath}/{GetPhotoContainer(PhotoType.PhotoFace)}/{Photo.Main}";
        }
    }

    public class ProfileChatList : ProfileSearch
    {
        public int QtdUnread { get; set; }
    }
}