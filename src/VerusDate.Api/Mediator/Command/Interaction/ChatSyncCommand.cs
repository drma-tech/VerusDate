using MediatR;
using Microsoft.Azure.Cosmos;
using System.ComponentModel.DataAnnotations;
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

        public ChatItem Item { get; set; }

        public override void SetIds(string IdLoggedUser)
        {
            //do nothing
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
            var chat = await _repo.Get<ChatModel>(request.Id, new PartitionKey(request.Key), cancellationToken);

            chat.Itens.Add(request.Item);

            await _repo.Update(chat, cancellationToken);

            return request.Item;
        }
    }
}