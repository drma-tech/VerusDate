using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionBlinkCommand : Shared.Model.Interaction.Interaction, IRequest<bool> { }

    public class InteractionBlinkHandler : IRequestHandler<InteractionBlinkCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionBlinkHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionBlinkCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<Shared.Model.Interaction.Interaction>(request.Id, request.Key, cancellationToken);

            obj.ExecuteBlink();

            return await _repo.Update(obj, request.Id, request.Key, cancellationToken) != null;
        }
    }
}