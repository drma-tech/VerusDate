using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetCommand : MediatorQuery<InteractionModel>
    {
        public string IdUserInteraction { get; set; }
    }

    public class InteractionGetHandler : IRequestHandler<InteractionGetCommand, InteractionModel>
    {
        private readonly IRepository _repo;

        public InteractionGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<InteractionModel> Handle(InteractionGetCommand request, CancellationToken cancellationToken)
        {
            var Id = InteractionModel.GetId(request.IdLoggedUser, request.IdUserInteraction);

            return await _repo.Get<InteractionModel>(Id, Id, cancellationToken: cancellationToken);
        }
    }
}