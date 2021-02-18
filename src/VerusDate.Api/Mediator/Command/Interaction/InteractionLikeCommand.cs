using MediatR;
using Microsoft.Azure.Cosmos;
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
            if (request.IdLoggedUser == request.IdUserInteraction) throw new InvalidOperationException("Você não pode interagir com você mesmo");

            var obj = await _repo.Get<InteractionModel>(request.Id, new PartitionKey(request.Key), cancellationToken);
            var profileUser = await _repo.Get<ProfileModel>(CosmosType.Profile + ":" + request.IdLoggedUser, new PartitionKey(request.IdLoggedUser), cancellationToken);
            InteractionModel result;

            //executa a interação
            if (obj == null)
            {
                obj = new InteractionModel();

                obj.SetIds(request.IdLoggedUser);
                obj.SetIdInteraction(request.IdUserInteraction);

                obj.ExecuteLike(profileUser.Basic.NickName, profileUser.Photo.Main);

                result = await _repo.Add(obj, cancellationToken);
            }
            else //caso existe uma interação (blink)
            {
                obj.ExecuteLike(profileUser.Basic.NickName, profileUser.Photo.Main);

                result = await _repo.Update(obj, cancellationToken);
            }

            //registra a interação. necessário, pois o cosmos não faz cross join com outros documentos (list match)
            var profileInteraction = await _repo.Get<ProfileModel>(CosmosType.Profile + ":" + request.IdUserInteraction, new PartitionKey(request.IdUserInteraction), cancellationToken);
            if (!Array.Exists(profileInteraction.PassiveInteractions, x => x == request.IdLoggedUser))
            {
                profileInteraction.PassiveInteractions = profileInteraction.PassiveInteractions.Concat(new string[] { request.IdLoggedUser }).ToArray();
            }

            //recupera a interação e executa o possível match
            var matched = await _repo.Get<InteractionModel>(obj.GetInvertedId(), new PartitionKey(request.IdUserInteraction), cancellationToken);

            if (matched != null && matched.Like.Value.Value) //se a outra pessoa deu like também
            {
                //registra o match nos dois
                obj.ExecuteMatch(profileInteraction.Basic.NickName, profileInteraction.Photo.Main);
                matched.ExecuteMatch(profileUser.Basic.NickName, profileUser.Photo.Main);

                //registra o chat dos dois
                var chat = new ChatModel();
                chat.SetIds(null);

                obj.IdChat = chat.Id;
                matched.IdChat = chat.Id;

                //atualiza as interações
                var mergeUser1 = await _repo.Update(obj, cancellationToken);
                await _repo.Update(matched, cancellationToken);

                //insere o chat
                await _repo.Add(chat, cancellationToken);

                //atualiza profile (passive interactions)
                await _repo.Update(profileInteraction, cancellationToken);

                return mergeUser1;
            }
            else
            {
                //atualiza profile (passive interactions)
                await _repo.Update(profileInteraction, cancellationToken);

                return result;
            }
        }
    }
}