using System;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Model.Profile;

namespace VerusDate.Shared.ModelQuery
{
    public class ProfileSearch
    {
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
    }

    public class ProfileChatList : ProfileSearch
    {
        public int QtdUnread { get; set; }
    }
}