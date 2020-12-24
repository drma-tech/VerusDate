using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionDeslikeCommand : Shared.Model.Interaction, IRequest<bool> { }

    public class InteractionDeslikeHandler : IRequestHandler<InteractionDeslikeCommand, bool>
    {
        private readonly IRepository<Shared.Model.Interaction> _repo;

        public InteractionDeslikeHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Interaction>();
        }

        public async Task<bool> Handle(InteractionDeslikeCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.GetAsync(request.Id, request.IdInteraction, cancellationToken);

            if (obj == null)
            {
                obj = new Shared.Model.Interaction() { Id = request.Id, IdInteraction = request.IdInteraction };
                obj.ExecuteDeslike();
                return await _repo.CreateAsync(obj, cancellationToken) != null;
            }
            else
            {
                obj.ExecuteDeslike();
                return await _repo.UpdateAsync(obj, cancellationToken) != null;
            }
        }
    }
}