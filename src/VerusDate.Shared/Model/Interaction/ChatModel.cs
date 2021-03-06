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
            var guid = Guid.NewGuid().ToString();
            this.SetId(guid);
            this.SetPartitionKey(guid);
        }

        public List<ChatItem> Itens { get; set; } = new List<ChatItem>();

        public override void SetIds(string IdLoggedUser)
        {
            //do nothing
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

        public ChatItem(string IdUserSender, TypeContent TypeContent, string Content)
        {
            this.IdUserSender = IdUserSender;
            this.TypeContent = TypeContent;
            this.Content = Content;
        }
    }
}