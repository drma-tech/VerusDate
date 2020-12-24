using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionLikeCommand : Shared.Model.Interaction, IRequest<bool> { }

    public class InteractionLikeHandler : IRequestHandler<InteractionLikeCommand, bool>
    {
        private readonly IRepository<Shared.Model.Interaction> _repo;

        public InteractionLikeHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Interaction>();
        }

        public async Task<bool> Handle(InteractionLikeCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.GetAsync(request.Id, request.IdInteraction, cancellationToken);

            obj.ExecuteLike();

            var mergeLike = await _repo.UpdateAsync(obj, cancellationToken) != null;

            var matched = await _repo.GetAsync(request.IdInteraction, request.Id, cancellationToken);

            if (matched != null && matched.Like.Value) //se o outro tbm deu like, gera o match para os dois
            {
                obj.ExecuteMatch();

                matched.ExecuteMatch();

                var mergeUser1 = await _repo.UpdateAsync(obj, cancellationToken) != null;

                var mergeUser2 = await _repo.UpdateAsync(matched, cancellationToken) != null;

                return mergeUser1 && mergeUser2;
            }
            else
            {
                return mergeLike;
            }
        }
    }
}