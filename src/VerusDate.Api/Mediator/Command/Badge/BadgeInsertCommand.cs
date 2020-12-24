using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Command.Badge
{
    public class BadgeInsertCommand : Shared.Model.Badge, IRequest<Shared.Model.Badge> { }

    public class BadgeInsertHandler : IRequestHandler<BadgeInsertCommand, Shared.Model.Badge>
    {
        private readonly IRepository<Shared.Model.Badge> _repo;

        public BadgeInsertHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Badge>();
        }

        public async Task<Shared.Model.Badge> Handle(BadgeInsertCommand request, CancellationToken cancellationToken)
        {
            request.Type = "Badge";

            return await _repo.CreateAsync(request, cancellationToken);
        }
    }
}