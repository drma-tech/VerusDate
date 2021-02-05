using MediatR;
using Microsoft.Azure.Cosmos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Chat
{
    public class ChatSyncCommand : CosmosBase, IRequest<ChatModel>
    {
        public ChatSyncCommand() : base(CosmosType.Interaction)
        {
        }

        [Required]
        public string IdUserInteraction { get; set; }

        public string IdLoggedUser { get; private set; }

        public ChatItem chatItem { get; set; }

        public override void SetIds(string IdLoggedUser)
        {
            this.SetId($"{IdLoggedUser}-{IdUserInteraction}");
            this.SetPartitionKey(IdLoggedUser);
            this.IdLoggedUser = IdLoggedUser;
        }
    }

    public class ChatSyncChatHandler : IRequestHandler<ChatSyncCommand, ChatModel>
    {
        private readonly IRepository _repo;

        public ChatSyncChatHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ChatModel> Handle(ChatSyncCommand request, CancellationToken cancellationToken)
        {
            if (request.IdLoggedUser == request.IdUserInteraction) throw new InvalidOperationException();

            var interaction = await _repo.Get<InteractionModel>(request.Id, new PartitionKey(request.Key), cancellationToken);

            var chat = await _repo.Get<ChatModel>(interaction.IdChat, new PartitionKey(interaction.IdChat.Split(":")[1]), cancellationToken: cancellationToken);

            chat.Itens.Add(request.chatItem);

            return await _repo.Update(chat, cancellationToken);
        }
    }
}