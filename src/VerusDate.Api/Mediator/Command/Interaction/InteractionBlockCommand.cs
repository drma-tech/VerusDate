using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionBlockCommand : InteractionModel, IRequest<bool> { }

    public class InteractionBlockHandler : IRequestHandler<InteractionBlockCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionBlockHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionBlockCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.Get<InteractionModel>(request.Id, request.Key, cancellationToken);

            if (obj == null)
            {
                throw new InvalidOperationException("Block");
            }
            else
            {
                obj.ExecuteBlock();
                return await _repo.Update(obj, request.Id, request.Key, cancellationToken) != null;
            }
        }
    }
}