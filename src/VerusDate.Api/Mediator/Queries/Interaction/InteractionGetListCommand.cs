using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetListCommand : MediatorQuery<IEnumerable<InteractionModel>> { }

    public class InteractionGetListHandler : IRequestHandler<InteractionGetListCommand, IEnumerable<InteractionModel>>
    {
        private readonly IRepository _repo;

        public InteractionGetListHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<InteractionModel>> Handle(InteractionGetListCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<InteractionModel>(x => x.Key == request.IdLoggedUser, cancellationToken);
        }
    }
}