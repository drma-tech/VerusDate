using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionBlinkCommand : InteractionModel, IRequest<bool> { }

    public class InteractionBlinkHandler : IRequestHandler<InteractionBlinkCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionBlinkHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionBlinkCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<InteractionModel>(request.Id, request.Key, cancellationToken);

            obj.ExecuteBlink();

            return await _repo.Update(obj, request.Id, request.Key, cancellationToken) != null;
        }
    }
}