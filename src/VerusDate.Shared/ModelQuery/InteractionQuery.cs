using VerusDate.Shared.Core;
using static VerusDate.Shared.Helper.ImageHelper;

namespace VerusDate.Shared.Model
{
    public enum TypeUser
    {
        LoggedUser,
        InteractionUser
    }

    public class InteractionQuery : CosmosBaseQuery
    {
        private readonly string BlobPath = "https://storageverusdate.blob.core.windows.net";

        public string IdLoggedUser { get; set; }
        public string IdUserInteraction { get; set; }

        public string NickNameLoggedUser { get; set; }
        public string MainPhotoLoggedUser { get; set; }

        public string NickNameInteraction { get; set; }
        public string MainPhotoInteraction { get; set; }

        public Action Like { get; set; } = new Action();
        public Action Deslike { get; set; } = new Action();
        public Action Blink { get; set; } = new Action();
        public Action Match { get; set; } = new Action();
        public Action Block { get; set; } = new Action();

        public string IdChat { get; set; }
        public bool StartedChat { get; set; }

        public string GetMainPhoto(TypeUser type)
        {
            var main = type == TypeUser.LoggedUser ? MainPhotoLoggedUser : MainPhotoInteraction;

            if (string.IsNullOrEmpty(main))
                return GetNoUserPhoto;
            else if (main.StartsWith("https://"))
                return main;
            else
                return $"{BlobPath}/{GetPhotoContainer(PhotoType.PhotoFace)}/{main}";
        }
    }
}