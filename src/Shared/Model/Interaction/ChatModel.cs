using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ChatModel : CosmosBase
    {
        public ChatModel() : base(CosmosType.Chat)
        {
        }

        public List<ChatItem> Itens { get; set; } = new List<ChatItem>();

        public override void SetIds(string IdLoggedUser)
        {
            var guid = Guid.NewGuid().ToString();
            this.SetId(guid);
            this.SetPartitionKey(guid);
        }
    }

    public class ChatItem
    {
        public DateTime DtMessage { get; set; } = DateTime.UtcNow;

        [Required]
        public string IdUserSender { get; set; }

        public TypeContent TypeContent { get; set; }

        [MaxLength(512)]
        public string Content { get; set; }
    }
}