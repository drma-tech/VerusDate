using MediatR;
using Microsoft.Azure.Cosmos;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Chat
{
    public class ChatSyncCommand : ChatModel, IRequest<ChatModel> { }

    public class ChatSyncChatHandler : IRequestHandler<ChatSyncCommand, ChatModel>
    {
        private readonly IRepository _repo;

        public ChatSyncChatHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ChatModel> Handle(ChatSyncCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<ChatModel>(request.Id, new PartitionKey(request.Key), cancellationToken: cancellationToken);

            obj.Itens = request.Itens;

            return await _repo.Update(obj, cancellationToken);
        }
    }
}