using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetListCommand : IRequest<IEnumerable<Shared.Model.Interaction>>
    {
        public string Id { get; set; }
    }

    public class InteractionGetListHandler : IRequestHandler<InteractionGetListCommand, IEnumerable<Shared.Model.Interaction>>
    {
        private readonly IRepository<Shared.Model.Interaction> _repo;

        public InteractionGetListHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Interaction>();
        }

        public async Task<IEnumerable<Shared.Model.Interaction>> Handle(InteractionGetListCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GetByQueryAsync("SELECT * FROM Interaction WHERE Id = @IdUser", cancellationToken: cancellationToken);
        }
    }
}