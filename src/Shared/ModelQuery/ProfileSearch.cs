using System;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Model;
using static VerusDate.Shared.Helper.ImageHelper;

namespace VerusDate.Shared.ModelQuery
{
    public class ProfileSearch : CosmosBaseQuery
    {
        private readonly string BlobPath = "https://storageverusdate.blob.core.windows.net";

        public string Id { get; set; }

        public string NickName { get; set; }
        public DateTime BirthDate { get; set; }
        public ProfilePhotoModel Photo { get; set; }
        public ActivityStatus ActivityStatus { get; set; }
        public double Distance { get; set; }

        public void SetIds(string IdLoggedUser)
        {
            this.Id = IdLoggedUser;
        }

        public void UpdatePhoto(ProfilePhotoModel obj)
        {
            Photo = obj;
        }

        public string GetMainPhoto()
        {
            if (Photo == null || string.IsNullOrEmpty(Photo.Main))
                return GetNoUserPhoto;
            else if (Photo.Main.StartsWith("https://"))
                return Photo.Main;
            else
                return $"{BlobPath}/{GetPhotoContainer(PhotoType.PhotoFace)}/{Photo.Main}";
        }
    }

    public class ProfileChatListModel : ProfileSearch
    {
        public int QtdUnread { get; set; }
    }
}