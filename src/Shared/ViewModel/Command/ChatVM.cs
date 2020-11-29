using Dapper.Contrib.Extensions;
using System;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.ViewModel.Command
{
    [Table("Chat")]
    public class ChatVM : ViewModelCommand
    {
        [ExplicitKey]
        public string IdChat { get; init; }

        [ExplicitKey]
        public DateTimeOffset DtMessage { get; init; }

        public string IdUserSender { get; set; }
        public TypeContent TypeContent { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; private set; }
        public DateTimeOffset? DtRead { get; private set; }
        public bool IsSync { get; private set; }
        public DateTimeOffset? DtSync { get; private set; }

        public override void LoadDefatultData()
        {
            TypeContent = TypeContent.Message;
        }

        public void SetRead()
        {
            IsRead = true;
            DtRead = DateTimeOffset.UtcNow;
        }

        public void SetSync()
        {
            IsSync = true;
            DtSync = DateTimeOffset.UtcNow;
        }
    }
}