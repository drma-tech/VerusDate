using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionBlockCommand : CosmosBase, IRequest<bool>
    {
        public InteractionBlockCommand() : base(CosmosType.Interaction)
        {
        }

        [Required]
        public string IdUserInteraction { get; set; }

        public string IdLoggedUser { get; private set; }

        public override void SetIds(string IdLoggedUser)
        {
            this.SetId($"{IdLoggedUser}-{IdUserInteraction}");
            this.SetPartitionKey(IdLoggedUser);
            this.IdLoggedUser = IdLoggedUser;
        }
    }

    public class InteractionBlockHandler : IRequestHandler<InteractionBlockCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionBlockHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionBlockCommand request, CancellationToken cancellationToken)
        {
            if (request.IdLoggedUser == request.IdUserInteraction) throw new InvalidOperationException();

            var obj = await _repo.Get<InteractionModel>(request.Id, request.Key, cancellationToken);

            if (obj == null)
            {
                throw new InvalidOperationException("Block");
            }
            else
            {
                obj.ExecuteBlock();
                return await _repo.Update(obj, cancellationToken) != null;
            }
        }
    }
}