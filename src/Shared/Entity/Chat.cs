using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Entity
{
    public class Chat : EntityType
    {
        [Key]
        public string IdChat { get; set; }

        [Key]
        public DateTimeOffset DtMessage { get; set; }

        public string IdUserSender { get; set; }
        public TypeContent TypeContent { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; private set; }
        public DateTimeOffset? DtRead { get; private set; }
        public bool IsSync { get; private set; }
        public DateTimeOffset? DtSync { get; private set; }
    }
}