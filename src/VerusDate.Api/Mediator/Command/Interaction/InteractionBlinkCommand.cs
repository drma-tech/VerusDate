using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionBlinkCommand : Shared.Model.Interaction, IRequest<bool> { }

    public class InteractionBlinkHandler : IRequestHandler<InteractionBlinkCommand, bool>
    {
        private readonly IRepository<Shared.Model.Interaction> _repo;

        public InteractionBlinkHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Interaction>();
        }

        public async Task<bool> Handle(InteractionBlinkCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.GetAsync(request.Id, request.IdInteraction, cancellationToken);

            obj.ExecuteBlink();

            return await _repo.UpdateAsync(obj, cancellationToken) != null;
        }
    }
}