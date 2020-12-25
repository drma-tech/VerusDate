using MediatR;
using Microsoft.Azure.CosmosRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionBlockCommand : Shared.Model.Interaction, IRequest<bool> { }

    public class InteractionBlockHandler : IRequestHandler<InteractionBlockCommand, bool>
    {
        private readonly IRepository<Shared.Model.Interaction> _repo;

        public InteractionBlockHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Interaction>();
        }

        public async Task<bool> Handle(InteractionBlockCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.GetAsync(request.Id, request.IdPrimary, cancellationToken);

            if (obj == null)
            {
                throw new InvalidOperationException("Block");
            }
            else
            {
                obj.ExecuteBlock();
                return await _repo.UpdateAsync(obj, cancellationToken) != null;
            }
        }
    }
}