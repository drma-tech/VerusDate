using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Interaction
{
    public class InteractionLikeCommand : InteractionModel, IRequest<bool> { }

    public class InteractionLikeHandler : IRequestHandler<InteractionLikeCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionLikeHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionLikeCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<InteractionModel>(request.Id, request.Key, cancellationToken);

            if (obj == null)
            {
                request.SetIdInteraction(request.IdUserInteraction);
                obj = await _repo.Add(request, request.Id, cancellationToken);
            }

            obj.ExecuteLike();

            var mergeLike = await _repo.Update(obj, request.Id, request.Key, cancellationToken) != null;

            var matched = await _repo.Get<InteractionModel>(request.GetInvertedId(), request.IdUserInteraction, cancellationToken);

            //se o outro tbm deu like, gera o match para os dois
            if (matched != null && matched.Like.Value.Value)
            {
                obj.ExecuteMatch();

                matched.ExecuteMatch();

                var mergeUser1 = await _repo.Update(obj, request.Id, request.Key, cancellationToken) != null;

                var mergeUser2 = await _repo.Update(matched, request.GetInvertedId(), request.IdUserInteraction, cancellationToken) != null;

                return mergeUser1 && mergeUser2;
            }
            else
            {
                return mergeLike;
            }
        }
    }
}