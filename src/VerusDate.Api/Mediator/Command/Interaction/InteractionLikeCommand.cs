using MediatR;
using Microsoft.Azure.Cosmos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Interaction
{
    public class InteractionLikeCommand : CosmosBase, IRequest<InteractionModel>
    {
        public InteractionLikeCommand() : base(CosmosType.Interaction)
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

    public class InteractionLikeHandler : IRequestHandler<InteractionLikeCommand, InteractionModel>
    {
        private readonly IRepository _repo;

        public InteractionLikeHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<InteractionModel> Handle(InteractionLikeCommand request, CancellationToken cancellationToken)
        {
            if (request.IdLoggedUser == request.IdUserInteraction) throw new InvalidOperationException();

            var obj = await _repo.Get<InteractionModel>(request.Id, new PartitionKey(request.Key), cancellationToken);
            InteractionModel result;

            //executa a interação
            if (obj == null)
            {
                obj = new InteractionModel();

                obj.SetIds(request.IdLoggedUser);
                obj.SetIdInteraction(request.IdUserInteraction);

                obj.ExecuteLike();

                result = await _repo.Add(obj, cancellationToken);
            }
            else //caso existe uma interação (blink)
            {
                obj.ExecuteLike();

                result = await _repo.Update(obj, cancellationToken);
            }

            //executa o possível match
            var matched = await _repo.Get<InteractionModel>(obj.GetInvertedId(), new PartitionKey(request.IdUserInteraction), cancellationToken);

            if (matched != null && matched.Like.Value.Value) //se a outra pessoa deu like também
            {
                obj.ExecuteMatch();
                matched.ExecuteMatch();

                var mergeUser1 = await _repo.Update(obj, cancellationToken);
                await _repo.Update(matched, cancellationToken);

                return mergeUser1;
            }
            else
            {
                return result;
            }
        }
    }
}