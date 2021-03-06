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

        public ChatModel(Guid guid) : base(CosmosType.Chat)
        {
            this.SetId(guid.ToString());
            this.SetPartitionKey(guid.ToString());
        }

        public List<ChatItem> Itens { get; set; } = new List<ChatItem>();

        public override void SetIds(string IdLoggedUser)
        {
            //do nothing
        }
    }

    public class ChatItem
    {
        protected ChatItem()
        {
        }

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