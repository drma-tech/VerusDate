using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class InteractionModel : CosmosBase
    {
        public InteractionModel() : base(CosmosType.Interaction)
        {
        }

        public static string GetId(CosmosType Type, string IdLoggedUser, string IdUserInteraction)
        {
            return $"{Type}:{IdLoggedUser}-{IdUserInteraction}";
        }

        public string GetInvertedId()
        {
            return $"{Type}:{IdUserInteraction}-{IdLoggedUser}";
        }

        public string IdLoggedUser { get; set; }
        public string IdUserInteraction { get; set; }

        public string NickNameLoggedUser { get; set; }
        public string MainPhotoLoggedUser { get; set; }

        public string NickNameInteraction { get; set; }
        public string MainPhotoInteraction { get; set; }

        public Action Like { get; set; } = new Action();
        public Action Deslike { get; set; } = new Action();
        public Action Blink { get; set; } = new Action();
        public Action Match { get; set; } = new Action();
        public Action Block { get; set; } = new Action();

        public List<ChatModel> Chat { get; set; } = new List<ChatModel>();

        public void ExecuteLike(string NickNameLoggedUser, string MainPhotoLoggedUser)
        {
            this.NickNameLoggedUser = NickNameLoggedUser;
            this.MainPhotoLoggedUser = MainPhotoLoggedUser;
            Like.Execute();
            DtUpdate = DateTime.UtcNow;
        }

        public void ExecuteDeslike()
        {
            Deslike.Execute();
            DtUpdate = DateTime.UtcNow;
        }

        public void ExecuteBlink(string NickNameLoggedUser, string MainPhotoLoggedUser)
        {
            this.NickNameLoggedUser = NickNameLoggedUser;
            this.MainPhotoLoggedUser = MainPhotoLoggedUser;
            Blink.Execute();
            DtUpdate = DateTime.UtcNow;
        }

        public void ExecuteMatch(string NickNameInteraction, string MainPhotoInteraction)
        {
            if (!Like.Value.Value) throw new InvalidOperationException("Ação só poderá ser feita depois do like");

            this.NickNameInteraction = NickNameInteraction;
            this.MainPhotoInteraction = MainPhotoInteraction;
            Match.Execute();
            DtUpdate = DateTime.UtcNow;
        }

        public void ExecuteBlock()
        {
            if (!Match.Value.Value) throw new InvalidOperationException("Ação só poderá ser feita depois do match");

            Block.Execute();
            DtUpdate = DateTime.UtcNow;
        }

        public bool ActiveInteraction()
        {
            var match = Match.Value.HasValue && Match.Value.Value;
            var blocked = Block.Value.HasValue && Block.Value.Value;

            return match && !blocked;
        }

        public override void SetIds(string IdLoggedUser)
        {
            this.IdLoggedUser = IdLoggedUser;
        }

        public void SetIdInteraction(string IdUserInteraction)
        {
            this.SetId($"{IdLoggedUser}-{IdUserInteraction}");
            this.SetPartitionKey(IdLoggedUser);
            this.IdUserInteraction = IdUserInteraction;
        }

        public void AddChat(ChatModel chat)
        {
            if (IsActiveInteraction())
            {
                Chat.Add(chat);
            }
            else
            {
                throw new InvalidOperationException("Operação não permitida");
            }
        }

        /// <summary>
        /// Possui match e não está bloqueado
        /// </summary>
        /// <returns></returns>
        public bool IsActiveInteraction()
        {
            var matched = Match.Value.HasValue && Match.Value.Value;
            var blocked = Block.Value.HasValue && Block.Value.Value;

            return matched && !blocked;
        }
    }

    public class Action
    {
        public bool? Value { get; set; }
        public DateTime? Date { get; set; }

        public void Execute()
        {
            Value = true;
            Date = DateTime.UtcNow;
        }
    }

    public class ChatModel
    {
        protected ChatModel()
        {
        }

        public DateTime DtMessage { get; set; } = DateTime.UtcNow;

        [Required]
        public string IdUserSender { get; set; }

        public TypeContent TypeContent { get; set; }

        [MaxLength(512)]
        public string Content { get; set; }

        public ChatModel(string IdUserSender, TypeContent TypeContent, string Content)
        {
            this.IdUserSender = IdUserSender;
            this.TypeContent = TypeContent;
            this.Content = Content;
        }
    }
}