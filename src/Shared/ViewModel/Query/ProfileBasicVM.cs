using Dapper.Contrib.Extensions;
using System;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.ViewModel.Query
{
    public class ProfileBasicVM : ViewModelQuery
    {
        [ExplicitKey]
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

    public class ProfileChatListVM : ProfileBasicVM
    {
        public int QtdUnread { get; set; }
    }
}