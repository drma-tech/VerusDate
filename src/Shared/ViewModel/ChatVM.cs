using Dapper.Contrib.Extensions;
using System;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.ViewModel
{
    [Table("Chat")]
    public class ChatVM : ViewModelType
    {
        /// <summary>
        /// Use for API
        /// </summary>
        public ChatVM()
        {
        }

        public ChatVM(string IdChat, string IdUserSender, TypeContent TypeContent, string Content)
        {
            this.IdChat = IdChat;
            this.IdUserSender = IdUserSender;
            this.TypeContent = TypeContent;
            this.Content = Content;
        }

        [ExplicitKey]
        public string IdChat { get; set; }

        [ExplicitKey]
        public DateTimeOffset DtMessage { get; set; } = DateTimeOffset.UtcNow;

        public string IdUserSender { get; set; }
        public TypeContent TypeContent { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public bool IsSync { get; set; }

        public void SetSync()
        {
            IsSync = true;
        }
    }
}