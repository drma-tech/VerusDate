using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionDeslikeCommand : InteractionModel, IRequest<bool> { }

    public class InteractionDeslikeHandler : IRequestHandler<InteractionDeslikeCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionDeslikeHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionDeslikeCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<InteractionModel>(request.Id, request.Key, cancellationToken);

            if (obj == null)
            {
                request.SetIdInteraction(request.IdUserInteraction);
                obj = await _repo.Add(request, request.Id, cancellationToken);
            }

            obj.ExecuteLike();

            return await _repo.Update(obj, request.Id, request.Id, cancellationToken) != null;
        }
    }
}