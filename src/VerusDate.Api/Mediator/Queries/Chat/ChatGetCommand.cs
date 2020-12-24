using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Chat
{
    public class ChatGetCommand : IRequest<Shared.Model.Chat>
    {
        public string Id { get; set; }
    }

    public class ChatGetHandler : IRequestHandler<ChatGetCommand, Shared.Model.Chat>
    {
        private readonly IRepository<Shared.Model.Chat> _repo;

        public ChatGetHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Chat>();
        }

        public async Task<Shared.Model.Chat> Handle(ChatGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);
        }
    }
}