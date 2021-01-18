using MediatR;
using Microsoft.Azure.Cosmos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionBlinkCommand : CosmosBase, IRequest<bool>
    {
        public InteractionBlinkCommand() : base(CosmosType.Interaction)
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

    public class InteractionBlinkHandler : IRequestHandler<InteractionBlinkCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionBlinkHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionBlinkCommand request, CancellationToken cancellationToken)
        {
            if (request.IdLoggedUser == request.IdUserInteraction) throw new InvalidOperationException();

            var obj = await _repo.Get<InteractionModel>(request.Id, new PartitionKey(request.Key), cancellationToken);

            if (obj == null)
            {
                obj = new InteractionModel();

                obj.SetIds(request.IdLoggedUser);
                obj.SetIdInteraction(request.IdUserInteraction);

                obj.ExecuteBlink();

                return await _repo.Add(obj, cancellationToken) != null;
            }
            else //caso existe uma interação (like)
            {
                obj.ExecuteBlink();

                return await _repo.Update(obj, cancellationToken) != null;
            }
        }
    }
}