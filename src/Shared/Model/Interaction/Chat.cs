using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model.Interaction
{
    public class Chat : CosmosBase
    {
        public Chat() : base("Chat")
        {
        }

        public List<ChatItem> Itens { get; set; } = new List<ChatItem>();

        public override void SetIdLoggedUser(string IdUser)
        {
            throw new NotImplementedException();
        }
    }

    public class ChatItem
    {
        public DateTimeOffset DtMessage { get; set; }

        [Required]
        public string IdUserSender { get; set; }

        public TypeContent TypeContent { get; set; }

        [MaxLength(512)]
        public string Content { get; set; }
    }
}