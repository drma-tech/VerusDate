using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

            var obj = await _repo.Get<InteractionModel>(request.Id, request.Key, cancellationToken);
            var profileUser = await _repo.Get<ProfileModel>(CosmosType.Profile + ":" + request.IdLoggedUser, request.IdLoggedUser, cancellationToken);

            //registra a interação. necessário, pois o cosmos não faz cross join com outros documentos (list match)
            var profile = await _repo.Get<ProfileModel>(CosmosType.Profile + ":" + request.IdUserInteraction, request.IdUserInteraction, cancellationToken);
            if (!Array.Exists(profile.PassiveInteractions, x => x == request.IdLoggedUser))
            {
                profile.PassiveInteractions = profile.PassiveInteractions.Concat(new string[] { request.IdLoggedUser }).ToArray();
            }
            await _repo.Update(profile, cancellationToken);

            if (obj == null)
            {
                obj = new InteractionModel();

                obj.SetIds(request.IdLoggedUser);
                obj.SetIdInteraction(request.IdUserInteraction);

                obj.ExecuteLike(profileUser.NickName, profileUser.Photo.Main);
                obj.ExecuteBlink(profileUser.NickName, profileUser.Photo.Main);

                return await _repo.Add(obj, cancellationToken) != null;
            }
            else //caso existe uma interação (like)
            {
                obj.ExecuteLike(profileUser.NickName, profileUser.Photo.Main);
                obj.ExecuteBlink(profileUser.NickName, profileUser.Photo.Main);

                return await _repo.Update(obj, cancellationToken);
            }
        }
    }
}