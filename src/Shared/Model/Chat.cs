using System;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class Chat : ModelBase
    {
        public string IdChat { get; set; }

        public DateTimeOffset DtMessage { get; set; }

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