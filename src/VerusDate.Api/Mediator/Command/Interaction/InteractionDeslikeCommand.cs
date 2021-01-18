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
    public class InteractionDeslikeCommand : CosmosBase, IRequest<bool>
    {
        public InteractionDeslikeCommand() : base(CosmosType.Interaction)
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

    public class InteractionDeslikeHandler : IRequestHandler<InteractionDeslikeCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionDeslikeHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionDeslikeCommand request, CancellationToken cancellationToken)
        {
            if (request.IdLoggedUser == request.IdUserInteraction) throw new InvalidOperationException();

            var obj = await _repo.Get<InteractionModel>(request.Id, new PartitionKey(request.Key), cancellationToken);

            if (obj == null)
            {
                obj = new InteractionModel();

                obj.SetIds(request.IdLoggedUser);
                obj.SetIdInteraction(request.IdUserInteraction);

                obj.ExecuteDeslike();

                return await _repo.Add(obj, cancellationToken) != null;
            }
            else
            {
                obj.ExecuteDeslike();

                return await _repo.Update(obj, cancellationToken) != null;
            }
        }
    }
}