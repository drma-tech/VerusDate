using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Command.Chat
{
    public class ChatSyncCommand : Shared.Model.Interaction.Chat, IRequest<Shared.Model.Interaction.Chat> { }

    public class ChatSyncChatHandler : IRequestHandler<ChatSyncCommand, Shared.Model.Interaction.Chat>
    {
        private readonly IRepository _repo;

        public ChatSyncChatHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Shared.Model.Interaction.Chat> Handle(ChatSyncCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<Shared.Model.Interaction.Chat>(request.Id, request.Id, cancellationToken: cancellationToken);

            obj.Itens = request.Itens;

            return await _repo.Update(obj, request.Id, request.Key, cancellationToken);
        }
    }
}