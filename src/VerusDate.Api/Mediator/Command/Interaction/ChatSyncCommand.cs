using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Interaction
{
    public class ChatSyncCommand : CosmosBase, IRequest<ChatItem>
    {
        public ChatSyncCommand() : base(CosmosType.Interaction)
        {
        }

        [Required]
        public string IdChat { get; set; }

        [Required]
        public string IdUserInteraction { get; set; }

        public ChatItem Item { get; set; }

        public override void SetIds(string IdLoggedUser)
        {
            this.SetId($"{IdLoggedUser}-{IdUserInteraction}");
            this.SetPartitionKey(IdLoggedUser);
        }
    }

    public class ChatSyncChatHandler : IRequestHandler<ChatSyncCommand, ChatItem>
    {
        private readonly IRepository _repo;

        public ChatSyncChatHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ChatItem> Handle(ChatSyncCommand request, CancellationToken cancellationToken)
        {
            var chat = await _repo.Get<ChatModel>(request.IdChat, request.IdChat.Split(":")[1], cancellationToken);

            if (!chat.Itens.Any()) //primeira msg enviada entre os dois usuários
            {
                var interactionUser = await _repo.Get<InteractionModel>(request.Id, request.Key, cancellationToken);
                interactionUser.StartedChat = true;
                await _repo.Update(interactionUser, cancellationToken);

                var interactionView = await _repo.Get<InteractionModel>(interactionUser.GetInvertedId(), request.IdUserInteraction, cancellationToken);
                interactionView.StartedChat = true;
                await _repo.Update(interactionView, cancellationToken);
            }

            chat.Itens.Add(request.Item);

            await _repo.Update(chat, cancellationToken);

            return request.Item;
        }
    }
}