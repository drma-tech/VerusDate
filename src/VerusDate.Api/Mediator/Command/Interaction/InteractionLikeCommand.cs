using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Command.Interaction
{
    public class InteractionLikeCommand : CosmosBase, IRequest<bool>
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

    public class InteractionLikeHandler : IRequestHandler<InteractionLikeCommand, bool>
    {
        private readonly IRepository _repo;

        public InteractionLikeHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(InteractionLikeCommand request, CancellationToken cancellationToken)
        {
            if (request.IdLoggedUser == request.IdUserInteraction) throw new InvalidOperationException("Você não pode interagir com você mesmo");

            var interactionUser = await _repo.Get<InteractionModel>(request.Id, request.Key, cancellationToken);
            var profileUser = await _repo.Get<ProfileModel>(CosmosType.Profile + ":" + request.IdLoggedUser, request.IdLoggedUser, cancellationToken);
            bool result;

            profileUser.Gamification.RemoveFood();

            //executa a interação
            if (interactionUser == null)
            {
                interactionUser = new InteractionModel();

                interactionUser.SetIds(request.IdLoggedUser);
                interactionUser.SetIdInteraction(request.IdUserInteraction);

                interactionUser.ExecuteLike(profileUser.NickName, profileUser.Photo?.Main);

                result = await _repo.Add(interactionUser, cancellationToken) != null;
            }
            else //caso existe uma interação (blink)
            {
                interactionUser.ExecuteLike(profileUser.NickName, profileUser.Photo?.Main);

                result = await _repo.Update(interactionUser, cancellationToken);
            }

            //registra a interação. necessário, pois o cosmos não faz cross join com outros documentos (list match)
            var profileInteraction = await _repo.Get<ProfileModel>(CosmosType.Profile + ":" + request.IdUserInteraction, request.IdUserInteraction, cancellationToken);
            if (!Array.Exists(profileInteraction.PassiveInteractions, x => x == request.IdLoggedUser))
            {
                profileInteraction.PassiveInteractions = profileInteraction.PassiveInteractions.Concat(new string[] { request.IdLoggedUser }).ToArray();
            }

            //recupera a interação e executa o possível match
            var matched = await _repo.Get<InteractionModel>(interactionUser.GetInvertedId(), request.IdUserInteraction, cancellationToken);

            if (matched != null && matched.Like.Value.Value) //se a outra pessoa deu like também
            {
                var chat = await _repo.Add(new ChatModel(Guid.NewGuid()), cancellationToken);

                //registra o match nos dois
                interactionUser.ExecuteMatch(profileInteraction.NickName, profileInteraction.Photo?.Main, chat.Id);
                matched.ExecuteMatch(profileUser.NickName, profileUser.Photo?.Main, chat.Id);

                //atualiza as interações
                var mergeUser1 = await _repo.Update(interactionUser, cancellationToken);
                await _repo.Update(matched, cancellationToken);

                //atualiza profile (passive interactions)
                await _repo.Update(profileInteraction, cancellationToken);
                await _repo.Update(profileUser, cancellationToken);

                return mergeUser1;
            }
            else
            {
                //atualiza profile (passive interactions)
                await _repo.Update(profileInteraction, cancellationToken);
                await _repo.Update(profileUser, cancellationToken);

                return result;
            }
        }
    }
}