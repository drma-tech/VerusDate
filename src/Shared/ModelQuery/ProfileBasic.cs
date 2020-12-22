using System;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.ModelQuery
{
    public class ProfileBasic
    {
        public string Id { get; set; }

        public string NickName { get; set; }
        public DateTime BirthDate { get; set; }
        public double? Distance { get; set; }
        public string MainPhoto { get; set; }
        public ActivityStatus ActivityStatus { get; set; }

        public string GetPhotoFace()
        {
            if (string.IsNullOrEmpty(MainPhoto))
                return "/img/nouser.jpg";
            else
                return MainPhoto;
        }
    }

    public class ProfileChatList : ProfileBasic
    {
        public int QtdUnread { get; set; }
    }
}