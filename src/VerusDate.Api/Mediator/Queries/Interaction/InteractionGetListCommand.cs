using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetListCommand : IRequest<IEnumerable<Shared.Model.Interaction.Interaction>>
    {
        public string Id { get; set; }
    }

    public class InteractionGetListHandler : IRequestHandler<InteractionGetListCommand, IEnumerable<Shared.Model.Interaction.Interaction>>
    {
        private readonly IRepository _repo;

        public InteractionGetListHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Shared.Model.Interaction.Interaction>> Handle(InteractionGetListCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<Shared.Model.Interaction.Interaction>(x => x.Key == request.Id, cancellationToken);
        }
    }
}