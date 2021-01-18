using MediatR;
using Microsoft.Azure.Cosmos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Server.Mediator.Commands.Interaction
{
    public class InteractionGenerateChatCommand : CosmosBase, IRequest<ChatModel>
    {
        public InteractionGenerateChatCommand() : base(CosmosType.Chat)
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

    public class InteractionGenerateChatHandler : IRequestHandler<InteractionGenerateChatCommand, ChatModel>
    {
        private readonly IRepository _repo;

        public InteractionGenerateChatHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ChatModel> Handle(InteractionGenerateChatCommand request, CancellationToken cancellationToken)
        {
            if (request.IdLoggedUser == request.IdUserInteraction) throw new InvalidOperationException();

            var obj1 = await _repo.Get<InteractionModel>(request.Id, new PartitionKey(request.Key), cancellationToken);

            if (!obj1.Match.Value.Value)
            {
                throw new NotificationException("Match ainda não ocorreu nesta interação");
            }
            else if (!string.IsNullOrEmpty(obj1.IdChat))
            {
                throw new NotificationException("Chat já gerado");
            }
            else
            {
                var obj2 = await _repo.Get<InteractionModel>(obj1.GetInvertedId(), new PartitionKey(request.IdUserInteraction), cancellationToken);

                var chat = new ChatModel();

                chat.SetIds(null);

                obj1.IdChat = chat.Id;
                obj2.IdChat = chat.Id;

                await _repo.Update(obj1, cancellationToken);
                await _repo.Update(obj2, cancellationToken);

                return await _repo.Add(chat, cancellationToken);
            }
        }
    }
}