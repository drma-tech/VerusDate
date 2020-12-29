using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Queries.Chat
{
    public class ChatGetCommand : IRequest<Shared.Model.Interaction.Chat>
    {
        public string Id { get; set; }
    }

    public class ChatGetHandler : IRequestHandler<ChatGetCommand, Shared.Model.Interaction.Chat>
    {
        private readonly IRepository _repo;

        public ChatGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Shared.Model.Interaction.Chat> Handle(ChatGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Get<Shared.Model.Interaction.Chat>(request.Id, request.Id, cancellationToken: cancellationToken);
        }
    }
}