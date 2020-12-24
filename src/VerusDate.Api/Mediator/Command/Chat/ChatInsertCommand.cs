using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Command.Chat
{
    public class ChatInsertCommand : Shared.Model.Chat, IRequest<Shared.Model.Chat>
    {
        public List<Shared.Model.Chat> LstChat { get; private set; }
    }

    public class ChatInsertChatHandler : IRequestHandler<ChatInsertCommand, Shared.Model.Chat>
    {
        private readonly IRepository<Shared.Model.Chat> _repo;

        public ChatInsertChatHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Chat>();
        }

        public async Task<Shared.Model.Chat> Handle(ChatInsertCommand request, CancellationToken cancellationToken)
        {
            request.Type = "Chat";

            return await _repo.CreateAsync(request, cancellationToken);
        }
    }
}