using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ChatModel : CosmosBase
    {
        public ChatModel() : base("Chat")
        {
        }

        public List<ChatItem> Itens { get; set; } = new List<ChatItem>();

        public override void SetIds(string IdLoggedUser)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Key = this.Id;
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